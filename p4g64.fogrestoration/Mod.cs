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
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "TVWorld", "Entrance", "CriV2"));
            }

            // Velvet Room
            if (_configuration.VelvetENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "TVWorld", "Velvet", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "TVWorld", "Velvet", "CriV2"));
            }

            // Desolate Bedroom (and surrounding areas)
            if (_configuration.BedroomENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "TVWorld", "Bedroom", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "TVWorld", "Bedroom", "CriV2"));
            }

            // ==================
            // ==================
            // ENVs - Dungeons
            // ==================
            // ==================

            // ???
            if (_configuration.DreamENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Foggy", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Foggy", "CriV2"));
            }

            // Yukiko's Castle
            if (_configuration.CastleENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Castle", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Castle", "CriV2"));
            }

            // Steamy Bathhouse
            if (_configuration.SaunaENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Sauna", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Sauna", "CriV2"));
            }

            // Marukyu Striptease
            if (_configuration.ClubENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Club", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Club", "CriV2"));
            }

            // Void Quest
            if (_configuration.GameENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Game", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Game", "CriV2"));
            }

            // Secret Laboratory
            if (_configuration.LabENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Lab", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Lab", "CriV2"));
            }

            // Heaven
            if (_configuration.HeavenENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Heaven", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Heaven", "CriV2"));
            }

            // Magatsu Inaba
            if (_configuration.MagatsuENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Magatsu", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Magatsu", "CriV2"));
            }

            // Yomotsu Hirasaka
            if (_configuration.YomotsuENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Yomotsu", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Yomotsu", "CriV2"));
            }

            // Hollow Forest
            if (_configuration.HollowENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Hollow", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Hollow", "CriV2"));
            }

            // Twisted Shopping District
            if (_configuration.TwistedENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Twisted", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Twisted", "CriV2"));
            }

            // Konishi Liquors
            if (_configuration.KonishiENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Dungeons", "Konishi", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Dungeons", "Konishi", "CriV2"));
            }

            // ==================
            // ==================
            // ENVs - Inaba
            // ==================
            // ==================

            // Dojima Residence
            if (_configuration.DojimaENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "DojimaResidence", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "DojimaResidence", "CriV2"));
            }

            // Samegawa Floodplain
            if (_configuration.SamegawaENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "Floodplain", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "Floodplain", "CriV2"));
            }

            // Junes
            if (_configuration.JunesENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "Junes", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "Junes", "CriV2"));
            }

            // Misc
            if (_configuration.MiscENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "Misc", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "Misc", "CriV2"));
            }

            // Shopping District
            if (_configuration.ShoppingDistrictENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "ShoppingDistrict", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "ShoppingDistrict", "CriV2"));
            }

            // Town Map
            if (_configuration.TownMapENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "TownMap", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "TownMap", "CriV2"));
            }

            // Yasogami High
            if (_configuration.YasogamiENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "Yasogami", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "Yasogami", "CriV2"));
            }

            // Okina City
            if (_configuration.OkinaENV == Config.ENVTypeA.P4)
            {
                _PakEmulator.AddDirectory(Path.Combine(modDir, "ENVs", "Inaba", "Okina", "PAK"));
                criFsApi.AddProbingPath(Path.Combine(modDir, "ENVs", "Inaba", "Okina", "IWantToCri"));
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