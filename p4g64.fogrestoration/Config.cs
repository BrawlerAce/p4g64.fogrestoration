using p4g64.fogrestoration.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

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
            P4,
            Stock,
        }

        // [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStockDesaturated: Uses the stock P4G ENV with almost no changes, but reduces the saturation to 1.00.\nStock: Uses the stock P4G ENV with no changes.")]

        // 2 options for textures
        public enum TexTypeA
        {
            P4,
            Stock,
        }

        [Category("Misc")]
        [DisplayName("Debug Mode")]
        [Description("If enabled, causes additional information that may be useful for debugging to be logged.")]
        [DefaultValue(false)]
        public bool DebugEnabled { get; set; } = false;


        // ENV Selection - Inaba

        [Category("ENV Selection - Inaba")]
        //[DisplayName("Samegawa Floodplain")]
        [DisplayName("Inaba - WIP")]
        //[Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [Description("WARNING: WIP! SOME AREAS MAY APPEAR BROKEN!\n\nSelect what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA SamegawaENV { get; set; } = ENVTypeA.P4;

        // ENV Selection - Dungeons

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Konishi Liquors")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA KonishiENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Twisted Shopping District")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA TwistedENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Hollow Forest (P4G)")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA HollowENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Yomotsu Hirasaka")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA YomotsuENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Magatsu Inaba")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA MagatsuENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Heaven")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock : Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA HeavenENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Secret Laboratory")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA LabENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Void Quest")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA GameENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Marukyu Striptease")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA ClubENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Steamy Bathhouse")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA SaunaENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("Yukiko's Castle")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA CastleENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - Dungeons")]
        [DisplayName("???")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA DreamENV { get; set; } = ENVTypeA.P4;

        // ENV Selection - TV World

        [Category("ENV Selection - TV World")]
        [DisplayName("Desolate Bedroom")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA BedroomENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - TV World")]
        [DisplayName("Velvet Room")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA VelvetENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - TV World")]
        [DisplayName("Entrance")]
        [Description("Select what ENV to use for this area.\n\nP4: Uses an overhauled P4 ENV, or a P4 inspired ENV for P4G exclusive fields.\nStock: Uses the stock P4G ENV with no changes.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA EntranceENV { get; set; } = ENVTypeA.P4;

        // Texture Selection

        [Category("Texture Selection")]
        [DisplayName("TV Static")]
        [Description("Select whether to apply P4-style TV static or not.\n\nP4: Uses the P4-style TV static.\nStock: Uses the stock P4G TV static. Select this if using No TV Static 64.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA StaticENV { get; set; } = TexTypeA.P4;

        [Category("Texture Selection")]
        [DisplayName("Fog Textures")]
        [Description("Select whether to apply P4-style fog or use the more \"stringy\" fog texture from P4G.\n\nP4: Uses the P4-style fog.\nStock: Uses the stock P4G fog.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA FogENV { get; set; } = TexTypeA.P4;

        // Field Selection, I no no wanna figure out how you did this so enjoy my commit being very different from your system

		[DisplayName("Powerline Fields")]
		[Category("Fields?")]
		[Description("True")]
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