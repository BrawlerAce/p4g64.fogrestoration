using p4g64.fogrestoration.Native;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using static p4g64.fogrestoration.Utils;
using File = p4g64.fogrestoration.Native.File;
using IReloadedHooks = Reloaded.Hooks.ReloadedII.Interfaces.IReloadedHooks;

namespace p4g64.fogrestoration;

public unsafe class Skybox
{
    private IAsmHook _skyBoxFileHook;
    private IReverseWrapper<LoadSkyboxFileDelegate> _loadSkyboxReverseWrapper;
    
    public Skybox(IReloadedHooks hooks)
    {
        SigScan("48 8B D8 4C 8B 40 ?? 4D 85 C0 0F 84 ?? ?? ?? ?? 48 8B 46 ??", "LoadSkyboxFile", address =>
        {
            string[] function =
            {
                "use64",
                "push rax \n push rdx",
                "sub rsp, 32",
                hooks.Utilities.GetAbsoluteCallMnemonics(LoadSkyboxFile, out _loadSkyboxReverseWrapper),
                "add rsp, 32",
                "cmp rax, 0",
                // If skybox was null just do original stuff
                "je original",
                "pop rdx \n add rsp, 8", // Leave the modded skybox in rax
                "jmp endHook",
                "label original",
                "pop rdx \n pop rax", // Put stuff back to normal
                "label endHook",
            };

            _skyBoxFileHook = hooks.CreateAsmHook(function, address, AsmHookBehaviour.ExecuteFirst).Activate();
        });
    }

    /// <summary>
    /// Tries to load a modified skybox file
    /// </summary>
    /// <returns>A pointer to the modified skybox file or 0 if there is none</returns>
    private File.FileInfo* LoadSkyboxFile()
    {
        var weather = Field.GetWeather();
        var major = Field.CurrentField->Major;
        var minor = Field.CurrentField->RealMinor;

        var skyboxName = $"sky_sphere_{major}_{minor}_{weather}.AMD";
        var skyboxFile = File.LoadFileInPak(skyboxName, 0, "field/pack/object.arc");

        if (skyboxFile->Data == null)
        {
            LogDebug($"Custom skybox {skyboxName} does not exist, loading vanilla skybox.");
            return null;
        }
        else
        {
            LogDebug($"Loading custom skybox {skyboxName}.");
            return skyboxFile;
        }
    }
    
    private delegate File.FileInfo* LoadSkyboxFileDelegate();
}