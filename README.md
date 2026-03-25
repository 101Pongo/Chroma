# Chroma

An HSB color system for Unity that's designed to be thought in, not just computed with.

## Why I Built This

Unity's built-in `Color` works in RGB, which is great for the GPU but terrible for humans. If I have a red and I want a slightly warmer, darker version of it, I shouldn't have to think about which combination of R, G, and B channels gets me there. I should just say "shift the hue toward orange and drop the brightness."

That's what this package does. `Chroma` is a color struct that works in HSB (Hue, Saturation, Brightness) with values that make sense: hue is 0–360 degrees on a color wheel, saturation and brightness are 0–100 percentages. You think about color the way a designer would — hue, intensity, lightness — and the conversion to Unity's `Color` happens when you need it.

I also wanted a ready-made palette I could grab colors from without constantly eyeballing hex codes. So I built the `Swatch` system: 24 named hues at 15° intervals, each available in 11 intensity variations (pure, vivid, friendly, pastel, dark, muted, etc.), all run through a luminance balancing pass so they look consistently bright to the eye.

## Chroma

The core of the package. It's a serializable struct that converts to and from Unity's `Color`, `Color32`, and hex strings. You can construct one from any of those, or just specify HSB values directly.

The API is built around immutable manipulation — every method returns a new `Chroma` rather than modifying the original. So `myColor.ShiftHue(30f)` gives you a new color 30° around the wheel, `myColor.SetBrightness(50f)` gives you one at half brightness, and you can chain them: `myColor.ShiftHue(15f).SetSaturation(80f).SetAlpha(50f)`.

There's also color harmony support. Given any color, you can get its complementary, split-complementary, triadic, tetradic, or analogous colors — the standard relationships from color theory. These are useful for procedural palette generation or UI theming where you want colors that work together.

Blending supports easing curves (linear, quadratic, cubic, elastic, bounce, etc.) for both full-color blends and hue-only rotation. `Gradation` lets you blend across an array of color stops at a given percentage, which is basically a gradient sampler.

The luminance calculation uses perceptual weighting (not just averaging RGB), so `IsBright`, `IsDark`, and `GetFontColor` give results that match how your eye actually sees the color. `GetBalancedLuminance` compensates for the fact that pure yellow looks way brighter than pure blue at the same HSB brightness — it nudges colors toward a consistent perceived lightness.

## Swatch

A pre-built palette organized as nested static classes: `Swatch.Pure.Azure`, `Swatch.Friendly.Red`, `Swatch.Dark.Violet`, etc.

The 24 hues are spaced at 15° intervals around the color wheel: Red, Vermilion, Orange, Golden, Yellow, Lime, Chartreuse, Harlequin, Green, Erin, Mint, Aquamarine, Cyan, Cerulean, Azure, Cobalt, Blue, Indigo, Violet, Purple, Magenta, Fandango, Rose, Carmine.

Each hue is available in 11 intensity tiers that vary saturation and brightness. The names describe what you'd actually use them for: **Friendly** (80/80 — good for UI), **Vivid** (100/90 — attention-grabbing), **Tinted** (50/100 — pastels), **Toned** (50/45 — muted), **Dark** (100/20 — deep accents), **Pale** (25/100 — barely-there tints), **Shadow** (25/20 — dark theme backgrounds), and so on.

All swatch colors are run through `GetBalancedLuminance` so that, for example, `Swatch.Vivid.Yellow` and `Swatch.Vivid.Blue` look like they belong at the same intensity level, even though raw HSB yellow is perceptually much brighter than raw HSB blue.

## SignalColors and Gray

`SignalColors` maps semantic meanings to swatch colors: `Positive` (green), `Negative` (red), `Warning` (orange), `Info` (blue), `Action`, `Disabled`, etc. These are the colors you'd use for UI feedback without having to pick specific values every time.

`Gray` is a grayscale ramp from black to white in 2.5% brightness increments: `Gray.T000` (black) through `Gray.T1000` (white). Useful for editor UI, debug visuals, or anywhere you need a specific gray without calculating it.

## ColorExtensions

Extension methods on Unity's `Color` for common operations: `WithAlpha`, `WithRed`, `Brighten`, `Darken`, `Invert`, `Grayscale`, `IsBright`/`IsDark`, `GetTextColor`, `ToHex`, `ToVector4`, and component-wise blending. These are the things I got tired of writing inline.

## Structure

```
Runtime/
  Internal/
    Easing.cs           — Easing curves used by Chroma's blend/gradation system.
  Public/
    Chroma.cs           — HSB color struct with manipulation, blending, and conversion.
    Swatch.cs           — 24 hues × 11 intensities, luminance-balanced.
    SignalColors.cs     — Semantic UI colors (positive, negative, warning, etc.).
    Gray.cs             — Grayscale ramp from 0%–100%.
    EditorColors.cs     — Unity editor-specific message and highlight colors.
    ColorExtensions.cs  — Extension methods for Unity's Color type.
```

## Dependencies

Unity only — no third-party packages.
