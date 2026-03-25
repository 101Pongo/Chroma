namespace Atlas.Chroma.Runtime.Public {

    /// <summary>
    ///     Predefined colors for user communication and UI feedback
    /// </summary>
    public static class SignalColors {
        /// <summary>
        ///     Success, confirmation, or positive feedback color (green)
        /// </summary>
        public static Chroma Positive => Swatch.Friendly.Erin;

        /// <summary>
        ///     Warning or caution color (orange)
        /// </summary>
        public static Chroma Warning => Swatch.Pure.Orange.SetSaturation(90f).SetBrightness(90f);

        /// <summary>
        ///     Error, danger, or negative feedback color (red)
        /// </summary>
        public static Chroma Negative => Swatch.Friendly.Red;

        /// <summary>
        ///     Informational or neutral color (blue)
        /// </summary>
        public static Chroma Info => Swatch.Friendly.Azure;

        /// <summary>
        ///     Special or notable color (purple)
        /// </summary>
        public static Chroma Special => Swatch.Friendly.Purple;

        /// <summary>
        ///     Interactive action color (bright blue)
        /// </summary>
        public static Chroma Action => Swatch.Pure.Azure;

        /// <summary>
        ///     Disabled state color (desaturated gray)
        /// </summary>
        public static Chroma Disabled => Info.SetSaturation(0f).SetBrightness(60f);

        /// <summary>
        ///     Selection highlight color (light gray)
        /// </summary>
        public static Chroma Select => Info.SetSaturation(0f).SetBrightness(90f);

        /// <summary>
        ///     Focus indicator color (blue)
        /// </summary>
        public static Chroma Focus => Info;

        /// <summary>
        ///     Text highlight background color (toned blue)
        /// </summary>
        public static Chroma TextHighlight => Swatch.Toned.Process(Focus);
	}

}