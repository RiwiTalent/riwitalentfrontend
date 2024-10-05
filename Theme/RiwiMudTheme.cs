using MudBlazor;

namespace RTFrontend.Theme;

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
            Primary = RiwiPalette.Secondary500,
            PrimaryDarken = RiwiPalette.Secondary600,
            PrimaryLighten = RiwiPalette.Secondary400,
            PrimaryContrastText = RiwiPalette.NeutralWhite,

            // Secondary
            Secondary = RiwiPalette.Primary500,
            SecondaryDarken = RiwiPalette.Primary600,
            SecondaryLighten = RiwiPalette.Primary400,
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
            Primary = RiwiPalette.Secondary500,
            PrimaryDarken = RiwiPalette.Secondary600,
            PrimaryLighten = RiwiPalette.Secondary400,
            PrimaryContrastText = RiwiPalette.NeutralWhite,

            // Secondary
            Secondary = RiwiPalette.Primary500,
            SecondaryDarken = RiwiPalette.Primary600,
            SecondaryLighten = RiwiPalette.Primary400,
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
        // Tipografía personalizada
        public static Typography Typography = new()
        {
            Default = new Default()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400
            },
            H1 = new H1()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "2.5rem",
                FontWeight = 700,
                LineHeight = 1.2
            },
            H2 = new H2()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "2rem",
                FontWeight = 600,
                LineHeight = 1.3
            },
            H3 = new H3()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1.75rem",
                FontWeight = 500,
                LineHeight = 1.4
            },
            H4 = new H4()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1.5rem",
                FontWeight = 500,
                LineHeight = 1.5
            },
            H5 = new H5()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1.25rem",
                FontWeight = 400,
                LineHeight = 1.6
            },
            H6 = new H6()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.6
            },
            Subtitle1 = new Subtitle1()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 500,
                LineHeight = 1.75
            },
            Subtitle2 = new Subtitle2()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 500,
                LineHeight = 1.57
            },
            Body1 = new Body1()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5
            },
            Body2 = new Body2()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.43
            },
            Button = new Button()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 500,
                LineHeight = 1.75
            },
            Caption = new Caption()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 1.66
            },
            Overline = new Overline()
            {
                FontFamily = new[] { "Ubuntu", "sans-serif" },
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 2.66
            }
        };
    }