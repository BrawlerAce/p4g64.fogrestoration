using p4g64.fogrestoration.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace p4g64.fogrestoration.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
    
            By default, configuration saves as "Config.json" in mod user config folder.    
            Need more config files/classes? See Configuration.cs
    
            Available Attributes:
            - Category
            - DisplayName
            - Description
            - DefaultValue

            // Technically Supported but not Useful
            - Browsable
            - Localizable

            The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
        */

        // 2 options for ENVs
        public enum ENVTypeA
        {
            [Display(Name = "P4 Fog Restoration")]
            P4,
            [Display(Name = "Stock P4G")]
            Stock,
        }

        // [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStockDesaturated: Uses the stock P4G ENV with almost no changes, but reduces the saturation to 1.00.\nStock: Uses the stock P4G ENV with no changes.")]

        // 2 options for textures
        public enum TexTypeA
        {
            [Display(Name = "P4 Fog Restoration")]
            P4,
            [Display(Name = "Stock P4G")]
            Stock,
        }

        [Category("Misc")]
        [Display(Order = 0)]
        [DisplayName("Debug Mode")]
        [Description("If enabled, causes additional information that may be useful for debugging to be logged.")]
        [DefaultValue(false)]
        public bool DebugEnabled { get; set; } = false;

        // Misc Texture Selection

        [Category("Texture Selection")]
        [Display(Order = 1)]
        [DisplayName("TV Static")]
        [Description("Select whether to apply P4-style TV static or not.\n\nP4: Uses the P4-style TV static.\nStock: Uses the stock P4G TV static. Select this if using No TV Static 64.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA StaticENV { get; set; } = TexTypeA.P4;

        [Category("Texture Selection")]
        [Display(Order = 2)]
        [DisplayName("Fog Textures")]
        [Description("Select whether to apply P4-style fog or use the more \"stringy\" fog texture from P4G.\n\nP4: Uses the P4-style fog.\nStock: Uses the stock P4G fog.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA FogENV { get; set; } = TexTypeA.P4;


        // ENV Selection - Inaba

        [Category("ENV Selection - Inaba")]
        [Display(Order = 3)]
        [DisplayName("Town Map")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA TownMapENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 4)]
        [DisplayName("Yasogami High")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA YasogamiENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 5)]
        [DisplayName("Dojima Residence")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA DojimaENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 6)]
        [DisplayName("Shopping District")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA ShoppingDistrictENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 7)]
        [DisplayName("Samegawa Floodplain")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA SamegawaENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 8)]
        [DisplayName("Junes Department Store")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA JunesENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 9)]
        [DisplayName("Okina City")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA OkinaENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Inaba")]
        [Display(Order = 10)]
        [DisplayName("Miscellaneous")]
        [Description("Select what visuals to use for areas like the hospital, police station, etc.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA MiscENV { get; set; } = ENVTypeA.P4;

        // ENV Selection - TV World

        [Category("ENV Selection - TV World")]
        [Display(Order = 11)]
        [DisplayName("Velvet Room")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA VelvetENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - TV World")]
        [Display(Order = 12)]
        [DisplayName("Entrance")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA EntranceENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - TV World")]
        [Display(Order = 13)]
        [DisplayName("Desolate Bedroom")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA BedroomENV { get; set; } = ENVTypeA.P4;

        // ENV Selection - Dungeons

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 14)]
        [DisplayName("???")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA DreamENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 14)]
        [DisplayName("Twisted Shopping District")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA TwistedENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 15)]
        [DisplayName("Konishi Liquors")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA KonishiENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 16)]
        [DisplayName("Yukiko's Castle")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA CastleENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 17)]
        [DisplayName("Steamy Bathhouse")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA SaunaENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 18)]
        [DisplayName("Marukyu Striptease")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA ClubENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 19)]
        [DisplayName("Void Quest")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA GameENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 20)]
        [DisplayName("Secret Laboratory")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA LabENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 21)]
        [DisplayName("Heaven")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA HeavenENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 22)]
        [DisplayName("Magatsu Inaba")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA MagatsuENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 23)]
        [DisplayName("Yomotsu Hirasaka")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA YomotsuENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [Display(Order = 24)]
        [DisplayName("Hollow Forest (P4G)")]
        [Description("Select what visuals to use for this area.\n\nNOTE: Since the Hollow Forest is P4G exclusive, if \"P4 Visuals\" is selected, the\nvisuals will have slightly reduced contrast to fit better with the other fields in this mod.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA HollowENV { get; set; } = ENVTypeA.P4;

        // Field Selection, I no no wanna figure out how you did this so enjoy my commit being very different from your system

        [Category("Fields Imports and Other Models")]
        [Display(Order = 25)]
        [DisplayName("Power Lines")]
		[Description("Adds power line models to fields that had them in P4 but not P4G. yeah")]
		[DefaultValue(true)]
		public bool PowerLinesTwitterLoves { get; set; } = true;
	}
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
}
