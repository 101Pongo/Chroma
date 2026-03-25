using UnityEngine;

namespace Atlas.Chroma.Runtime.Public {

	/// <summary>
	///     Editor-specific colors for messages and highlights
	/// </summary>
	public static class EditorColors {
		/// <summary>
		///     Information message border color
		/// </summary>
		public static Chroma InfoBorder => new Color32(40, 180, 220, 255);

		/// <summary>
		///     Information message fill color
		/// </summary>
		public static Chroma InfoFill => new Color32(30, 120, 190, 255);

		/// <summary>
		///     Warning message border color
		/// </summary>
		public static Chroma WarningBorder => new Color32(220, 180, 40, 255);

		/// <summary>
		///     Warning message fill color
		/// </summary>
		public static Chroma WarningFill => new Color32(190, 120, 30, 255);

		/// <summary>
		///     Error message border color
		/// </summary>
		public static Chroma ErrorBorder => new Color32(190, 40, 40, 255);

		/// <summary>
		///     Error message fill color
		/// </summary>
		public static Chroma ErrorFill => new Color32(110, 30, 30, 255);

		/// <summary>
		///     Selection highlight fill color
		/// </summary>
		public static Chroma HighlightFill => new Color32(70, 96, 124, 255);

		/// <summary>
		///     Selection highlight border color
		/// </summary>
		public static Chroma HighlightBorder => new Color32(110, 180, 255, 255);
	}

}