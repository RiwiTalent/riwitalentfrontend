using MudBlazor;

namespace riwi.Theme;

    public static class CustomMudTheme
    {
        public static PaletteLight PaletteLight = new PaletteLight
        {
            // AppBar (Barra de Aplicación)
            AppbarText = RiwiPalette.NeutralBlack,
            AppbarBackground = RiwiPalette.NeutralWhite,

            // Drawer (Panel Lateral)
            DrawerBackground = RiwiPalette.NeutralWhite,
            DrawerText = RiwiPalette.Primary500,
            DrawerIcon = RiwiPalette.Primary500,

            // Background (Fondo)
            Background = RiwiPalette.NeutralWhite,

            // Colors (Colores)
            // neutral
            Black = RiwiPalette.NeutralBlack,
            White = RiwiPalette.NeutralWhite,
            GrayDefault = RiwiPalette.FeedbackWarning600,
            GrayLight = RiwiPalette.FeedbackWarning600,
            GrayLighter = RiwiPalette.FeedbackWarning600,

            // Primary
            Primary = RiwiPalette.Primary500,
            PrimaryDarken = RiwiPalette.Primary600,
            PrimaryLighten = RiwiPalette.Primary400,
            PrimaryContrastText = RiwiPalette.NeutralWhite,

            // Secondary
            Secondary = RiwiPalette.Secondary500,
            SecondaryDarken = RiwiPalette.Secondary600,
            SecondaryLighten = RiwiPalette.Secondary400,
            SecondaryContrastText = RiwiPalette.NeutralWhite,

            // FeedbackInfo
            Info = RiwiPalette.FeedbackInfo500,
            InfoDarken = RiwiPalette.FeedbackInfo600,
            InfoLighten = RiwiPalette.FeedbackInfo400,
            InfoContrastText = RiwiPalette.NeutralWhite,

            // FeedbackSuccess
            Success = RiwiPalette.FeedbackSuccess500,
            SuccessDarken = RiwiPalette.FeedbackSuccess600,
            SuccessLighten = RiwiPalette.FeedbackSuccess400,
            SuccessContrastText = RiwiPalette.NeutralWhite,

            // FeedbackWarning
            Warning = RiwiPalette.FeedbackWarning500,
            WarningDarken = RiwiPalette.FeedbackWarning600,
            WarningLighten = RiwiPalette.FeedbackWarning400,
            WarningContrastText = RiwiPalette.NeutralWhite,

            // FeedbackDanger
            Error = RiwiPalette.FeedbackDanger500,
            ErrorDarken = RiwiPalette.FeedbackDanger600,
            ErrorLighten = RiwiPalette.FeedbackDanger400,
            ErrorContrastText = RiwiPalette.NeutralWhite,
        };

        // Definición de la paleta de colores para el tema oscuro
        public static PaletteDark PaletteDark = new PaletteDark
        {
            // AppBar (Barra de Aplicación)
            AppbarText = RiwiPalette.NeutralWhite,
            AppbarBackground = RiwiPalette.Primary800,

            // Drawer (Panel Lateral)
            DrawerBackground = RiwiPalette.Primary800,

            // Background (Fondo)
            Background = RiwiPalette.NeutralBlack,

            // Colors (Colores)
            // neutral
            Black = RiwiPalette.NeutralBlack,
            White = RiwiPalette.NeutralWhite,
            GrayDefault = RiwiPalette.NeutralGrey,
            GrayLight = RiwiPalette.NeutralSoftGrey,
            GrayLighter = RiwiPalette.NeutralLightGrey,

            // Primary
            Primary = RiwiPalette.Primary500,
            PrimaryDarken = RiwiPalette.Primary600,
            PrimaryLighten = RiwiPalette.Primary400,
            PrimaryContrastText = RiwiPalette.NeutralWhite,

            // Secondary
            Secondary = RiwiPalette.Secondary500,
            SecondaryDarken = RiwiPalette.Secondary600,
            SecondaryLighten = RiwiPalette.Secondary400,
            SecondaryContrastText = RiwiPalette.NeutralWhite,

            // FeedbackInfo
            Info = RiwiPalette.FeedbackInfo500,
            InfoDarken = RiwiPalette.FeedbackInfo600,
            InfoLighten = RiwiPalette.FeedbackInfo400,
            InfoContrastText = RiwiPalette.NeutralWhite,

            // FeedbackSuccess
            Success = RiwiPalette.FeedbackSuccess500,
            SuccessDarken = RiwiPalette.FeedbackSuccess600,
            SuccessLighten = RiwiPalette.FeedbackSuccess400,
            SuccessContrastText = RiwiPalette.NeutralWhite,

            // FeedbackWarning
            Warning = RiwiPalette.FeedbackWarning500,
            WarningDarken = RiwiPalette.FeedbackWarning600,
            WarningLighten = RiwiPalette.FeedbackWarning400,
            WarningContrastText = RiwiPalette.NeutralWhite,

            // FeedbackDanger
            Error = RiwiPalette.FeedbackDanger500,
            ErrorDarken = RiwiPalette.FeedbackDanger600,
            ErrorLighten = RiwiPalette.FeedbackDanger400,
            ErrorContrastText = RiwiPalette.NeutralWhite,
        };

        public static LayoutProperties LayoutProperties = new LayoutProperties
        {
            DrawerWidthLeft = "240px",
            AppbarHeight = "64px",
            DefaultBorderRadius = "10px"
        };
    }