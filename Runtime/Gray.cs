namespace Atlas.Chroma.Runtime.Public {

    /// <summary>
    ///     Grayscale palette from black (0%) to white (100%) in 2.5% increments
    /// </summary>
    public static class Gray {
		/// <summary>Black (0%)</summary>
		public static Chroma T000 => Chroma.Graytone(0f);
		/// <summary>Nearly black (2.5%)</summary>
		public static Chroma T025 => Chroma.Graytone(2.5f);
		/// <summary>Very dark gray (5%)</summary>
		public static Chroma T050 => Chroma.Graytone(5f);
		/// <summary>Dark gray (10%)</summary>
		public static Chroma T100 => Chroma.Graytone(10f);
		/// <summary>Dark gray (15%)</summary>
		public static Chroma T150 => Chroma.Graytone(15f);
		/// <summary>Dark gray (20%)</summary>
		public static Chroma T200 => Chroma.Graytone(20f);
		/// <summary>Dark gray (25%)</summary>
		public static Chroma T250 => Chroma.Graytone(25f);
		/// <summary>Medium-dark gray (30%)</summary>
		public static Chroma T300 => Chroma.Graytone(30f);
		/// <summary>Medium-dark gray (35%)</summary>
		public static Chroma T350 => Chroma.Graytone(35f);
		/// <summary>Medium-dark gray (40%)</summary>
		public static Chroma T400 => Chroma.Graytone(40f);
		/// <summary>Medium-dark gray (45%)</summary>
		public static Chroma T450 => Chroma.Graytone(45f);
		/// <summary>Medium gray (50%)</summary>
		public static Chroma T500 => Chroma.Graytone();
		/// <summary>Medium-light gray (55%)</summary>
		public static Chroma T550 => Chroma.Graytone(55f);
		/// <summary>Medium-light gray (60%)</summary>
		public static Chroma T600 => Chroma.Graytone(60f);
		/// <summary>Medium-light gray (65%)</summary>
		public static Chroma T650 => Chroma.Graytone(65f);
		/// <summary>Light gray (70%)</summary>
		public static Chroma T700 => Chroma.Graytone(70f);
		/// <summary>Light gray (75%)</summary>
		public static Chroma T750 => Chroma.Graytone(75f);
		/// <summary>Light gray (80%)</summary>
		public static Chroma T800 => Chroma.Graytone(80f);
		/// <summary>Very light gray (85%)</summary>
		public static Chroma T850 => Chroma.Graytone(85f);
		/// <summary>Very light gray (90%)</summary>
		public static Chroma T900 => Chroma.Graytone(90f);
		/// <summary>Nearly white (95%)</summary>
		public static Chroma T950 => Chroma.Graytone(95f);
		/// <summary>Nearly white (97.5%)</summary>
		public static Chroma T975 => Chroma.Graytone(97.5f);
		/// <summary>White (100%)</summary>
		public static Chroma T1000 => Chroma.Graytone(100f);
	}

}