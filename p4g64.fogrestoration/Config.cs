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


        // ENV Selection - Town Map

            [Category("ENV Selection - Town Map")]
            [Display(Order = 1)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_SunnyDay { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 2)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_SunnyDusk { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 3)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_Cloudy { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 4)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_Rain { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 5)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_Storm { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 6)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_Fog { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 7)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_WinterSnow { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Town Map")]
            [Display(Order = 8)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TownMapENV_WinterCloudy { get; set; } = ENVTypeA.P4;

        // ENV Selection - Yasogami High

            //// Classroom/Practice Building

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 9)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 10)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 11)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 12)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 13)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 14)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 15)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom/Practice Building")]
            [Display(Order = 16)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_001 { get; set; } = ENVTypeA.P4;

            //// Classroom 2-2

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 17)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 18)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 19)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 20)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 21)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 22)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 23)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_006 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Classroom 2-2")]
            [Display(Order = 24)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_006 { get; set; } = ENVTypeA.P4;

            //// Music Room

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 25)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 26)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 27)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 28)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 29)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 30)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 31)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_007 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Music Room")]
            [Display(Order = 32)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_007 { get; set; } = ENVTypeA.P4;

            //// Drama Room

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 33)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 34)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 35)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 36)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 37)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 38)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 39)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_008 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Drama Room")]
            [Display(Order = 40)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_008 { get; set; } = ENVTypeA.P4;

            //// P.E. Field

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 41)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 42)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 43)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 44)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 45)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 46)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 47)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, P.E. Field")]
            [Display(Order = 48)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_009 { get; set; } = ENVTypeA.P4;

            //// Basketball Court

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 49)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 50)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 51)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 52)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 53)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 54)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 55)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_010 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Basketball Court")]
            [Display(Order = 56)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_010 { get; set; } = ENVTypeA.P4;

            //// Faculty Office

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 57)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 58)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 59)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 60)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 61)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 62)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 63)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_011 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Faculty Office")]
            [Display(Order = 64)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_011 { get; set; } = ENVTypeA.P4;

            //// Nurse's Office

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 65)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 66)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 67)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 68)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 69)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 70)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 71)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_012 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Nurse's Office")]
            [Display(Order = 72)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_012 { get; set; } = ENVTypeA.P4;

            //// Library

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 73)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 74)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 75)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 76)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 77)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 78)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 79)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_013 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Library")]
            [Display(Order = 80)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_013 { get; set; } = ENVTypeA.P4;

            //// Rooftop

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 81)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 82)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 83)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 84)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 85)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 86)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 87)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_014 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, Rooftop")]
            [Display(Order = 88)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_014 { get; set; } = ENVTypeA.P4;

            //// School Entrance

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 89)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDay_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 90)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_SunnyDusk_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 91)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Cloudy_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 92)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Rain_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 93)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Storm_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 94)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_Fog_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 95)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterSnow_015 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Yasogami High, School Entrance")]
            [Display(Order = 96)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_WinterCloudy_015 { get; set; } = ENVTypeA.P4;

            //// Group Date Cafe
            
            [Category("ENV Selection - Yasogami High, Group Date Cafe")]
            [Display(Order = 97)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_016 { get; set; } = ENVTypeA.P4;

            //// School Festival 2F
            
            [Category("ENV Selection - Yasogami High, School Festival 2F")]
            [Display(Order = 98)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YasogamiENV_017 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Dojima Residence

            //// Outside

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 99)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 100)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 101)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 102)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Rain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 103)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Storm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 104)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 105)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 106)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 107)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightClear_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 108)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 109)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightRain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 110)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightStorm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 111)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightFog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 112)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Outside")]
            [Display(Order = 113)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterCloudy_001 { get; set; } = ENVTypeA.P4;

            //// Living Room

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 114)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDay_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 115)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDusk_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 116)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Cloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 117)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Rain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 118)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Storm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 119)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Fog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 120)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 121)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 122)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightClear_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 123)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 124)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightRain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 125)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightStorm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 126)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightFog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 127)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Living Room")]
            [Display(Order = 128)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterCloudy_002 { get; set; } = ENVTypeA.P4;

            //// Your Room

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 129)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDay_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 130)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_SunnyDusk_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 131)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Cloudy_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 132)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Rain_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 133)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Storm_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 134)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_Fog_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 135)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterSnow_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 136)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_WinterCloudy_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 137)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightClear_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 138)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightCloudy_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 139)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightRain_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 140)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightStorm_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 141)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightFog_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 142)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterSnow_003 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dojima Residence, Your Room")]
            [Display(Order = 143)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DojimaENV_NightWinterCloudy_003 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Shopping District

            //// North

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 144)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 145)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 146)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 147)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Rain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 148)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Storm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 149)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 150)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 151)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 152)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightClear_001 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 153)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 154)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightRain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 155)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightStorm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 156)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightFog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 157)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, North")]
            [Display(Order = 158)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterCloudy_001 { get; set; } = ENVTypeA.P4;

            //// South

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 159)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDay_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 160)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDusk_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 161)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Cloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 162)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Rain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 163)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Storm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 164)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Fog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 165)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 166)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 167)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightClear_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 168)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 169)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightRain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 170)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightStorm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 171)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightFog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 172)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, South")]
            [Display(Order = 173)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterCloudy_002 { get; set; } = ENVTypeA.P4;

            //// Daidara Metalworks

            [Category("ENV Selection - Shopping District, Daidara Metalworks")]
            [Display(Order = 174)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_004 { get; set; } = ENVTypeA.P4;

            //// Chinese Diner Aiya

            [Category("ENV Selection - Shopping District, Chinese Diner Aiya")]
            [Display(Order = 175)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_005 { get; set; } = ENVTypeA.P4;

            //// Shiroku Store

            [Category("ENV Selection - Shopping District, Shiroku Store")]
            [Display(Order = 176)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_006 { get; set; } = ENVTypeA.P4;

            //// Shiroku Pub

            [Category("ENV Selection - Shopping District, Shiroku Pub")]
            [Display(Order = 177)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_011 { get; set; } = ENVTypeA.P4;

            //// Tatsumi Textiles

            [Category("ENV Selection - Shopping District, Tatsumi Textiles")]
            [Display(Order = 178)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_007 { get; set; } = ENVTypeA.P4;

            //// Marukyu Tofu

            [Category("ENV Selection - Shopping District, Marukyu Tofu")]
            [Display(Order = 179)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_008 { get; set; } = ENVTypeA.P4;

            //// Shrine

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 180)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDay_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 181)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_SunnyDusk_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 182)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Cloudy_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 183)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Rain_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 184)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Storm_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 185)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_Fog_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 186)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterSnow_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 187)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_WinterCloudy_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 188)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightClear_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 189)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightCloudy_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 190)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightRain_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 191)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightStorm_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 192)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightFog_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 193)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterSnow_009 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Shopping District, Shrine")]
            [Display(Order = 194)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ShoppingDistrictENV_NightWinterCloudy_009 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Junes Department Store

        //// Food Court

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 195)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 196)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 197)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 198)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Rain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 199)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Storm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 200)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 201)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_WinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, Food Court")]
            [Display(Order = 202)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_WinterCloudy_001 { get; set; } = ENVTypeA.P4;

            //// Electronics Department

            [Category("ENV Selection - Junes Department Store, Electronics Department")]
            [Display(Order = 203)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_002 { get; set; } = ENVTypeA.P4;

            //// Produce Department

            [Category("ENV Selection - Junes Department Store, Produce Department")]
            [Display(Order = 204)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_003 { get; set; } = ENVTypeA.P4;

            //// West Entrance

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 205)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_SunnyDay_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 206)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_SunnyDusk_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 207)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Cloudy_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 208)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Rain_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 209)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Storm_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 210)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_Fog_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 211)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_WinterSnow_004 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Junes Department Store, West Entrance")]
            [Display(Order = 212)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA JunesENV_WinterCloudy_004 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Samegawa Floodplain

            //// Floodplain

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 213)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 214)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 215)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 216)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Rain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 217)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Storm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 218)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 219)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_WinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 220)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_WinterCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 221)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightClear_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 222)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightCloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 223)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightRain_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 224)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightStorm_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 225)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightFog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 226)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightWinterSnow_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Floodplain")]
            [Display(Order = 227)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightWinterCloudy_001 { get; set; } = ENVTypeA.P4;

            //// Riverbank

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 228)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_SunnyDay_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 229)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_SunnyDusk_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 230)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Cloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 231)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Rain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 232)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Storm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 233)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_Fog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 234)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_WinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 235)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_WinterCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 236)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightClear_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 237)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 238)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightRain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 239)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightStorm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 240)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightFog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 241)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightWinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Samegawa Floodplain, Riverbank")]
            [Display(Order = 242)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SamegawaENV_NightWinterCloudy_002 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Okina City

            //// Outside

            [Category("ENV Selection - Okina City, Outside")]
            [Display(Order = 243)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_SunnyDay_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Okina City, Outside")]
            [Display(Order = 244)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_SunnyDusk_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Okina City, Outside")]
            [Display(Order = 245)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_Cloudy_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Okina City, Outside")]
            [Display(Order = 246)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_Fog_001 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Okina City, Outside")]
            [Display(Order = 247)]
            [DisplayName("Winter")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_Winter_001 { get; set; } = ENVTypeA.P4;

            //// Croco Fur

            [Category("ENV Selection - Okina City, Croco Fur")]
            [Display(Order = 248)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA OkinaENV_002 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Inaba Municipal Hospital

            //// Hallway

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 249)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_SunnyDay_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 250)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_SunnyDusk_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 251)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_Cloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 251)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_Rain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 252)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_Storm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 253)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_Fog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 254)]
            [DisplayName("Winter")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_WinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 255)]
            [DisplayName("Winter")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_WinterCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 256)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightClear_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 257)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightCloudy_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 258)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightRain_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 259)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightStorm_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 260)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightFog_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 261)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightWinterSnow_002 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Inaba Municipal Hospital, Hallway")]
            [Display(Order = 262)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_NightWinterCloudy_002 { get; set; } = ENVTypeA.P4;

            //// Patient Room

            [Category("ENV Selection - Inaba Municipal Hospital, Patient Room")]
            [Display(Order = 263)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_003 { get; set; } = ENVTypeA.P4;

            //// Patient Room

            [Category("ENV Selection - Inaba Municipal Hospital, Patient Room (Top Floor)")]
            [Display(Order = 264)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HospitalENV_004 { get; set; } = ENVTypeA.P4;

        // ENV Selection - Miscellaneous

            //// Shu's Room

            [Category("ENV Selection - Miscellaneous - Shu's Room")]
            [Display(Order = 265)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Shu { get; set; } = ENVTypeA.P4;

            //// Namatame's Room

            [Category("ENV Selection - Miscellaneous - Namatame's Room")]
            [Display(Order = 266)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Namatame { get; set; } = ENVTypeA.P4;

            //// Hill Overlooking Inaba

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 267)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDay_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 268)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDusk_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 269)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Cloudy_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 270)]
            [DisplayName("Rainy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Rain_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 271)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Storm_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 272)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Fog_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 273)]
            [DisplayName("Winter (Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterSnow_Hill { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Hill Overlooking Inaba")]
            [Display(Order = 274)]
            [DisplayName("Winter (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterCloudy_Hill { get; set; } = ENVTypeA.P4;

            //// Police Station (Interrogation Room)

            [Category("ENV Selection - Miscellaneous - Police Station, Interrogation Room")]
            [Display(Order = 275)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_PoliceInterrogation { get; set; } = ENVTypeA.P4;

            //// Police Station (Hallway)

            [Category("ENV Selection - Miscellaneous - Police Station, Hallway")]
            [Display(Order = 276)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_PoliceHallway { get; set; } = ENVTypeA.P4;

            //// Camping Trip (Outside)

            [Category("ENV Selection - Miscellaneous - Camping Trip, Outside")]
            [Display(Order = 277)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_CampingOutside { get; set; } = ENVTypeA.P4;

            //// Camping Trip (Tent)

            [Category("ENV Selection - Miscellaneous - Camping Trip, Tent")]
            [Display(Order = 278)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_CampingTent { get; set; } = ENVTypeA.P4;

            //// Camping Trip (Waterfall)

            [Category("ENV Selection - Miscellaneous - Camping Trip, Waterfall")]
            [Display(Order = 279)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_CampingWaterfall { get; set; } = ENVTypeA.P4;

            //// Gekkoukan High (Entrance)

            [Category("ENV Selection - Miscellaneous - Gekkoukan High, Entrance")]
            [Display(Order = 280)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_GekkouEntrance { get; set; } = ENVTypeA.P4;

            //// Gekkoukan High (Classroom)

            [Category("ENV Selection - Miscellaneous - Gekkoukan High, Classroom")]
            [Display(Order = 281)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_GekkouClassroom { get; set; } = ENVTypeA.P4;

            //// Love Hotel

            [Category("ENV Selection - Miscellaneous - Love Hotel")]
            [Display(Order = 282)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_LoveHotel { get; set; } = ENVTypeA.P4;

            //// Club Escapade

            [Category("ENV Selection - Miscellaneous - Club Escapade")]
            [Display(Order = 283)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_ClubEscapade { get; set; } = ENVTypeA.P4;

            //// Iwatodai (Beef Bowl Shop)

            [Category("ENV Selection - Miscellaneous - Iwatodai Station, Beef Bowl Shop")]
            [Display(Order = 284)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Iwatodai { get; set; } = ENVTypeA.P4;

            //// School Zone

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 285)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDay_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 286)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDusk_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 287)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Cloudy_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 288)]
            [DisplayName("Rain")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Rain_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 289)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Storm_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 290)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Fog_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 291)]
            [DisplayName("Winter - Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterSnow_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 292)]
            [DisplayName("Winter - Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterCloudy_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 293)]
            [DisplayName("Night (Clear)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightClear_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 294)]
            [DisplayName("Night (Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightCloudy_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 295)]
            [DisplayName("Night (Rainy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightRain_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 296)]
            [DisplayName("Night (Stormy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightStorm_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 297)]
            [DisplayName("Night (Foggy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightFog_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 298)]
            [DisplayName("Night (Winter - Snowy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightWinterSnow_SchoolZone { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - School Zone")]
            [Display(Order = 299)]
            [DisplayName("Night (Winter - Cloudy)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_NightWinterCloudy_SchoolZone { get; set; } = ENVTypeA.P4;

            //// Train Station

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 300)]
            [DisplayName("Sunny (Day)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDay_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 301)]
            [DisplayName("Sunny (Dusk)")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_SunnyDusk_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 302)]
            [DisplayName("Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Cloudy_Train { get; set; } = ENVTypeA.P4;

            //[Category("ENV Selection - Miscellaneous - Train Station")]
            //[Display(Order = 303)]
            //[DisplayName("Rainy")]
            //[Description("Select what visuals to use for this area with this weather.")]
            //[DefaultValue(ENVTypeA.P4)]
            //public ENVTypeA MiscENV_Rain_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 304)]
            [DisplayName("Stormy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Storm_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 305)]
            [DisplayName("Foggy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_Fog_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 306)]
            [DisplayName("Winter Snowy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterSnow_Train { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Train Station")]
            [Display(Order = 307)]
            [DisplayName("Winter Cloudy")]
            [Description("Select what visuals to use for this area with this weather.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_WinterCloudy_Train { get; set; } = ENVTypeA.P4;

            // Amagi Inn

            [Category("ENV Selection - Miscellaneous - Amagi Inn, Room")]
            [Display(Order = 308)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_AmagiRoom { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Amagi Inn, Entrance")]
            [Display(Order = 308)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_AmagiEntrance { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Miscellaneous - Amagi Inn, Hot Springs")]
            [Display(Order = 308)]
            [DisplayName("Visuals")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MiscENV_AmagiHotSprings { get; set; } = ENVTypeA.P4;

        // ENV Selection - TV World

        [Category("ENV Selection - TV World")]
        [Display(Order = 400)]
        [DisplayName("Velvet Room")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA VelvetENV { get; set; } = ENVTypeA.P4;

        [Category("ENV Selection - TV World")]
        [Display(Order = 401)]
        [DisplayName("TV World Entrance")]
        [Description("Select what visuals to use for this area.")]
        [DefaultValue(ENVTypeA.P4)]
        public ENVTypeA EntranceENV { get; set; } = ENVTypeA.P4;

        // ENV Selection - Dungeons

            //// ???

            [Category("ENV Selection - Dungeons - ???")]
            [Display(Order = 402)]
            [DisplayName("Dungeon")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DreamENV_Dungeon1 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - ???")]
            [Display(Order = 403)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA DreamENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Twisted Shopping District

            [Category("ENV Selection - Dungeons - Twisted Shopping District")]
            [Display(Order = 404)]
            [DisplayName("Twisted Shopping District")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TwistedENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Twisted Shopping District")]
            [Display(Order = 405)]
            [DisplayName("Konishi Liquors")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TwistedENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Twisted Shopping District")]
            [Display(Order = 406)]
            [DisplayName("First Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TwistedENV_FirstBattle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Twisted Shopping District")]
            [Display(Order = 407)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA TwistedENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Yukiko's Castle

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 408)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_Entrance { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 409)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_Dungeon1 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 410)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_Dungeon2 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 411)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_Dungeon3 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 412)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_DungeonBoss { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 413)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_Battle { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 414)]
            [DisplayName("Mini Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_MiniBossBattle { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Yukiko's Castle")]
            [Display(Order = 415)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA CastleENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Steamy Bathhouse

            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 416)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 417)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 418)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 419)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 420)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 421)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Steamy Bathhouse")]
            [Display(Order = 422)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA SaunaENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Marukyu Striptease

            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 423)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_Entrance { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 424)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_Dungeon1 { get; set; } = ENVTypeA.P4;

            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 425)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 426)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 427)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 428)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 429)]
            [DisplayName("Boss Battle 1")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_BossBattle1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Marukyu Striptease")]
            [Display(Order = 430)]
            [DisplayName("Boss Battle 2")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA ClubENV_BossBattle2 { get; set; } = ENVTypeA.P4;

            //// Void Quest

            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 431)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 432)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 433)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 434)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 435)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 436)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Void Quest")]
            [Display(Order = 437)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA GameENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Secret Laboratory

            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 438)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 439)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 440)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 441)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 442)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 443)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Secret Laboratory")]
            [Display(Order = 444)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA LabENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Heaven

            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 445)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 446)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 447)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 448)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 449)]
            [DisplayName("Dungeon (Boss Floor 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_DungeonBoss1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 450)]
            [DisplayName("Dungeon (Boss Floor 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_DungeonBoss2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 451)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 452)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_BossBattle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Heaven")]
            [Display(Order = 453)]
            [DisplayName("Superboss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HeavenENV_SuperbossBattle { get; set; } = ENVTypeA.P4;

        //// Magatsu Inaba

            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 454)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 455)]
            [DisplayName("Dungeon - Magatsu Inaba")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 456)]
            [DisplayName("Dungeon - Magatsu Mandala (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 457)]
            [DisplayName("Dungeon - Magatsu Mandala (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 458)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 459)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 460)]
            [DisplayName("Boss Battle 1")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_BossBattle1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Magatsu Inaba")]
            [Display(Order = 461)]
            [DisplayName("Boss Battle 2")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA MagatsuENV_BossBattle2 { get; set; } = ENVTypeA.P4;

            //// Yomotsu Hirasaka

            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 462)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 463)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 464)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 465)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 466)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 467)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Yomotsu Hirasaka")]
            [Display(Order = 468)]
            [DisplayName("Boss Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA YomotsuENV_BossBattle { get; set; } = ENVTypeA.P4;

            //// Hollow Forest

            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 469)]
            [DisplayName("Entrance")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_Entrance { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 470)]
            [DisplayName("Dungeon (Layer 1)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_Dungeon1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 471)]
            [DisplayName("Dungeon (Layer 2)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_Dungeon2 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 472)]
            [DisplayName("Dungeon (Layer 3)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_Dungeon3 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 473)]
            [DisplayName("Dungeon (Boss Floor)")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_DungeonBoss { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 474)]
            [DisplayName("Battle")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_Battle { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 475)]
            [DisplayName("Boss Battle 1")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_BossBattle1 { get; set; } = ENVTypeA.P4;
        
            [Category("ENV Selection - Dungeons - Hollow Forest")]
            [Display(Order = 476)]
            [DisplayName("Boss Battle 2")]
            [Description("Select what visuals to use for this area.")]
            [DefaultValue(ENVTypeA.P4)]
            public ENVTypeA HollowENV_BossBattle2 { get; set; } = ENVTypeA.P4;


        // Field Texture Selection

        [Category("Texture Toggle - Town Map")]
        [Display(Order = 600)]
        [DisplayName("Town Map")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_TownMap { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 601)]
        [DisplayName("Classroom/Practice Building")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_001 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 602)]
        [DisplayName("Classroom 2-2")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_006 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 603)]
        [DisplayName("Music Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_007 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 604)]
        [DisplayName("Drama Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_008 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 605)]
        [DisplayName("P.E. Field")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_009 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 606)]
        [DisplayName("Basketball Court")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_010 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 607)]
        [DisplayName("Faculty Office")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_011 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 608)]
        [DisplayName("Nurse's Office")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_012 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 609)]
        [DisplayName("Library")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_013 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 610)]
        [DisplayName("Rooftop")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_014 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 611)]
        [DisplayName("School Entrance")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_015 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 612)]
        [DisplayName("Group Date Cafe")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_016 { get; set; } = true;

        [Category("Texture Toggle - Yasogami High")]
        [Display(Order = 613)]
        [DisplayName("School Festival 2F")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Yasogami_017 { get; set; } = true;


        [Category("Texture Toggle - Dojima Residence")]
        [Display(Order = 614)]
        [DisplayName("Outside")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Dojima_001 { get; set; } = true;

        [Category("Texture Toggle - Dojima Residence")]
        [Display(Order = 615)]
        [DisplayName("Living Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Dojima_002 { get; set; } = true;

        [Category("Texture Toggle - Dojima Residence")]
        [Display(Order = 616)]
        [DisplayName("Your Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Dojima_003 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 617)]
        [DisplayName("Shopping District North")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_001 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 618)]
        [DisplayName("Shopping District South")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_002 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 619)]
        [DisplayName("Daidara Metalworks")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_004 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 620)]
        [DisplayName("Chinese Diner Aiya")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_005 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 621)]
        [DisplayName("Shiroku Store")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_006 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 622)]
        [DisplayName("Tatsumi Textiles")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_007 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 623)]
        [DisplayName("Marukyu Tofu")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_008 { get; set; } = true;

        [Category("Texture Toggle - Shopping District")]
        [Display(Order = 624)]
        [DisplayName("Shrine")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_ShoppingDistrict_009 { get; set; } = true;

        [Category("Texture Toggle - Junes Department Store")]
        [Display(Order = 625)]
        [DisplayName("Food Court")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Junes_001 { get; set; } = true;

        [Category("Texture Toggle - Junes Department Store")]
        [Display(Order = 626)]
        [DisplayName("Electronics Department")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Junes_002 { get; set; } = true;

        [Category("Texture Toggle - Junes Department Store")]
        [Display(Order = 627)]
        [DisplayName("Produce Department")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Junes_003 { get; set; } = true;

        [Category("Texture Toggle - Junes Department Store")]
        [Display(Order = 628)]
        [DisplayName("West Entrance")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Junes_004 { get; set; } = true;

        [Category("Texture Toggle - Samegawa Floodplain")]
        [Display(Order = 629)]
        [DisplayName("Floodplain")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Samegawa_001 { get; set; } = true;

        [Category("Texture Toggle - Samegawa Floodplain")]
        [Display(Order = 630)]
        [DisplayName("Riverbank")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Samegawa_002 { get; set; } = true;

        [Category("Texture Toggle - Okina City")]
        [Display(Order = 631)]
        [DisplayName("Outside")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Okina_001 { get; set; } = true;

        [Category("Texture Toggle - Okina City")]
        [Display(Order = 632)]
        [DisplayName("Croco Fur")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Okina_002 { get; set; } = true;

        [Category("Texture Toggle - Inaba Municipal Hospital")]
        [Display(Order = 633)]
        [DisplayName("Hallway")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Hospital_002 { get; set; } = true;

        [Category("Texture Toggle - Inaba Municipal Hospital")]
        [Display(Order = 634)]
        [DisplayName("Patient Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Hospital_003 { get; set; } = true;

        [Category("Texture Toggle - Inaba Municipal Hospital")]
        [Display(Order = 635)]
        [DisplayName("Patient Room (Top Floor)")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Hospital_004 { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 636)]
        [DisplayName("Shu's Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_Shu { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 637)]
        [DisplayName("Namatame's Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_Namatame { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 638)]
        [DisplayName("Hill Overlooking Inaba")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_Hill { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 639)]
        [DisplayName("Police Station, Interrogation Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_PoliceInterrogation { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 640)]
        [DisplayName("Police Station, Hallway")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_PoliceHallway { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 641)]
        [DisplayName("Camping Trip (Outside)")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_CampingOutside { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 642)]
        [DisplayName("Camping Trip (Tent)")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_CampingTent { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 643)]
        [DisplayName("Camping Trip (Waterfall)")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_CampingWaterfall { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 644)]
        [DisplayName("Gekkoukan High, Entrance")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_GekkouEntrance { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 645)]
        [DisplayName("Gekkoukan High, Classroom")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_GekkouClassroom { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 646)]
        [DisplayName("Love Hotel")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_LoveHotel { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 647)]
        [DisplayName("Club Escapade")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_ClubEscapade { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 648)]
        [DisplayName("Iwatodai Station, Beef Bowl Shop")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_Iwatodai { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 649)]
        [DisplayName("School Zone")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_SchoolZone { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 650)]
        [DisplayName("Train Station")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_Train { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 651)]
        [DisplayName("Amagi Inn - Room")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_AmagiRoom { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 652)]
        [DisplayName("Amagi Inn - Entrance")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_AmagiEntrance { get; set; } = true;

        [Category("Texture Toggle - Miscellaneous")]
        [Display(Order = 653)]
        [DisplayName("Amagi Inn - Hot Springs")]
        [Description("Use P4 styled texture replacements in applicable areas.\n\nNote: Some textures in this mod are from P4 PS2, some are source textures,\nand others are edited P4G textures to look more like P4.")]
        [DefaultValue(true)]
        public bool Texture_Misc_AmagiHotSprings { get; set; } = true;

        // Misc Texture Selection

        [Category("Texture Selection")]
        [Display(Order = 700)]
        [DisplayName("TV Static")]
        [Description("Select whether to apply P4-style TV static or not.\n\nP4: Uses the P4-style TV static.\nStock: Uses the stock P4G TV static. Select this if using No TV Static 64.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA StaticENV { get; set; } = TexTypeA.P4;

        [Category("Texture Selection")]
        [Display(Order = 701)]
        [DisplayName("Fog Textures")]
        [Description("Select whether to apply P4-style fog or use the more \"stringy\" fog texture from P4G\nseen mainly in the TV World studio.\n\nP4: Uses the P4-style fog.\nStock: Uses the stock P4G fog.")]
        [DefaultValue(TexTypeA.P4)]
        public TexTypeA FogENV { get; set; } = TexTypeA.P4;

        // Field Selection, I no no wanna figure out how you did this so enjoy my commit being very different from your system

        [Category("Fields Imports and Other Models")]
        [Display(Order = 702)]
        [DisplayName("Power Lines")]
        [Description("Adds power line models to fields that had them in P4 but not P4G. yeah\n\nCurrently this breaks some road textures so it is disabled by default!")]
        [DefaultValue(false)]
        public bool PowerLinesTwitterLoves { get; set; } = false;

        // Event ENV Toggles

        [Category("Event ENV Toggles")]
        [Display(Order = 703)]
        [DisplayName("Gas Station Introduction")]
        [Description("Use P4 event files to change visuals for event specific\nENVs.\n\nThis event has extra fog in P4 PS2 that is not present in P4G.")]
        [DefaultValue(true)]
        public bool Event_E105_001 { get; set; } = true;

        [Category("Event ENV Toggles")]
        [Display(Order = 704)]
        [DisplayName("Entering the Bedroom")]
        [Description("Use P4 event files to change visuals for event specific\nENVs.\n\nThis event has a different fog transition at the beginning.")]
        [DefaultValue(true)]
        public bool Event_E124_003 { get; set; } = true;

        [Category("Event ENV Toggles")]
        [Display(Order = 705)]
        [DisplayName("Foggy Street Events")]
        [Description("Use P4 event files to change visuals for event specific\nENVs.\n\nThese events have different fog, being more yellowish-green.")]
        [DefaultValue(true)]
        public bool Event_FoggyStreet { get; set; } = true;

        // Night Skyboxes

        [Category("Night Skyboxes")]
        [Display(Order = 710)]
        [DisplayName("Dojima Residence, Outside")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_Dojima { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 711)]
        [DisplayName("Shopping District, North")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_ShoppingDistrictNorth { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 712)]
        [DisplayName("Shopping District, South")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_ShoppingDistrictSouth { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 713)]
        [DisplayName("Shrine")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_Shrine { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 714)]
        [DisplayName("Samegawa Floodplain")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_Samegawa { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 715)]
        [DisplayName("Hospital")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_Hospital { get; set; } = true;

        [Category("Night Skyboxes")]
        [Display(Order = 716)]
        [DisplayName("School Zone")]
        [Description("Toggle P4 style skyboxes for clear night fields.\n\nTrue: uses P4 style skyboxes, with clouds visible in the sky.\nFalse: uses P4G's default skyboxes for a starry night.")]
        [DefaultValue(true)]
        public bool NightSky_SchoolZone { get; set; } = true;
    }
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
}
