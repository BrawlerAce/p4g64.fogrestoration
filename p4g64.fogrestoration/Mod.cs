using p4g64.fogrestoration.Configuration;
using p4g64.fogrestoration.Native;
using p4g64.fogrestoration.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using CriFs.V2.Hook;
using CriFs.V2.Hook.Interfaces;
using PAK.Stream.Emulator;
using PAK.Stream.Emulator.Interfaces;
using static p4g64.fogrestoration.Utils;
using File = p4g64.fogrestoration.Native.File;
using System.Runtime.Intrinsics.Arm;

namespace p4g64.fogrestoration
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;
        
        private Skybox _skybox;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;


            // For more information about this template, please see
            // https://reloaded-project.github.io/Reloaded-II/ModTemplate/

            // If you want to implement e.g. unload support in your mod,
            // and some other neat features, override the methods in ModBase.

            // TODO: Implement some mod logic

            var criFsController = _modLoader.GetController<ICriFsRedirectorApi>();
            if (criFsController == null || !criFsController.TryGetTarget(out var criFsApi))
            {
                _logger.WriteLine($"criFSController returned as null! p4g64.fogrestoration will be lost in the fog...", System.Drawing.Color.Red);
                return;
            }

            var PakEmulatorController = _modLoader.GetController<IPakEmulator>();
            if (PakEmulatorController == null || !PakEmulatorController.TryGetTarget(out var _PakEmulator))
            {
                _logger.WriteLine($"PakEmulatorController returned as null! p4g64.fogrestoration may never reach the truth...", System.Drawing.Color.Red);
                return;
            }

            var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);

            this._modLoader.OnModLoaderInitialized += () =>
            {
            };

            Utils.Initialise(_logger, _configuration, _modLoader);
            File.Initialise(_hooks!);
            Field.Initialise(_hooks!);

            _skybox = new Skybox(_hooks!);

            // Yanderedev ass code istg (at least I never claimed I was good at coding!)

            // ==================
            // ==================
            // Texture Selection
            // ==================
            // ==================

            // TV Static
            var mods = _modLoader.GetActiveMods();
            if (mods.Any(x => x.Generic.ModId == "p4gpc.notvstatic64"))
            {
                _logger.WriteLine($"Found \"No TV Static+\", disabling P4 TV static.", System.Drawing.Color.Green);
            }

            else if (_configuration.StaticENV == Config.TexTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "Textures", "Static"));
            }

            // Fog Clouds
            if (_configuration.FogENV == Config.TexTypeA.P4)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "Textures", "Fog"));
            }

            // ==================
            // ==================
            // ENVs - TV World
            // ==================
            // ==================

            // Entrance
            if (_configuration.EntranceENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "TVWorld", "Entrance", "PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "TVWorld", "Entrance", "CriV2"));
            }

            // Velvet Room
            if (_configuration.VelvetENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "TVWorld", "Velvet", "PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "TVWorld", "Velvet", "CriV2"));
            }

            // ==================
            // ==================
            // ENVs - Dungeons
            // ==================
            // ==================

            // ???
            if (_configuration.DreamENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Foggy/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Foggy/Dungeon1/CriV2"));
            }
            if (_configuration.DreamENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Foggy/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Foggy/BossBattle/CriV2"));
            }

            // Twisted Shopping District
            if (_configuration.TwistedENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Twisted/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Twisted/Entrance/CriV2"));
            }
            if (_configuration.TwistedENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Twisted/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Twisted/DungeonBoss/CriV2"));
            }
            if (_configuration.TwistedENV_FirstBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Twisted/FirstBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Twisted/FirstBattle/CriV2"));
            }
            if (_configuration.TwistedENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Twisted/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Twisted/BossBattle/CriV2"));
            }

            // Yukiko's Castle
            if (_configuration.CastleENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/Entrance/CriV2"));
            }
            if (_configuration.CastleENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon1/CriV2"));
            }
            if (_configuration.CastleENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon2/CriV2"));
            }
            if (_configuration.CastleENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/Dungeon3/CriV2"));
            }
            if (_configuration.CastleENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/DungeonBoss/CriV2"));
            }
            if (_configuration.CastleENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/Battle/CriV2"));
            }
            if (_configuration.CastleENV_MiniBossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/MiniBossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/MiniBossBattle/CriV2"));
            }
            if (_configuration.CastleENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Castle/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Castle/BossBattle/CriV2"));
            }

            // Steamy Bathhouse
            if (_configuration.SaunaENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Entrance/CriV2"));
            }
            if (_configuration.SaunaENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon1/CriV2"));
            }
            if (_configuration.SaunaENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon2/CriV2"));
            }
            if (_configuration.SaunaENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Dungeon3/CriV2"));
            }
            if (_configuration.SaunaENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/DungeonBoss/CriV2"));
            }
            if (_configuration.SaunaENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/Battle/CriV2"));
            }
            if (_configuration.SaunaENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Sauna/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Sauna/BossBattle/CriV2"));
            }

            // Marukyu Striptease
            if (_configuration.ClubENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/Entrance/CriV2"));
            }
            if (_configuration.ClubENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon1/CriV2"));
            }
            if (_configuration.ClubENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon2/CriV2"));
            }
            if (_configuration.ClubENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/Dungeon3/CriV2"));
            }
            if (_configuration.ClubENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/DungeonBoss/CriV2"));
            }
            if (_configuration.ClubENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/Battle/CriV2"));
            }
            if (_configuration.ClubENV_BossBattle1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/BossBattle1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/BossBattle1/CriV2"));
            }
            if (_configuration.ClubENV_BossBattle2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Club/BossBattle2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Club/BossBattle2/CriV2"));
            }

            // Void Quest
            if (_configuration.GameENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/Entrance/CriV2"));
            }
            if (_configuration.GameENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon1/CriV2"));
            }
            if (_configuration.GameENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon2/CriV2"));
            }
            if (_configuration.GameENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/Dungeon3/CriV2"));
            }
            if (_configuration.GameENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/DungeonBoss/CriV2"));
            }
            if (_configuration.GameENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/Battle/CriV2"));
            }
            if (_configuration.GameENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Game/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Game/BossBattle/CriV2"));
            }

            // Secret Laboratory
            if (_configuration.LabENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/Entrance/CriV2"));
            }
            if (_configuration.LabENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon1/CriV2"));
            }
            if (_configuration.LabENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon2/CriV2"));
            }
            if (_configuration.LabENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/Dungeon3/CriV2"));
            }
            if (_configuration.LabENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/DungeonBoss/CriV2"));
            }
            if (_configuration.LabENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/Battle/CriV2"));
            }
            if (_configuration.LabENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Lab/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Lab/BossBattle/CriV2"));
            }

            // Heaven
            if (_configuration.HeavenENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Entrance/CriV2"));
            }
            if (_configuration.HeavenENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon1/CriV2"));
            }
            if (_configuration.HeavenENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon2/CriV2"));
            }
            if (_configuration.HeavenENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Dungeon3/CriV2"));
            }
            if (_configuration.HeavenENV_DungeonBoss1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/DungeonBoss1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/DungeonBoss1/CriV2"));
            }
            if (_configuration.HeavenENV_DungeonBoss2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/DungeonBoss2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/DungeonBoss2/CriV2"));
            }
            if (_configuration.HeavenENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/Battle/CriV2"));
            }
            if (_configuration.HeavenENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/BossBattle/CriV2"));
            }
            if (_configuration.HeavenENV_SuperbossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Heaven/SuperbossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Heaven/SuperbossBattle/CriV2"));
            }

            // Magatsu Inaba
            if (_configuration.MagatsuENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Entrance/CriV2"));
            }
            if (_configuration.MagatsuENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon1/CriV2"));
            }
            if (_configuration.MagatsuENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon2/CriV2"));
            }
            if (_configuration.MagatsuENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Dungeon3/CriV2"));
            }
            if (_configuration.MagatsuENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/DungeonBoss/CriV2"));
            }
            if (_configuration.MagatsuENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/Battle/CriV2"));
            }
            if (_configuration.MagatsuENV_BossBattle1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/BossBattle1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/BossBattle1/CriV2"));
            }
            if (_configuration.MagatsuENV_BossBattle2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/BossBattle2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Magatsu/BossBattle2/CriV2"));
            }

            // Yomotsu Hirasaka
            if (_configuration.YomotsuENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Entrance/CriV2"));
            }
            if (_configuration.YomotsuENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon1/CriV2"));
            }
            if (_configuration.YomotsuENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon2/CriV2"));
            }
            if (_configuration.YomotsuENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Dungeon3/CriV2"));
            }
            if (_configuration.YomotsuENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/DungeonBoss/CriV2"));
            }
            if (_configuration.YomotsuENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/Battle/CriV2"));
            }
            if (_configuration.YomotsuENV_BossBattle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/BossBattle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Yomotsu/BossBattle/CriV2"));
            }

            // Hollow Forest
            if (_configuration.HollowENV_Entrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Entrance/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Entrance/CriV2"));
            }
            if (_configuration.HollowENV_Dungeon1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon1/CriV2"));
            }
            if (_configuration.HollowENV_Dungeon2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon2/CriV2"));
            }
            if (_configuration.HollowENV_Dungeon3 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon3/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Dungeon3/CriV2"));
            }
            if (_configuration.HollowENV_DungeonBoss == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/DungeonBoss/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/DungeonBoss/CriV2"));
            }
            if (_configuration.HollowENV_Battle == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Battle/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Battle/CriV2"));
            }
            if (_configuration.HollowENV_BossBattle1 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/BossBattle1/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/BossBattle1/CriV2"));
            }
            if (_configuration.HollowENV_BossBattle2 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/BossBattle2/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/BossBattle2/CriV2"));
            }
            if (_configuration.HollowENV_Skybox == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Skybox/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Dungeons/Hollow/Skybox/CriV2"));
            }

            // ==================
            // ==================
            // ENVs - Inaba
            // ==================
            // ==================

            // Town Map
            if (_configuration.TownMapENV_SunnyDay == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_SunnyDusk == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_Cloudy == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_Rain == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_Storm == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_Fog == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_WinterSnow == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/TownMap/CriV2"));
            }
            if (_configuration.TownMapENV_WinterCloudy == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/TownMap/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/TownMap/CriV2"));
            }
            if (_configuration.Texture_TownMap == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/TownMap/CriV2"));
            }

            // Yasogami High
            if (_configuration.YasogamiENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/001/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/001/CriV2"));
            }
            if (_configuration.Texture_Yasogami_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/001/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/006/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/006/CriV2"));
            }
            if (_configuration.Texture_Yasogami_006 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/006/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/007/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/007/CriV2"));
            }
            if (_configuration.Texture_Yasogami_007 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/007/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/008/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/008/CriV2"));
            }
            if (_configuration.Texture_Yasogami_008 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/008/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/009/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/009/CriV2"));
            }
            if (_configuration.Texture_Yasogami_009 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/009/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/010/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_010 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/010/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/010/CriV2"));
            }
            if (_configuration.Texture_Yasogami_010 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/010/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/011/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/011/CriV2"));
            }
            if (_configuration.Texture_Yasogami_011 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/011/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/012/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_012 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/012/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/012/CriV2"));
            }
            if (_configuration.Texture_Yasogami_012 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/012/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/013/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_013 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/013/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/013/CriV2"));
            }
            if (_configuration.Texture_Yasogami_013 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/013/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/014/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_014 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/014/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/014/CriV2"));
            }
            if (_configuration.Texture_Yasogami_014 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/014/CriV2"));
            }


            if (_configuration.YasogamiENV_SunnyDay_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_SunnyDusk_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_Cloudy_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_Rain_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_Storm_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_Fog_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterSnow_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Yasogami/015/CriV2"));
            }
            if (_configuration.YasogamiENV_WinterCloudy_015 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/015/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Yasogami/015/CriV2"));
            }
            if (_configuration.Texture_Yasogami_015 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/015/CriV2"));
            }


            if (_configuration.YasogamiENV_016 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Yasogami/016/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Yasogami/016/CriV2"));
            }
            if (_configuration.Texture_Yasogami_016 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/016/CriV2"));
            }


            if (_configuration.YasogamiENV_017 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Yasogami/017/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Yasogami/017/CriV2"));
            }
            if (_configuration.Texture_Yasogami_017 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Yasogami/017/CriV2"));
            }

            // Dojima Residence
            if (_configuration.DojimaENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_Rain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_Storm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_WinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_WinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/001/CriV2"));
            }
            if ((_configuration.DojimaENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_Dojima == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Dojima/001/CriV2"));
            }
            if ((_configuration.DojimaENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_Dojima == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightRain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightStorm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightFog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/001/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/001/CriV2"));
            }
            if (_configuration.Texture_Dojima_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Dojima/001/CriV2"));
            }


            if (_configuration.DojimaENV_SunnyDay_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_SunnyDusk_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_Cloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_Rain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_Storm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_Fog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_WinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_WinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightClear_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightRain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightStorm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightFog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/002/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/002/CriV2"));
            }
            if (_configuration.Texture_Dojima_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Dojima/002/CriV2"));
            }


            if (_configuration.DojimaENV_SunnyDay_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_SunnyDusk_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_Cloudy_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_Rain_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_Storm_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_Fog_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_WinterSnow_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_WinterCloudy_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightClear_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightCloudy_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightRain_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightStorm_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightFog_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterSnow_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Dojima/003/CriV2"));
            }
            if (_configuration.DojimaENV_NightWinterCloudy_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Dojima/003/CriV2"));
            }
            if (_configuration.Texture_Dojima_003 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Dojima/003/CriV2"));
            }

            // Shopping District
            if (_configuration.ShoppingDistrictENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Rain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Storm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/001/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_ShoppingDistrictNorth == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/001/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_ShoppingDistrictNorth == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightRain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightStorm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightFog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/001/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/001/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_SunnyDay_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_SunnyDusk_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Cloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Rain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Storm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Fog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/002/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_002 == Config.ENVTypeA.P4) && (_configuration.NightSky_ShoppingDistrictSouth == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/002/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_002 == Config.ENVTypeA.P4) && (_configuration.NightSky_ShoppingDistrictSouth == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightRain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightStorm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightFog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/002/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/002/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/004/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_004 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/004/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_005 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/005/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/005/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_005 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/005/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_006 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/006/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/006/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_006 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/006/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_011 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/011/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/011/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_007 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/007/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/007/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_007 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/007/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_008 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/008/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/ShoppingDistrict/008/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_008 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/008/CriV2"));
            }


            if (_configuration.ShoppingDistrictENV_SunnyDay_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_SunnyDusk_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Cloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Rain_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Storm_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_Fog_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterSnow_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_WinterCloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/ShoppingDistrict/009/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_009 == Config.ENVTypeA.P4) && (_configuration.NightSky_Shrine == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/ShoppingDistrict/009/CriV2"));
            }
            if ((_configuration.ShoppingDistrictENV_NightClear_009 == Config.ENVTypeA.P4) && (_configuration.NightSky_Shrine == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightCloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightRain_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightStorm_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightFog_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterSnow_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.ShoppingDistrictENV_NightWinterCloudy_009 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/009/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/ShoppingDistrict/009/CriV2"));
            }
            if (_configuration.Texture_ShoppingDistrict_009 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/ShoppingDistrict/009/CriV2"));
            }

            // Junes
            if (_configuration.JunesENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Junes/001/PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_Rain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_Storm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_WinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Junes/001/CriV2"));
            }
            if (_configuration.JunesENV_WinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Junes/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Junes/001/CriV2"));
            }
            if (_configuration.Texture_Junes_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Junes/001/CriV2"));
            }


            if (_configuration.JunesENV_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Junes/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Junes/002/CriV2"));
            }
            if (_configuration.Texture_Junes_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Junes/002/CriV2"));
            }


            if (_configuration.JunesENV_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Junes/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Junes/003/CriV2"));
            }
            if (_configuration.Texture_Junes_003 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Junes/003/CriV2"));
            }


            if (_configuration.JunesENV_SunnyDay_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_SunnyDusk_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_Cloudy_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_Rain_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_Storm_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_Fog_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_WinterSnow_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Junes/004/CriV2"));
            }
            if (_configuration.JunesENV_WinterCloudy_004 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Junes/004/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Junes/004/CriV2"));
            }
            if (_configuration.Texture_Junes_004 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Junes/004/CriV2"));
            }

            // Samegawa Floodplain
            if (_configuration.SamegawaENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_Rain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_Storm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_WinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_WinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Samegawa/001/CriV2"));
            }
            if ((_configuration.SamegawaENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_Samegawa == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Samegawa/001/CriV2"));
            }
            if ((_configuration.SamegawaENV_NightClear_001 == Config.ENVTypeA.P4) && (_configuration.NightSky_Samegawa == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightRain_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightStorm_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightFog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightWinterSnow_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Samegawa/001/CriV2"));
            }
            if (_configuration.SamegawaENV_NightWinterCloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Samegawa/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Samegawa/001/CriV2"));
            }
            if (_configuration.Texture_Samegawa_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Samegawa/001/CriV2"));
            }


            if (_configuration.SamegawaENV_SunnyDay_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_SunnyDusk_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_Cloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_Rain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_Storm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_Fog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_WinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_WinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightClear_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightRain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightStorm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightFog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightWinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Samegawa/002/CriV2"));
            }
            if (_configuration.SamegawaENV_NightWinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Samegawa/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Samegawa/002/CriV2"));
            }
            if (_configuration.Texture_Samegawa_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Samegawa/002/CriV2"));
            }

            // Okina City
            if (_configuration.OkinaENV_SunnyDay_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Okina/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Okina/001/CriV2"));
            }
            if (_configuration.OkinaENV_SunnyDusk_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Okina/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Okina/001/CriV2"));
            }
            if (_configuration.OkinaENV_Cloudy_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Okina/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Okina/001/CriV2"));
            }
            if (_configuration.OkinaENV_Fog_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Okina/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Okina/001/CriV2"));
            }
            if (_configuration.OkinaENV_Winter_001 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Okina/001/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Okina/001/CriV2"));
            }
            if (_configuration.Texture_Okina_001 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Okina/001/CriV2"));
            }


            if (_configuration.OkinaENV_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Okina/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Okina/002/CriV2"));
            }
            if (_configuration.Texture_Okina_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Okina/002/CriV2"));
            }

            // Inaba Municipal Hospital
            if (_configuration.HospitalENV_SunnyDay_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_SunnyDusk_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_Cloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_Rain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_Storm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_Fog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_WinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_WinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Hospital/002/CriV2"));
            }
            if ((_configuration.HospitalENV_NightClear_002 == Config.ENVTypeA.P4) && (_configuration.NightSky_Hospital == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Hospital/002/CriV2"));
            }
            if ((_configuration.HospitalENV_NightClear_002 == Config.ENVTypeA.P4) && (_configuration.NightSky_Hospital == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightRain_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightStorm_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightFog_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightWinterSnow_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Hospital/002/CriV2"));
            }
            if (_configuration.HospitalENV_NightWinterCloudy_002 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Hospital/002/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Hospital/002/CriV2"));
            }
            if (_configuration.Texture_Hospital_002 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Hospital/002/CriV2"));
            }


            if (_configuration.HospitalENV_003 == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Hospital/003/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Hospital/003/CriV2"));
            }
            if (_configuration.Texture_Hospital_003 == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Hospital/003/CriV2"));
            }

            // Miscellaneous
            if (_configuration.MiscENV_Shu == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Shu/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Shu/CriV2"));
            }
            if (_configuration.Texture_Misc_Shu == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/Shu/CriV2"));
            }


            if (_configuration.MiscENV_Namatame == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Namatame/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Namatame/CriV2"));
            }
            if (_configuration.Texture_Misc_Namatame == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/Namatame/CriV2"));
            }


            if (_configuration.MiscENV_SunnyDay_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_SunnyDusk_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_Cloudy_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_Rain_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_Storm_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_Fog_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_WinterSnow_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/Hill/CriV2"));
            }
            if (_configuration.MiscENV_WinterCloudy_Hill == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/Hill/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/Hill/CriV2"));
            }
            if (_configuration.Texture_Misc_Hill == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/Hill/CriV2"));
            }


            if (_configuration.MiscENV_PoliceInterrogation == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/PoliceInterrogation/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/PoliceInterrogation/CriV2"));
            }
            if (_configuration.Texture_Misc_PoliceInterrogation == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/PoliceInterrogation/CriV2"));
            }
            if (_configuration.MiscENV_PoliceHallway == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/PoliceHallway/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/PoliceHallway/CriV2"));
            }
            if (_configuration.Texture_Misc_PoliceHallway == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/PoliceHallway/CriV2"));
            }


            if (_configuration.MiscENV_CampingOutside == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingOutside/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingOutside/CriV2"));
            }
            if (_configuration.Texture_Misc_CampingOutside == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/CampingOutside/CriV2"));
            }
            if (_configuration.MiscENV_CampingTent == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingTent/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingTent/CriV2"));
            }
            if (_configuration.Texture_Misc_CampingTent == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/CampingTent/CriV2"));
            }
            if (_configuration.MiscENV_CampingWaterfall == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingWaterfall/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/CampingWaterfall/CriV2"));
            }
            if (_configuration.Texture_Misc_CampingWaterfall == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/CampingWaterfall/CriV2"));
            }


            if (_configuration.MiscENV_GekkouEntrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/GekkouEntrance/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/GekkouEntrance/CriV2"));
            }
            if (_configuration.Texture_Misc_GekkouEntrance == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/GekkouEntrance/CriV2"));
            }
            if (_configuration.MiscENV_GekkouClassroom == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/GekkouClassroom/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/GekkouClassroom/CriV2"));
            }
            if (_configuration.Texture_Misc_GekkouClassroom == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/GekkouClassroom/CriV2"));
            }
            if (_configuration.MiscENV_LoveHotel == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/LoveHotel/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/LoveHotel/CriV2"));
            }
            if (_configuration.Texture_Misc_LoveHotel == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/LoveHotel/CriV2"));
            }
            if (_configuration.MiscENV_ClubEscapade == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/ClubEscapade/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/ClubEscapade/CriV2"));
            }
            if (_configuration.Texture_Misc_ClubEscapade == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/ClubEscapade/CriV2"));
            }
            if (_configuration.MiscENV_Iwatodai == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Iwatodai/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/Iwatodai/CriV2"));
            }
            if (_configuration.Texture_Misc_Iwatodai == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/Iwatodai/CriV2"));
            }


            if (_configuration.MiscENV_SunnyDay_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_SunnyDusk_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_Cloudy_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_Rain_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_Storm_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_Fog_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_WinterSnow_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_WinterCloudy_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/SchoolZone/CriV2"));
            }
            if ((_configuration.MiscENV_NightClear_SchoolZone == Config.ENVTypeA.P4) && (_configuration.NightSky_SchoolZone == true))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClearSkybox/Misc/SchoolZone/CriV2"));
            }
            if ((_configuration.MiscENV_NightClear_SchoolZone == Config.ENVTypeA.P4) && (_configuration.NightSky_SchoolZone == false))
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightClear/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightClear/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightCloudy_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightCloudy/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightRain_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightRain/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightRain/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightStorm_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightStorm/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightFog_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightFog/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightFog/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightWinterSnow_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterSnow/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.MiscENV_NightWinterCloudy_SchoolZone == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Misc/SchoolZone/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/NightWinterCloudy/Misc/SchoolZone/CriV2"));
            }
            if (_configuration.Texture_Misc_SchoolZone == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/SchoolZone/CriV2"));
            }


            if (_configuration.MiscENV_SunnyDay_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDay/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_SunnyDusk_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/SunnyDusk/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_Cloudy_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Cloudy/Misc/Train/CriV2"));
            }
            //if (_configuration.MiscENV_Rain_Train == Config.ENVTypeA.P4)
            //{
            //    _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/Train/PAK"));
            //    // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Rain/Misc/Train/CriV2"));
            //}
            if (_configuration.MiscENV_Storm_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Storm/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_Fog_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Fog/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_WinterSnow_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterSnow/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_WinterCloudy_Train == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/Train/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/WinterCloudy/Misc/Train/CriV2"));
            }
            if (_configuration.Texture_Misc_Train == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/Train/CriV2"));
            }
            if (_configuration.MiscENV_ScooterRides == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/ScooterRides/PAK"));
                // criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/All/Misc/ScooterRides/CriV2"));
            }


            if (_configuration.MiscENV_AmagiRoom == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/AmagiRoom/PAK"));
            }
            if (_configuration.MiscENV_AmagiEntrance == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/AmagiEntrance/PAK"));
            }
            if (_configuration.MiscENV_AmagiHotSprings == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs/Inaba/All/Misc/AmagiHotSprings/PAK"));
            }
            if (_configuration.Texture_Misc_AmagiRoom == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/AmagiRoom/CriV2"));
            }
            if (_configuration.Texture_Misc_AmagiEntrance == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/AmagiEntrance/CriV2"));
            }
            if (_configuration.Texture_Misc_AmagiHotSprings == true)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs/Inaba/Textures/Misc/AmagiHotSprings/CriV2"));
            }



            // ==================
            // ==================
            // Field imports
            // ==================
            // ==================

            // thanks max

            if (_configuration.PowerLinesTwitterLoves)
			{
				criFsApi.AddProbingPath(Path.Combine(modDir, "Field", "TwitterPowerLine"));
            }



            // ==================
            // ==================
            // Event ENV toggles
            // ==================
            // ==================

            if (_configuration.Event_E105_001)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "Event", "E105_001"));
            }
            if (_configuration.Event_E124_003)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "Event", "E124_003"));
            }
            if (_configuration.Event_FoggyStreet)
            {
                criFsApi.AddProbingPath(Path.Combine(modDir, "Event", "E182_002"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "Event", "E219_001"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "Event", "E311_001"));
            }



            // ==================
            // ==================
            // Night Skyboxes
            // ==================
            // ==================
        }     

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}