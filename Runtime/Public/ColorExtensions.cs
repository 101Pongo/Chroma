using UnityEngine;

namespace Atlas.Chroma.Runtime.Public {

    /// <summary>
    ///     Extension methods for UnityEngine.Color operations
    /// </summary>
    public static class ColorExtensions {
		
        /// <summary>
        ///     Returns a new color with the specified alpha value.
        ///     Example: color.WithAlpha(0.5f)
        /// </summary>
        public static Color WithAlpha(this Color color, float alpha) {
			color.a = alpha;

			return color;
		}

        /// <summary>
        ///     Returns a new color with the specified red value.
        ///     Example: color.WithRed(1f)
        /// </summary>
        public static Color WithRed(this Color color, float red) {
			color.r = red;

			return color;
		}

        /// <summary>
        ///     Returns a new color with the specified green value.
        ///     Example: color.WithGreen(1f)
        /// </summary>
        public static Color WithGreen(this Color color, float green) {
			color.g = green;

			return color;
		}

        /// <summary>
        ///     Returns a new color with the specified blue value.
        ///     Example: color.WithBlue(1f)
        /// </summary>
        public static Color WithBlue(this Color color, float blue) {
			color.b = blue;

			return color;
		}

        /// <summary>
        ///     Checks if color is perceptually bright using YIQ color space luminance calculation.
        ///     Example: if (color.IsBright()) { ... }
        /// </summary>
        public static bool IsBright(this Color color) {
			float yiq = ( color.r * 299f + color.g * 587f + color.b * 114f ) / 1000f;

			return yiq >= 0.5f;
		}

        /// <summary>
        ///     Checks if color is perceptually dark.
        ///     Example: if (color.IsDark()) { ... }
        /// </summary>
        public static bool IsDark(this Color color) => !color.IsBright();

        /// <summary>
        ///     Returns black or white based on the color's brightness for optimal text contrast.
        ///     Example: Color textColor = backgroundColor.GetTextColor()
        /// </summary>
        public static Color GetTextColor(this Color color) => color.IsBright() ? Color.black : Color.white;

        /// <summary>
        ///     Returns dark or light color based on the background color's brightness.
        ///     Example: Color textColor = backgroundColor.GetTextColor(Color.black, Color.white)
        /// </summary>
        public static Color GetTextColor(this Color color, Color darkColor, Color lightColor)
			=> color.IsBright() ? darkColor : lightColor;

        /// <summary>
        ///     Clamps all color components (RGBA) to [0, 1] range.
        ///     Example: color.Clamp01()
        /// </summary>
        public static Color Clamp01(this Color color) {
			color.r = Mathf.Clamp01(color.r);
			color.g = Mathf.Clamp01(color.g);
			color.b = Mathf.Clamp01(color.b);
			color.a = Mathf.Clamp01(color.a);

			return color;
		}

        /// <summary>
        ///     Multiplies the color's RGB values by a factor (preserves alpha).
        ///     Example: color.Brighten(1.5f)
        /// </summary>
        public static Color Brighten(this Color color, float factor) {
			color.r *= factor;
			color.g *= factor;
			color.b *= factor;

			return color;
		}

        /// <summary>
        ///     Darkens the color by multiplying RGB by a factor less than 1.
        ///     Example: color.Darken(0.5f)
        /// </summary>
        public static Color Darken(this Color color, float factor) => color.Brighten(1f - factor);

        /// <summary>
        ///     Inverts the color (1 - each component). Preserves alpha.
        ///     Example: Color inverted = color.Invert()
        /// </summary>
        public static Color Invert(this Color color) => new(1f - color.r, 1f - color.g, 1f - color.b, color.a);

        /// <summary>
        ///     Returns a grayscale version of the color using luminance calculation.
        ///     Example: Color gray = color.Grayscale()
        /// </summary>
        public static Color Grayscale(this Color color) {
			float gray = color.r * 0.299f + color.g * 0.587f + color.b * 0.114f;

			return new Color(gray, gray, gray, color.a);
		}

        /// <summary>
        ///     Converts color to Vector4 (r, g, b, a).
        ///     Example: Vector4 vec = color.ToVector4()
        /// </summary>
        public static Vector4 ToVector4(this Color color) => new(color.r, color.g, color.b, color.a);

        /// <summary>
        ///     Converts color to Vector3 (r, g, b).
        ///     Example: Vector3 vec = color.ToVector3()
        /// </summary>
        public static Vector3 ToVector3(this Color color) => new(color.r, color.g, color.b);

        /// <summary>
        ///     Converts color to hex string.
        ///     Example: string hex = color.ToHex() returns "FF8800FF"
        /// </summary>
        public static string ToHex(this Color color) {
			Color32 c = color;

			return $"{c.r:X2}{c.g:X2}{c.b:X2}{c.a:X2}";
		}

        /// <summary>
        ///     Converts color to hex string with # prefix.
        ///     Example: string hex = color.ToHexWithPrefix() returns "#FF8800FF"
        /// </summary>
        public static string ToHexWithPrefix(this Color color) => "#" + color.ToHex();

        /// <summary>
        ///     Linearly interpolates between two colors.
        ///     Example: Color blended = color1.Lerp(color2, 0.5f)
        /// </summary>
        public static Color Lerp(this Color from, Color to, float t) => Color.Lerp(from, to, t);

        /// <summary>
        ///     Blends two colors additively.
        ///     Example: Color result = color1.Add(color2)
        /// </summary>
        public static Color Add(this Color color, Color other) => new(
				color.r + other.r,
				color.g + other.g,
				color.b + other.b,
				color.a
		);

        /// <summary>
        ///     Multiplies two colors component-wise.
        ///     Example: Color result = color1.Multiply(color2)
        /// </summary>
        public static Color Multiply(this Color color, Color other) => new(
				color.r * other.r,
				color.g * other.g,
				color.b * other.b,
				color.a
		);
	}

}