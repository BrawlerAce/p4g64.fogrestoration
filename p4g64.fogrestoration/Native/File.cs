using Reloaded.Hooks.ReloadedII.Interfaces;
using System.Runtime.InteropServices;
using static p4g64.fogrestoration.Utils;

namespace p4g64.fogrestoration.Native;

public unsafe class File
{
    public static LoadFileInPakDelegate LoadFileInPak;
    public static LoadFileDelegate LoadFile;

    public static void Initialise(IReloadedHooks hooks)
    {
        SigScan("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B 05 ?? ?? ?? ?? 48 31 E0 48 89 44 24 ?? 48 89 CE", "LoadFileInPak",
            address =>
            {
                LoadFileInPak = hooks.CreateWrapper<LoadFileInPakDelegate>(address, out _);
            });

        SigScan("48 89 6C 24 ?? 56 57 41 56 48 81 EC 30 03 00 00", "LoadFile", address =>
        {
            LoadFile = hooks.CreateWrapper<LoadFileDelegate>(address, out _);
        });
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct FileInfo
    {
        [FieldOffset(8)]
        public void* Data;

        [FieldOffset(0x10)]
        public int Length;

        // Unsure on actual length of this name, probably can be longer
        [FieldOffset(0x14)]
        public fixed char Name[64];
    }

    public delegate nuint LoadFileDelegate(string filePath, int param_2);
    public delegate FileInfo* LoadFileInPakDelegate(string pathInPak, nuint param_2, string pakPath);
}