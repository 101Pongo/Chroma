using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Atlas.Chroma.Runtime.Internal;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Atlas.Chroma.Runtime.Public {

    /// <summary>
    ///     Chroma is a color struct that uses Hue, Saturation and Brightness (HSB/HSV).
    ///     Hue loops between a 0-360f range. Saturation, Brightness and Alpha are clamped within a 0-100f range.
    /// </summary>
    [Serializable]
	public struct Chroma : IEquatable<Chroma>, IFormattable {
        /// <summary>
        ///     The backing field of Hue.
        /// </summary>
        [SerializeField]
		[Range(0f, 360f)]
		private float _hue;

        /// <summary>
        ///     The backing field of Saturation.
        /// </summary>
        [SerializeField]
		[Range(0f, 100f)]
		private float _saturation;

        /// <summary>
        ///     The backing field of Brightness.
        /// </summary>
        [SerializeField]
		[Range(0f, 100f)]
		private float _brightness;

        /// <summary>
        ///     The backing field of Alpha.
        /// </summary>
        [SerializeField]
		[Range(0f, 100f)]
		private float _alpha;

        /// <summary>
        ///     A looped radial angular position from 0-360f that points to a position on a color wheel.
        /// </summary>
        public float Hue {
			get => _hue;
			set => _hue = Loop(value, 360f);
		}

        /// <summary>
        ///     A clamped value from 0-100f that controls the color's tone.
        /// </summary>
        public float Saturation {
			get => _saturation;
			set => _saturation = Mathf.Clamp(value, 0f, 100f);
		}

        /// <summary>
        ///     A clamped value from 0-100f that controls the color's value.
        /// </summary>
        public float Brightness {
			get => _brightness;
			set => _brightness = Mathf.Clamp(value, 0f, 100f);
		}

        /// <summary>
        ///     A clamped value from 0-100f that controls the color's opacity.
        /// </summary>
        public float Alpha {
			get => _alpha;
			set => _alpha = Mathf.Clamp(value, 0f, 100f);
		}

        /// <summary>
        ///     Chroma's constructor.
        /// </summary>
        public Chroma(float hue, float saturation = 100, float brightness = 100, float alpha = 100) {
			this._hue        = Loop(hue, 360);
			this._saturation = Mathf.Clamp(saturation, 0, 100);
			this._brightness = Mathf.Clamp(brightness, 0, 100);
			this._alpha      = Mathf.Clamp(alpha, 0, 100);
		}

        /// <summary>
        ///     Chroma's constructor.
        /// </summary>
        public Chroma(Color color) {
			Color.RGBToHSV(color, out float hue, out float saturation, out float brightness);
			this._hue        = Loop(hue               * 360f, 360f);
			this._saturation = Mathf.Clamp(saturation * 100, 0, 100);
			this._brightness = Mathf.Clamp(brightness * 100, 0, 100);
			_alpha           = Mathf.Clamp(color.a    * 100, 0, 100);
		}

        /// <summary>
        ///     Chroma constructor.
        /// </summary>
        public Chroma(string hexCode) {
			if (!hexCode.StartsWith('#')) {
				hexCode = $"#{hexCode}";
			}

			ColorUtility.TryParseHtmlString(hexCode, out Color color);

			Color.RGBToHSV(color, out float hue, out float saturation, out float brightness);
			this._hue        = Loop(hue * 360f, 360f);
			this._saturation = Mathf.Clamp(saturation * 100f, 0f, 100f);
			this._brightness = Mathf.Clamp(brightness * 100f, 0f, 100f);
			_alpha           = Mathf.Clamp(color.a    * 100f, 0f, 100f);
		}

        /// <summary>
        ///     Chroma's constructor.
        /// </summary>
        public Chroma(Color32 color) : this((Color)color) { }

        /// <summary>
        ///     Chroma's constructor.
        /// </summary>
        public Chroma(Chroma color) {
			_hue        = color._hue;
			_saturation = color._saturation;
			_brightness = color._brightness;
			_alpha      = color._alpha;
		}

        /// <summary>
        ///     Make a copy of this object.
        /// </summary>
        private Chroma Copy => new(this);

        /// <summary>
        ///     Returns the color with no saturation and with brightness set to the color's percieved lightness.
        /// </summary>
        public Chroma AsGrayscale => Copy.SetSaturation(0f).SetBrightness(CalculatePerceivedLightness());

        /// <summary>
        ///     Convert this color to a Unity.Color.
        /// </summary>
        public Color AsColor
			=> Color.HSVToRGB(Hue / 360f, Saturation / 100f, Brightness / 100f).WithAlpha(Alpha / 100f);

        /// <summary>
        ///     Convert this color to a Unity.Color32.
        /// </summary>
        public Color32 AsColor32 => AsColor;

        /// <summary>
        ///     Returns the hex code of this object.
        /// </summary>
        public string AsHexCode
			=> "#" + Hexify(AsColor32.r) + Hexify(AsColor32.g) + Hexify(AsColor32.b) + Hexify(AsColor32.a);

		private string Hexify(byte value) => value.ToString("X2");

		public string AsCopyPasteChromaString => $"new Chroma({Hue}f, {Saturation}f, {Brightness}f, {Alpha}f)";
		public string AsCopyPasteColorString => $"new Color({AsColor.r}f, {AsColor.g}f, {AsColor.b}f, {AsColor.a}f)";
		public string AsCopyPasteColor32String
			=> $"new Color32({AsColor32.r}, {AsColor32.g}, {AsColor32.b}, {AsColor32.a})";

		public string AsChromaString
			=> $"HSBA\n({Round(Hue, 0)}, {Round(Saturation, 0)}, {Round(Brightness, 0)}, {Round(Alpha, 0)})";
		public string AsColorString
			=> $"RGBA\n({Round(AsColor.r, 2)}, {Round(AsColor.g, 2)}, {Round(AsColor.b, 2)}, {Round(AsColor.a, 2)})";
		public string AsColor32String => $"RGBA32\n({AsColor32.r}, {AsColor32.g}, {AsColor32.b}, {AsColor32.a})";

		public static float Round(float value, int decimalPlaces) {
			float multiplier = Mathf.Pow(10f, decimalPlaces);
			return Mathf.Round(value * multiplier) / multiplier;
		}
		
        /// <summary>
        ///     Is the luma bright?
        /// </summary>
        public bool IsBright => CalculateLuma() >= 50f;

        /// <summary>
        ///     Is the luma dark?
        /// </summary>
        public bool IsDark => !IsBright;

        /// <summary>
        ///     Returns a no-opacity black color.
        /// </summary>
        public static Chroma Clear => new(0f, 0f, 0f, 0f);

        /// <summary>
        ///     Returns a pure white.
        /// </summary>
        public static Chroma White => new(0f, 0f);

        /// <summary>
        ///     Returns a pure black.
        /// </summary>
        public static Chroma Black => new(0f, 0f, 0f);

        /// <summary>
        ///     Returns a pure gray.
        /// </summary>
        public static Chroma MiddleGray => Graytone();

        /// <summary>
        ///     Returns a totally random color.
        /// </summary>
        public static Chroma RandomColor => RandomInRange();

        /// <summary>
        ///     Returns a random "pure" color.
        /// </summary>
        public static Chroma RandomHue => Huetone(Random.Range(0, 360f));

        /// <summary>
        ///     Returns a random gray color.
        /// </summary>
        public static Chroma RandomGray => Graytone(Random.Range(0, 100f));

        /// <summary>
        ///     Returns a "pure" color at the specified hue (0-360).
        /// </summary>
        public static Chroma Huetone(float hue, float alpha = 100f) => new(hue, 100f, 100f, alpha);

        /// <summary>
        ///     Returns a gray color at the specified brightness (0-100).
        /// </summary>
        public static Chroma Graytone(float brightness = 50f, float alpha = 100f) => new(0, 0, brightness, alpha);

		public static Chroma RandomInRange(
				float hueMin = 0f,
				float hueMax = 360f,
				float saturationMin = 0f,
				float saturationMax = 100f,
				float brightnessMin = 0f,
				float brightnessMax = 100f
		) => new(
				Random.Range(hueMin, hueMax),
				Random.Range(saturationMin, saturationMax),
				Random.Range(brightnessMin, brightnessMax)
		);

        /// <summary>
        ///     Returns a random "pure" color.
        /// </summary>
        public static Chroma RandomTone(float hue) => new(hue, Random.Range(0, 100f), Random.Range(0, 100f));

        /// <summary>
        ///     Used to ensure the hue stays within the 0-max range.
        /// </summary>
        private static float Loop(float value, float max) => value < 0 ? max - Mathf.Abs(value % max) : value % max;

        /// <summary>
        ///     The Gamma-Compressed weighted value.
        /// </summary>
        public float CalculateLuma() {
			Color c = AsColor;

			return ( c.r * 212.6f + c.g * 715.2f + c.b * 72.2f ) / 10f;
		}

        /// <summary>
        ///     The Gamma-Expanded weighted value.
        /// </summary>
        public float CalculateLuminance() {
			Color c = AsColor.linear;

			return ( c.r * 212.6f + c.g * 715.2f + c.b * 72.2f ) / 10f;
		}

        /// <summary>
        ///     Returns the value of perceptual lightness / the luminance weighted for human vision.
        /// </summary>
        public float CalculatePerceivedLightness() {
			float y = CalculateLuminance() / 100f;

			return y <= 216f / 24389f ? y * ( 24389f / 27f ) : Mathf.Pow(y, 1f / 3f) * 116f - 16f;
		}

        /// <summary>
        ///     Returns a 0-100f value for how close the hue value is to 180 degrees.
        /// </summary>
        public float MeasureHuePercentDistanceFromRed
			=> Mathf.InverseLerp(0f, 180f, MeasureHueDistanceFromRed()) * 100f;

        /// <summary>
        ///     Returns the value of perceptual lightness / the luminance weighted for human vision.
        /// </summary>
        public float MeasureHueDistanceFromRed() => Hue <= 180f ? Hue : 360f - Hue;

        /// <summary>
        ///     Get a new color with this value as its hue.
        /// </summary>
        public Chroma SetHue(float hue) {
			Chroma c = Copy;
			c.Hue = hue;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value as its saturation.
        /// </summary>
        public Chroma SetSaturation(float saturation) {
			Chroma c = Copy;
			c.Saturation = saturation;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value as its brightness.
        /// </summary>
        public Chroma SetBrightness(float brightness) {
			Chroma c = Copy;
			c.Brightness = brightness;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value as its saturation and brightness.
        /// </summary>
        public Chroma SetTone(float saturation, float brightness) {
			Chroma c = Copy;
			c.Saturation = saturation;
			c.Brightness = brightness;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value added to its brightness.
        /// </summary>
        public Chroma SetAlpha(float alpha) {
			Chroma c = Copy;
			c.Alpha = alpha;

			return c;
		}

        /// <summary>
        ///     Get a new color with everything shifted.
        /// </summary>
        public Chroma Shift(float hue, float saturation = 0f, float brightness = 0f, float alpha = 0f) {
			Chroma c = Copy;
			c.Hue        += hue;
			c.Saturation += saturation;
			c.Brightness += brightness;
			c.Alpha      += alpha;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value added to its hue.
        /// </summary>
        public Chroma ShiftHue(float hue) {
			Chroma c = Copy;
			c.Hue += hue;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value added to its saturation.
        /// </summary>
        public Chroma ShiftSaturation(float saturation) {
			Chroma c = Copy;
			c.Saturation += saturation;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value added to its brightness.
        /// </summary>
        public Chroma ShiftBrightness(float brightness) {
			Chroma c = Copy;
			c.Brightness += brightness;

			return c;
		}

        /// <summary>
        ///     Get a new color with everything shifted.
        /// </summary>
        public Chroma ShiftTone(float saturation, float brightness) {
			Chroma c = Copy;
			c.Saturation += saturation;
			c.Brightness += brightness;

			return c;
		}

        /// <summary>
        ///     Get a new color with this value added to its saturation.
        /// </summary>
        public Chroma ShiftAlpha(float alpha) {
			Chroma c = Copy;
			c.Alpha += alpha;

			return c;
		}

        /// <summary>
        ///     Complementary colors are pairs of colors which, when combined or mixed, cancel each other out.
        /// </summary>
        public Chroma GetComplementaryColor() => Copy.ShiftHue(180f);

        /// <summary>
        ///     The split-complementary color scheme is a three-color combination consisting of base color
        ///     and two colors that are 150 degrees and 210 degrees apart from the base color.
        /// </summary>
        public Chroma[] GetSplitComplementaryColors() => GetPolychromaticColors(0f, 150f, 210f);

        /// <summary>
        ///     The triadic color scheme is a three-color combination consisting of base color and two colors that are
        ///     120 degrees and 240 degrees apart from the base color
        /// </summary>
        public Chroma[] GetTriadicColors() => GetPolychromaticColors(0f, 120f, 240f);

        /// <summary>
        ///     The tetradic color scheme uses four colors arranged into two complementary color pairs.
        /// </summary>
        public Chroma[] GetTetradicColors() => GetPolychromaticColors(0f, 90f, 180f, 270f);

        /// <summary>
        ///     The Analogous color scheme uses a group of colors next to each other on a color wheel.
        /// </summary>
        public Chroma[] GetAnalogousColors() => GetPolychromaticColors(-60f, -30f, 0f, 30f, 60f);

        /// <summary>
        ///     Returns a group of colors with shifted hues.
        /// </summary>
        public Chroma[] GetPolychromaticColors(params float[] hueShifts) {
			if (hueShifts is not { Length: > 1 }) {
				return default;
			}

			List<Chroma> colors = new();

			foreach (float hueShift in hueShifts) {
				colors.Add(Copy.ShiftHue(hueShift));
			}

			return colors.ToArray();
		}

        /// <summary>
        ///     Make a copy of this object.
        /// </summary>
        public Chroma GetInverse()
			=> GetComplementaryColor().SetSaturation(100 - _saturation).SetBrightness(100 - _brightness);

        /// <summary>
        ///     Takes the average Luminance of 60 and 240 degree hues at the same saturation and lightness,
        ///     and then shifts this color towards that midpoint. Then, shifts the hue to compensate for RGB color shifting
        ///     that happens
        /// </summary>
        public Chroma GetBalancedLuminance(float strength = 3.5f) => GetBalancedLuminance(Copy, strength);

        /// <summary>
        ///     Takes the average Luminance of 60 and 240 degree hues at the same saturation and lightness,
        ///     and then shifts this color towards that midpoint. Then, shifts the hue to compensate for RGB color shifting
        ///     that happens
        /// </summary>
        public static Chroma GetBalancedLuminance(Chroma color, float strength = 3.5f) {
			float lum      = color.CalculatePerceivedLightness();
			float high     = new Chroma(60, color.Saturation, color.Brightness).CalculatePerceivedLightness();
			float low      = new Chroma(240, color.Saturation, color.Brightness).CalculatePerceivedLightness();
			float midpoint = high - low;
			bool  isLow    = lum <= midpoint;

			float deficiency = isLow
					? ( 1f - Mathf.InverseLerp(low, midpoint, lum) ) * 2f
					: Mathf.InverseLerp(midpoint, high, lum);

			return color.ShiftBrightness(( isLow ? 1f : -1f ) * Mathf.Pow(deficiency, strength))
						.ShiftSaturation(isLow ? -Mathf.Pow(deficiency, strength * 1.2f) : 0f);
		}

        /// <summary>
        ///     Returns either black or white based on the Luma.
        /// </summary>
        public Chroma ThresholdValue => IsBright ? Black : White;

        /// <summary>
        ///     Returns either the dark or light version of the color based on this color's Luma.
        /// </summary>
        public Chroma GetFontColor(Chroma lightColor, Chroma darkColor) => IsBright ? darkColor : lightColor;

        /// <summary>
        ///     Returns a dark or light version of the color based on this color's Luma.
        /// </summary>
        public Chroma GetFontColor(float tintStrength = 5f) => GetFontColor(this, tintStrength);

        /// <summary>
        ///     Returns with black or white based on this color's Luma.
        /// </summary>
        public static Chroma GetFontColor(Chroma color, float tintStrength = 5f) => color.IsBright
				? color.SetBrightness(5f + tintStrength / 2f).SetSaturation(tintStrength * 2f)
				: color.SetBrightness(95f).SetSaturation(tintStrength                    / 2f);

        /// <summary>
        ///     Lerps between two colors using an easing pattern.
        /// </summary>
        public Chroma Blend(
				Chroma b,
				float t = 0.5f,
				Easing.EType blendType = Easing.EType.Linear,
				Easing.EOperation blendOperation = Easing.EOperation.InOut
		) => Blend(this, b, t, blendType, blendOperation);

        /// <summary>
        ///     Lerps between two colors using an easing pattern.
        /// </summary>
        public Chroma BlendHue(
				Chroma b,
				float t = 0.5f,
				Easing.EType blendType = Easing.EType.Linear,
				Easing.EOperation blendOperation = Easing.EOperation.InOut
		) => new(Blend(this, b, t, blendType, blendOperation).Hue, Saturation, Brightness, Alpha);

        /// <summary>
        ///     Adds the Base color to the RotateTowards color.
        /// </summary>
        public Chroma Add(Color blendColor) => Add(this, blendColor);

        /// <summary>
        ///     Subtracts the RotateTowards color from the Base color.
        /// </summary>
        public Chroma Subtract(Color blendColor) => Subtract(this, blendColor);

        /// <summary>
        ///     Multiplies the Base color and the RotateTowards color.
        /// </summary>
        public Chroma Multiply(Color blendColor) => Multiply(this, blendColor);

        /// <summary>
        ///     Inverts the Base and RotateTowards colors, Multiplies them, then Inverts the result.
        /// </summary>
        public Chroma Screen(Color blendColor) => Screen(this, blendColor);

        /// <summary>
        ///     Multiplies values lower than 0.5f, and performs a Screen operation on values above 0.5f.
        /// </summary>
        public Chroma Overlay(Color blendColor) => Overlay(this, blendColor);

        /// <summary>
        ///     Divides the Base color by the RotateTowards color.
        /// </summary>
        public Chroma Divide(Color blendColor) => Divide(this, blendColor);

        /// <summary>
        ///     Blends between an array of colors to the given percentage.
        /// </summary>
        public static Chroma Gradation(float percentage, params Chroma[] colors) => Gradation(
				percentage,
				Easing.EType.Linear,
				Easing.EOperation.InOut,
				colors
		);

        /// <summary>
        ///     Blends between an array of colors to the given percentage.
        /// </summary>
        public static Chroma Gradation(
				float percentage,
				Easing.EType blendType,
				Easing.EOperation blendOperation,
				params Chroma[] colors
		) {
			percentage = Mathf.Clamp(percentage, 0f, 100f);

			if (colors is not { Length: > 0 }) {
				return Black;
			}

			if (colors is not { Length: > 1 }) {
				return colors[0];
			}

			int   steps  = colors.Length - 1;
			float spread = 100f / steps;
			var   index  = (int)System.Math.Truncate(percentage / spread);

			int bottom = AtLeast(index, 0);
			int top    = AtMost(index + 1 , colors.Length - 1);

			return Blend(
					colors[bottom],
					colors[top],
					Mathf.InverseLerp(spread * bottom, spread * top, percentage),
					blendType,
					blendOperation
			);
		}
		
		public static int AtLeast(int value, int min) => value < min ? min : value;
		public static int AtMost(int value, int max) => value > max ? max : value;

		/// <summary>
        ///     Blends between an array of colors to the given percentage using the RotateTowards method.
        /// </summary>
        public static Chroma GradationRotation(float percentage, params Chroma[] colors) => GradationRotation(
				percentage,
				Easing.EType.Linear,
				Easing.EOperation.InOut,
				colors
		);

        /// <summary>
        ///     Blends between an array of colors to the given percentage using the RotateTowards method.
        /// </summary>
        public static Chroma GradationRotation(
				float percentage,
				Easing.EType blendType,
				Easing.EOperation blendOperation,
				params Chroma[] colors
		) {
			percentage = Mathf.Clamp(percentage, 0f, 100f);

			if (colors is not { Length: > 0 }) {
				return Black;
			}

			if (colors is not { Length: > 1 }) {
				return colors[0];
			}

			int   steps  = colors.Length - 1;
			float spread = 100f / steps;
			var   index  = (int)System.Math.Truncate(percentage / spread);

			int bottom = AtLeast(index, 0);
			int top    = AtMost(index + 1, colors.Length - 1);

			return RotateTowards(
					colors[bottom],
					colors[top],
					Mathf.InverseLerp(spread * bottom, spread * top, percentage),
					blendType,
					blendOperation
			);
		}

        /// <summary>
        ///     Lerps between two colors using an easing pattern.
        /// </summary>
        public static Chroma Blend(
				Chroma a,
				Chroma b,
				float t = 0.5f,
				Easing.EType blendType = Easing.EType.Linear,
				Easing.EOperation blendOperation = Easing.EOperation.InOut
		) {
			t = Mathf.Clamp01(t);

			if (blendOperation == Easing.EOperation.In) {
				return Easing.In(a, b, t, blendType);
			}

			if (blendOperation == Easing.EOperation.Out) {
				return Easing.Out(a, b, t, blendType);
			}

			return Easing.InOut(a, b, t, blendType);
		}

        /// <summary>
        ///     Rotates the Hue and Lerps the Saturation, Brightness and Alpha using an easing pattern.
        /// </summary>
        public static Chroma RotateTowards(
				Chroma a,
				Chroma b,
				float t = 0.5f,
				Easing.EType blendType = Easing.EType.Linear,
				Easing.EOperation blendOperation = Easing.EOperation.InOut
		) {
			t = Mathf.Clamp01(t);

			float hueBlend;
			float saturationBlend;
			float brightnessBlend;
			float alphaBlend;

			if (blendOperation == Easing.EOperation.In) {
				hueBlend        = Easing.In(a._hue, b._hue, t, blendType);
				saturationBlend = Easing.In(a._saturation, b._saturation, t, blendType);
				brightnessBlend = Easing.In(a._brightness, b._brightness, t, blendType);
				alphaBlend      = Easing.In(a._alpha, b._alpha, t, blendType);
			} else if (blendOperation == Easing.EOperation.Out) {
				hueBlend        = Easing.Out(a._hue, b._hue, t, blendType);
				saturationBlend = Easing.Out(a._saturation, b._saturation, t, blendType);
				brightnessBlend = Easing.Out(a._brightness, b._brightness, t, blendType);
				alphaBlend      = Easing.Out(a._alpha, b._alpha, t, blendType);
			} else {
				hueBlend        = Easing.InOut(a._hue, b._hue, t, blendType);
				saturationBlend = Easing.InOut(a._saturation, b._saturation, t, blendType);
				brightnessBlend = Easing.InOut(a._brightness, b._brightness, t, blendType);
				alphaBlend      = Easing.InOut(a._alpha, b._alpha, t, blendType);
			}

			return new Chroma(hueBlend, saturationBlend, brightnessBlend, alphaBlend);
		}

        /// <summary>
        ///     Adds the Base color to the RotateTowards color.
        /// </summary>
        public static Color Add(Color baseColor, Color blendColor) => new(
				baseColor.r + blendColor.r,
				baseColor.g + blendColor.g,
				baseColor.b + blendColor.b,
				baseColor.a
		);

        /// <summary>
        ///     Subtracts the RotateTowards color from the Base color.
        /// </summary>
        public static Color Subtract(Color baseColor, Color blendColor) => new(
				baseColor.r - blendColor.r,
				baseColor.g - blendColor.g,
				baseColor.b - blendColor.b,
				baseColor.a
		);

        /// <summary>
        ///     Multiplies the Base color and the RotateTowards color.
        /// </summary>
        public static Color Multiply(Color baseColor, Color blendColor) => new(
				baseColor.r * blendColor.r,
				baseColor.g * blendColor.g,
				baseColor.b * blendColor.b,
				baseColor.a
		);

        /// <summary>
        ///     Inverts the Base and RotateTowards colors, Multiplies them, then Inverts the result.
        /// </summary>
        public static Color Screen(Color baseColor, Color blendColor) {
			float Calculate(float a, float b) => 1 - ( 1 - a ) * ( 1 - b );

			return new Color(
					Calculate(baseColor.r, blendColor.r),
					Calculate(baseColor.g, blendColor.g),
					Calculate(baseColor.b, blendColor.b),
					baseColor.a
			);
		}

        /// <summary>
        ///     Multiplies values lower than 0.5f, and performs a Screen operation on values above 0.5f.
        /// </summary>
        public static Color Overlay(Color baseColor, Color blendColor) {
			float Calculate(float a, float b) => a < 0.5f ? 2 * ( a * b ) : 1 - 2 * ( 1 - a ) * ( 1 - b );

			return new Color(
					Calculate(baseColor.r, blendColor.r),
					Calculate(baseColor.g, blendColor.g),
					Calculate(baseColor.b, blendColor.b),
					baseColor.a
			);
		}

        /// <summary>
        ///     Divides the Base color by the RotateTowards color.
        /// </summary>
        public static Color Divide(Color baseColor, Color blendColor) => new(
				baseColor.r / blendColor.r,
				baseColor.g / blendColor.g,
				baseColor.b / blendColor.b,
				baseColor.a
		);

        /// <summary>
        ///     Returns a list of colors that include "sets" of tones set at equal-distance hues.
        /// </summary>
        public static List<Chroma> CreateChromaticSwatch(
				int hueCount = 12,
				float hueOffset = 0f,
				int toneCount = 11,
				float saturationMin = 50f,
				float saturationMid = 100f,
				float saturationMax = 25f,
				float brightnessMin = 10f,
				float brightnessMid = 100f,
				float brightnessMax = 100f
		) {
			hueOffset = Loop(hueOffset, 360f);

			var colors = new List<Chroma>();

			for (var i = 0; i < hueCount; i++) {
				float hueStep = 360f / hueCount;
				float hue     = Loop(i * hueStep - hueOffset, 360f);

				int highCount = toneCount % 2 == 0 ? toneCount / 2 : ( toneCount - 1 ) / 2;
				int lowCount  = toneCount % 2 == 0 ? toneCount / 2 : ( toneCount - 1 ) / 2 + 1;

				var high = CreateMonochromeSwatch(
						hue,
						highCount + 1,
						saturationMid,
						saturationMax,
						brightnessMid,
						brightnessMax
				);

				high.Remove(high.LastOrDefault());

				var low = CreateMonochromeSwatch(
						hue,
						lowCount,
						saturationMin,
						saturationMid,
						brightnessMin,
						brightnessMid
				);

				
				colors.AddRange(high);
				colors.AddRange(low);
			}

			return colors;
		}

        /// <summary>
        ///     Returns a list of color in one hue with changes made to Saturation and Brightness.
        /// </summary>
        public static List<Chroma> CreateMonochromeSwatch(
				float hue = 0,
				int tones = 11,
				float saturationMin = 50f,
				float saturationMax = 100f,
				float brightnessMin = 10f,
				float brightnessMax = 100f
		) {
			brightnessMin = Mathf.Clamp(brightnessMin, 0f, 100f);
			brightnessMax = Mathf.Clamp(brightnessMax, 0f, 100f);
			saturationMin = Mathf.Clamp(saturationMin, 0f, 100f);
			saturationMax = Mathf.Clamp(saturationMax, 0f, 100f);

			var colors = new List<Chroma>();

			float satStep = ( saturationMax - saturationMin ) / ( tones - 1 );
			float valStep = ( brightnessMax - brightnessMin ) / ( tones - 1 );

			for (var j = 0; j < tones; j++) {
				float saturation = saturationMax - satStep * j;
				float brightness = brightnessMax - valStep * j;

				colors.Add(new Chroma(hue, saturation, brightness));
			}

			return colors;
		}

        /// <summary>
        ///     Implicit operator.
        /// </summary>
        public static implicit operator Color(Chroma chroma) => chroma.AsColor;

        /// <summary>
        ///     Implicit operator.
        /// </summary>
        public static implicit operator Color32(Chroma color) => color.AsColor;

        /// <summary>
        ///     Implicit operator.
        /// </summary>
        public static implicit operator Chroma(Color color) => new(color);

        /// <summary>
        ///     Implicit operator.
        /// </summary>
        public static implicit operator Chroma(Color32 color) => new(color);

        /// <summary>
        ///     Implicit operator.
        /// </summary>
        public static implicit operator StyleColor(Chroma color) => new(color.AsColor);

        /// <summary>
        ///     Equality operator.
        /// </summary>
        public static bool operator ==(Chroma a, Chroma b) => a.Equals(b);

        /// <summary>
        ///     Equality operator.
        /// </summary>
        public static bool operator !=(Chroma a, Chroma b) => !( a == b );

        /// <summary>
        ///     Equality operator.
        /// </summary>
        public bool Equals(Chroma other) => Hue.Equals(other.Hue) && Saturation.Equals(other.Saturation)
				&& Brightness.Equals(other.Brightness)            && Alpha.Equals(other.Alpha);

        /// <summary>
        ///     Equality operator.
        /// </summary>
        public override bool Equals(object obj) => obj is Chroma other && Equals(other);

        /// <summary>
        ///     HashCode creator.
        /// </summary>
        public override int GetHashCode() => HashCode.Combine(Hue, Saturation, Brightness, Alpha);

        /// <summary>
        ///     String creator.
        /// </summary>
        public override string ToString() => ToString(null, null);

        /// <summary>
        ///     String creator.
        /// </summary>
        public string ToString(string format) => ToString(format, null);

        /// <summary>
        ///     String creator.
        /// </summary>
        public string ToString(string format, IFormatProvider formatProvider) {
			if (string.IsNullOrEmpty(format)) {
				format = "F3";
			}

			formatProvider ??= CultureInfo.InvariantCulture.NumberFormat;

			return
					$"Chroma({Hue.ToString(format, formatProvider)}, {Saturation.ToString(format, formatProvider)}, {Brightness.ToString(format, formatProvider)}, {Alpha.ToString(format, formatProvider)})";
		}
	}

}