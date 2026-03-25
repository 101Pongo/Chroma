namespace Atlas.Chroma.Runtime.Public {

    /// <summary>
    ///     Comprehensive color swatches organized by hue (15° intervals) and intensity variations.
    ///     All colors are processed for balanced luminance to ensure consistent perceived brightness.
    /// </summary>
    public static class Swatch {
        /// <summary>
        ///     Applies saturation and brightness adjustments, then balances luminance for consistent perceived brightness
        /// </summary>
        public static Chroma ColorProcess(Chroma color, float saturation, float brightness)
			=> color.SetSaturation(saturation).SetBrightness(brightness).GetBalancedLuminance();

        /// <summary>
        ///     Pure hues at 15° intervals with 100% saturation and brightness.
        ///     These are the base colors for all other variations.
        /// </summary>
        public static class Pure {
			/// <summary>Red (0°)</summary>
			public static Chroma Red => new(0f);
			/// <summary>Red-Orange (15°)</summary>
			public static Chroma Vermilion => new(15f);
			/// <summary>Orange (30°)</summary>
			public static Chroma Orange => new(30f);
			/// <summary>Yellow-Orange (45°)</summary>
			public static Chroma Golden => new(45f);
			/// <summary>Yellow (60°)</summary>
			public static Chroma Yellow => new(60f);
			/// <summary>Yellow-Green (75°)</summary>
			public static Chroma Lime => new(75f);
			/// <summary>Yellow-Green (90°)</summary>
			public static Chroma Chartreuse => new(90f);
			/// <summary>Yellow-Green (105°)</summary>
			public static Chroma Harlequin => new(105f);
			/// <summary>Green (120°)</summary>
			public static Chroma Green => new(120f);
			/// <summary>Green-Cyan (135°)</summary>
			public static Chroma Erin => new(135f);
			/// <summary>Green-Cyan (150°)</summary>
			public static Chroma Mint => new(150f);
			/// <summary>Green-Cyan (165°)</summary>
			public static Chroma Aquamarine => new(165f);
			/// <summary>Cyan (180°)</summary>
			public static Chroma Cyan => new(180f);
			/// <summary>Cyan-Blue (195°)</summary>
			public static Chroma Cerulean => new(195f);
			/// <summary>Cyan-Blue (210°)</summary>
			public static Chroma Azure => new(210f);
			/// <summary>Blue (225°)</summary>
			public static Chroma Cobalt => new(225f);
			/// <summary>Blue (240°)</summary>
			public static Chroma Blue => new(240f);
			/// <summary>Blue-Violet (255°)</summary>
			public static Chroma Indigo => new(255f);
			/// <summary>Violet (270°)</summary>
			public static Chroma Violet => new(270f);
			/// <summary>Violet-Magenta (285°)</summary>
			public static Chroma Purple => new(285f);
			/// <summary>Magenta (300°)</summary>
			public static Chroma Magenta => new(300f);
			/// <summary>Magenta-Red (315°)</summary>
			public static Chroma Fandango => new(315f);
			/// <summary>Magenta-Red (330°)</summary>
			public static Chroma Rose => new(330f);
			/// <summary>Red-Magenta (345°)</summary>
			public static Chroma Carmine => new(345f);
		}

        /// <summary>
        ///     Friendly, approachable colors with 80% saturation and brightness.
        ///     Good for UI elements and general purpose use.
        /// </summary>
        public static class Friendly {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => color.SetSaturation(80f).SetBrightness(80f);
		}

        /// <summary>
        ///     Bright, eye-catching colors with 100% saturation and 90% brightness.
        ///     Good for attention-grabbing elements and highlights.
        /// </summary>
        public static class Vivid {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 100f, 90f);
		}

        /// <summary>
        ///     Medium intensity colors with 100% saturation and 45% brightness.
        ///     Good for darker themes and body content.
        /// </summary>
        public static class Middle {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 100f, 45f);
		}

        /// <summary>
        ///     Deep, rich colors with 100% saturation and 20% brightness.
        ///     Good for dark themes, backgrounds, and subtle accents.
        /// </summary>
        public static class Dark {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 100f, 20f);
		}

        /// <summary>
        ///     Light, pastel colors with 50% saturation and 100% brightness.
        ///     Good for light themes, backgrounds, and soft accents.
        /// </summary>
        public static class Tinted {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 50f, 100f);
		}

        /// <summary>
        ///     Muted, subdued colors with 50% saturation and 45% brightness.
        ///     Good for secondary elements and background details.
        /// </summary>
        public static class Toned {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 50f, 45f);
		}

        /// <summary>
        ///     Dark, muted colors with 50% saturation and 20% brightness.
        ///     Good for dark theme backgrounds and subtle UI elements.
        /// </summary>
        public static class Shaded {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 50f, 20f);
		}

        /// <summary>
        ///     Very light, subtle colors with 25% saturation and 100% brightness.
        ///     Good for backgrounds, hover states, and very subtle accents.
        /// </summary>
        public static class Pale {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 25f, 100f);
		}

        /// <summary>
        ///     Neutral, barely-tinted grays with 25% saturation and 45% brightness.
        ///     Good for borders, dividers, and neutral UI elements with subtle color hints.
        /// </summary>
        public static class Neutral {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 25f, 45f);
		}

        /// <summary>
        ///     Very dark, barely-tinted colors with 25% saturation and 20% brightness.
        ///     Good for dark theme backgrounds with subtle color warmth/coolness.
        /// </summary>
        public static class Shadow {
			public static Chroma Red => Process(Pure.Red);
			public static Chroma Vermilion => Process(Pure.Vermilion);
			public static Chroma Orange => Process(Pure.Orange);
			public static Chroma Golden => Process(Pure.Golden);
			public static Chroma Yellow => Process(Pure.Yellow);
			public static Chroma Lime => Process(Pure.Lime);
			public static Chroma Chartreuse => Process(Pure.Chartreuse);
			public static Chroma Harlequin => Process(Pure.Harlequin);
			public static Chroma Green => Process(Pure.Green);
			public static Chroma Erin => Process(Pure.Erin);
			public static Chroma Mint => Process(Pure.Mint);
			public static Chroma Aquamarine => Process(Pure.Aquamarine);
			public static Chroma Cyan => Process(Pure.Cyan);
			public static Chroma Cerulean => Process(Pure.Cerulean);
			public static Chroma Azure => Process(Pure.Azure);
			public static Chroma Cobalt => Process(Pure.Cobalt);
			public static Chroma Blue => Process(Pure.Blue);
			public static Chroma Indigo => Process(Pure.Indigo);
			public static Chroma Violet => Process(Pure.Violet);
			public static Chroma Purple => Process(Pure.Purple);
			public static Chroma Magenta => Process(Pure.Magenta);
			public static Chroma Fandango => Process(Pure.Fandango);
			public static Chroma Rose => Process(Pure.Rose);
			public static Chroma Carmine => Process(Pure.Carmine);
			public static Chroma Process(Chroma color) => ColorProcess(color, 25f, 20f);
		}
	}

}