using Reloaded.Hooks.ReloadedII.Interfaces;
using System.Runtime.InteropServices;
using static p4g64.fogrestoration.Utils;

namespace p4g64.fogrestoration.Native;
internal unsafe class Field
{
    public static CurrentFieldInfo* CurrentField => *_currentField;

    private static CurrentFieldInfo** _currentField;

    public static GetWeatherDelegate GetWeather;

    public static void Initialise(IReloadedHooks hooks)
    {
        SigScan("4C 8B 15 ?? ?? ?? ?? 49 8D 92 ?? ?? ?? ?? 4C 63 02", "CurrentFieldPtrPtr", address =>
        {
            _currentField = (CurrentFieldInfo**)GetGlobalAddress(address + 3);
            LogDebug($"Found CurrentFieldPtr at 0x{(nuint)_currentField:X}");
        });

        SigScan("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8D 0D ?? ?? ?? ??", "GetWeatherPtr", address =>
        {
            GetWeather = hooks.CreateWrapper<GetWeatherDelegate>((long)GetGlobalAddress(address + 1), out _);
        });

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CurrentFieldInfo
    {
        [FieldOffset(0)]
        public int Major;

        [FieldOffset(4)]
        public int BaseMinor;

        [FieldOffset(0x16)]
        public int RealMinor;
    }

    public delegate byte GetWeatherDelegate();

}
