using UnityEngine;

namespace Atlas.Chroma.Runtime.Internal {

    /// <summary>
    ///     Math used for lerping between values using a variety of algorithms.
    /// </summary>
    public static class Easing {
		public enum EOperation {
			In,
			Out,
			InOut
		}

		public enum EType {
			Linear,
			Quadratic,
			Cubic,
			Quartic,
			Quintic,
			Sin,
			Sinusoidal,
			Exponential,
			Circular,
			Elastic,
			Back,
			Bounce
		}

		public static float In(float from, float to, float time, EType type) => type switch {
				EType.Linear      => Mathf.Lerp(from, to, time),
				EType.Quadratic   => Mathf.Lerp(from, to, Quadratic.In(time)),
				EType.Cubic       => Mathf.Lerp(from, to, Cubic.In(time)),
				EType.Quartic     => Mathf.Lerp(from, to, Quartic.In(time)),
				EType.Quintic     => Mathf.Lerp(from, to, Quintic.In(time)),
				EType.Sin         => Mathf.Lerp(from, to, Sin.In(time)),
				EType.Sinusoidal  => Mathf.Lerp(from, to, Sinusoidal.In(time)),
				EType.Exponential => Mathf.Lerp(from, to, Exponential.In(time)),
				EType.Circular    => Mathf.Lerp(from, to, Circular.In(time)),
				EType.Elastic     => Mathf.Lerp(from, to, Elastic.In(time)),
				EType.Back        => Mathf.Lerp(from, to, Back.In(time)),
				EType.Bounce      => Mathf.Lerp(from, to, Bounce.In(time)),
				_                 => Mathf.Lerp(from, to, time)
		};

		public static float Out(float from, float to, float time, EType type) => type switch {
				EType.Linear      => Mathf.Lerp(from, to, time),
				EType.Quadratic   => Mathf.Lerp(from, to, Quadratic.Out(time)),
				EType.Cubic       => Mathf.Lerp(from, to, Cubic.Out(time)),
				EType.Quartic     => Mathf.Lerp(from, to, Quartic.Out(time)),
				EType.Quintic     => Mathf.Lerp(from, to, Quintic.Out(time)),
				EType.Sin         => Mathf.Lerp(from, to, Sin.Out(time)),
				EType.Sinusoidal  => Mathf.Lerp(from, to, Sinusoidal.Out(time)),
				EType.Exponential => Mathf.Lerp(from, to, Exponential.Out(time)),
				EType.Circular    => Mathf.Lerp(from, to, Circular.Out(time)),
				EType.Elastic     => Mathf.Lerp(from, to, Elastic.Out(time)),
				EType.Back        => Mathf.Lerp(from, to, Back.Out(time)),
				EType.Bounce      => Mathf.Lerp(from, to, Bounce.Out(time)),
				_                 => Mathf.Lerp(from, to, time)
		};

		public static float InOut(float from, float to, float time, EType type) => type switch {
				EType.Linear      => Mathf.Lerp(from, to, time),
				EType.Quadratic   => Mathf.Lerp(from, to, Quadratic.InOut(time)),
				EType.Cubic       => Mathf.Lerp(from, to, Cubic.InOut(time)),
				EType.Quartic     => Mathf.Lerp(from, to, Quartic.InOut(time)),
				EType.Quintic     => Mathf.Lerp(from, to, Quintic.InOut(time)),
				EType.Sin         => Mathf.Lerp(from, to, Sin.InOut(time)),
				EType.Sinusoidal  => Mathf.Lerp(from, to, Sinusoidal.InOut(time)),
				EType.Exponential => Mathf.Lerp(from, to, Exponential.InOut(time)),
				EType.Circular    => Mathf.Lerp(from, to, Circular.InOut(time)),
				EType.Elastic     => Mathf.Lerp(from, to, Elastic.InOut(time)),
				EType.Back        => Mathf.Lerp(from, to, Back.InOut(time)),
				EType.Bounce      => Mathf.Lerp(from, to, Bounce.InOut(time)),
				_                 => Mathf.Lerp(from, to, time)
		};

		public static Color In(Color from, Color to, float time, EType type) => type switch {
				EType.Linear      => Color.Lerp(from, to, time),
				EType.Quadratic   => Color.Lerp(from, to, Quadratic.In(time)),
				EType.Cubic       => Color.Lerp(from, to, Cubic.In(time)),
				EType.Quartic     => Color.Lerp(from, to, Quartic.In(time)),
				EType.Quintic     => Color.Lerp(from, to, Quintic.In(time)),
				EType.Sin         => Color.Lerp(from, to, Sin.In(time)),
				EType.Sinusoidal  => Color.Lerp(from, to, Sinusoidal.In(time)),
				EType.Exponential => Color.Lerp(from, to, Exponential.In(time)),
				EType.Circular    => Color.Lerp(from, to, Circular.In(time)),
				EType.Elastic     => Color.Lerp(from, to, Elastic.In(time)),
				EType.Back        => Color.Lerp(from, to, Back.In(time)),
				EType.Bounce      => Color.Lerp(from, to, Bounce.In(time)),
				_                 => Color.Lerp(from, to, time)
		};

		public static Color Out(Color from, Color to, float time, EType type) => type switch {
				EType.Linear      => Color.Lerp(from, to, time),
				EType.Quadratic   => Color.Lerp(from, to, Quadratic.Out(time)),
				EType.Cubic       => Color.Lerp(from, to, Cubic.Out(time)),
				EType.Quartic     => Color.Lerp(from, to, Quartic.Out(time)),
				EType.Quintic     => Color.Lerp(from, to, Quintic.Out(time)),
				EType.Sin         => Color.Lerp(from, to, Sin.Out(time)),
				EType.Sinusoidal  => Color.Lerp(from, to, Sinusoidal.Out(time)),
				EType.Exponential => Color.Lerp(from, to, Exponential.Out(time)),
				EType.Circular    => Color.Lerp(from, to, Circular.Out(time)),
				EType.Elastic     => Color.Lerp(from, to, Elastic.Out(time)),
				EType.Back        => Color.Lerp(from, to, Back.Out(time)),
				EType.Bounce      => Color.Lerp(from, to, Bounce.Out(time)),
				_                 => Color.Lerp(from, to, time)
		};

		public static Color InOut(Color from, Color to, float time, EType type) => type switch {
				EType.Linear      => Color.Lerp(from, to, time),
				EType.Quadratic   => Color.Lerp(from, to, Quadratic.InOut(time)),
				EType.Cubic       => Color.Lerp(from, to, Cubic.InOut(time)),
				EType.Quartic     => Color.Lerp(from, to, Quartic.InOut(time)),
				EType.Quintic     => Color.Lerp(from, to, Quintic.InOut(time)),
				EType.Sin         => Color.Lerp(from, to, Sin.InOut(time)),
				EType.Sinusoidal  => Color.Lerp(from, to, Sinusoidal.InOut(time)),
				EType.Exponential => Color.Lerp(from, to, Exponential.InOut(time)),
				EType.Circular    => Color.Lerp(from, to, Circular.InOut(time)),
				EType.Elastic     => Color.Lerp(from, to, Elastic.InOut(time)),
				EType.Back        => Color.Lerp(from, to, Back.InOut(time)),
				EType.Bounce      => Color.Lerp(from, to, Bounce.InOut(time)),
				_                 => Color.Lerp(from, to, time)
		};

		public static Vector3 In(Vector3 from, Vector3 to, float time, EType type) => type switch {
				EType.Linear      => Vector3.Lerp(from, to, time),
				EType.Quadratic   => Vector3.Lerp(from, to, Quadratic.In(time)),
				EType.Cubic       => Vector3.Lerp(from, to, Cubic.In(time)),
				EType.Quartic     => Vector3.Lerp(from, to, Quartic.In(time)),
				EType.Quintic     => Vector3.Lerp(from, to, Quintic.In(time)),
				EType.Sin         => Vector3.Lerp(from, to, Sin.In(time)),
				EType.Sinusoidal  => Vector3.Lerp(from, to, Sinusoidal.In(time)),
				EType.Exponential => Vector3.Lerp(from, to, Exponential.In(time)),
				EType.Circular    => Vector3.Lerp(from, to, Circular.In(time)),
				EType.Elastic     => Vector3.Lerp(from, to, Elastic.In(time)),
				EType.Back        => Vector3.Lerp(from, to, Back.In(time)),
				EType.Bounce      => Vector3.Lerp(from, to, Bounce.In(time)),
				_                 => Vector3.Lerp(from, to, time)
		};

		public static Vector3 Out(Vector3 from, Vector3 to, float time, EType type) => type switch {
				EType.Linear      => Vector3.Lerp(from, to, time),
				EType.Quadratic   => Vector3.Lerp(from, to, Quadratic.Out(time)),
				EType.Cubic       => Vector3.Lerp(from, to, Cubic.Out(time)),
				EType.Quartic     => Vector3.Lerp(from, to, Quartic.Out(time)),
				EType.Quintic     => Vector3.Lerp(from, to, Quintic.Out(time)),
				EType.Sin         => Vector3.Lerp(from, to, Sin.Out(time)),
				EType.Sinusoidal  => Vector3.Lerp(from, to, Sinusoidal.Out(time)),
				EType.Exponential => Vector3.Lerp(from, to, Exponential.Out(time)),
				EType.Circular    => Vector3.Lerp(from, to, Circular.Out(time)),
				EType.Elastic     => Vector3.Lerp(from, to, Elastic.Out(time)),
				EType.Back        => Vector3.Lerp(from, to, Back.Out(time)),
				EType.Bounce      => Vector3.Lerp(from, to, Bounce.Out(time)),
				_                 => Vector3.Lerp(from, to, time)
		};

		public static Vector3 InOut(Vector3 from, Vector3 to, float time, EType type) => type switch {
				EType.Linear      => Vector3.Lerp(from, to, time),
				EType.Quadratic   => Vector3.Lerp(from, to, Quadratic.InOut(time)),
				EType.Cubic       => Vector3.Lerp(from, to, Cubic.InOut(time)),
				EType.Quartic     => Vector3.Lerp(from, to, Quartic.InOut(time)),
				EType.Quintic     => Vector3.Lerp(from, to, Quintic.InOut(time)),
				EType.Sin         => Vector3.Lerp(from, to, Sin.InOut(time)),
				EType.Sinusoidal  => Vector3.Lerp(from, to, Sinusoidal.InOut(time)),
				EType.Exponential => Vector3.Lerp(from, to, Exponential.InOut(time)),
				EType.Circular    => Vector3.Lerp(from, to, Circular.InOut(time)),
				EType.Elastic     => Vector3.Lerp(from, to, Elastic.InOut(time)),
				EType.Back        => Vector3.Lerp(from, to, Back.InOut(time)),
				EType.Bounce      => Vector3.Lerp(from, to, Bounce.InOut(time)),
				_                 => Vector3.Lerp(from, to, time)
		};

		public static Vector2 In(Vector2 from, Vector2 to, float time, EType type) => type switch {
				EType.Linear      => Vector2.Lerp(from, to, time),
				EType.Quadratic   => Vector2.Lerp(from, to, Quadratic.In(time)),
				EType.Cubic       => Vector2.Lerp(from, to, Cubic.In(time)),
				EType.Quartic     => Vector2.Lerp(from, to, Quartic.In(time)),
				EType.Quintic     => Vector2.Lerp(from, to, Quintic.In(time)),
				EType.Sin         => Vector2.Lerp(from, to, Sin.In(time)),
				EType.Sinusoidal  => Vector2.Lerp(from, to, Sinusoidal.In(time)),
				EType.Exponential => Vector2.Lerp(from, to, Exponential.In(time)),
				EType.Circular    => Vector2.Lerp(from, to, Circular.In(time)),
				EType.Elastic     => Vector2.Lerp(from, to, Elastic.In(time)),
				EType.Back        => Vector2.Lerp(from, to, Back.In(time)),
				EType.Bounce      => Vector2.Lerp(from, to, Bounce.In(time)),
				_                 => Vector2.Lerp(from, to, time)
		};

		public static Vector2 Out(Vector2 from, Vector2 to, float time, EType type) => type switch {
				EType.Linear      => Vector2.Lerp(from, to, time),
				EType.Quadratic   => Vector2.Lerp(from, to, Quadratic.Out(time)),
				EType.Cubic       => Vector2.Lerp(from, to, Cubic.Out(time)),
				EType.Quartic     => Vector2.Lerp(from, to, Quartic.Out(time)),
				EType.Quintic     => Vector2.Lerp(from, to, Quintic.Out(time)),
				EType.Sin         => Vector2.Lerp(from, to, Sin.Out(time)),
				EType.Sinusoidal  => Vector2.Lerp(from, to, Sinusoidal.Out(time)),
				EType.Exponential => Vector2.Lerp(from, to, Exponential.Out(time)),
				EType.Circular    => Vector2.Lerp(from, to, Circular.Out(time)),
				EType.Elastic     => Vector2.Lerp(from, to, Elastic.Out(time)),
				EType.Back        => Vector2.Lerp(from, to, Back.Out(time)),
				EType.Bounce      => Vector2.Lerp(from, to, Bounce.Out(time)),
				_                 => Vector2.Lerp(from, to, time)
		};

		public static Vector2 InOut(Vector2 from, Vector2 to, float time, EType type) => type switch {
				EType.Linear      => Vector2.Lerp(from, to, time),
				EType.Quadratic   => Vector2.Lerp(from, to, Quadratic.InOut(time)),
				EType.Cubic       => Vector2.Lerp(from, to, Cubic.InOut(time)),
				EType.Quartic     => Vector2.Lerp(from, to, Quartic.InOut(time)),
				EType.Quintic     => Vector2.Lerp(from, to, Quintic.InOut(time)),
				EType.Sin         => Vector2.Lerp(from, to, Sin.InOut(time)),
				EType.Sinusoidal  => Vector2.Lerp(from, to, Sinusoidal.InOut(time)),
				EType.Exponential => Vector2.Lerp(from, to, Exponential.InOut(time)),
				EType.Circular    => Vector2.Lerp(from, to, Circular.InOut(time)),
				EType.Elastic     => Vector2.Lerp(from, to, Elastic.InOut(time)),
				EType.Back        => Vector2.Lerp(from, to, Back.InOut(time)),
				EType.Bounce      => Vector2.Lerp(from, to, Bounce.InOut(time)),
				_                 => Vector2.Lerp(from, to, time)
		};

		public static Quaternion In(Quaternion from, Quaternion to, float time, EType type) => type switch {
				EType.Linear      => Quaternion.Lerp(from, to, time),
				EType.Quadratic   => Quaternion.Lerp(from, to, Quadratic.In(time)),
				EType.Cubic       => Quaternion.Lerp(from, to, Cubic.In(time)),
				EType.Quartic     => Quaternion.Lerp(from, to, Quartic.In(time)),
				EType.Quintic     => Quaternion.Lerp(from, to, Quintic.In(time)),
				EType.Sin         => Quaternion.Lerp(from, to, Sin.In(time)),
				EType.Sinusoidal  => Quaternion.Lerp(from, to, Sinusoidal.In(time)),
				EType.Exponential => Quaternion.Lerp(from, to, Exponential.In(time)),
				EType.Circular    => Quaternion.Lerp(from, to, Circular.In(time)),
				EType.Elastic     => Quaternion.Lerp(from, to, Elastic.In(time)),
				EType.Back        => Quaternion.Lerp(from, to, Back.In(time)),
				EType.Bounce      => Quaternion.Lerp(from, to, Bounce.In(time)),
				_                 => Quaternion.Lerp(from, to, time)
		};

		public static Quaternion Out(Quaternion from, Quaternion to, float time, EType type) => type switch {
				EType.Linear      => Quaternion.Lerp(from, to, time),
				EType.Quadratic   => Quaternion.Lerp(from, to, Quadratic.Out(time)),
				EType.Cubic       => Quaternion.Lerp(from, to, Cubic.Out(time)),
				EType.Quartic     => Quaternion.Lerp(from, to, Quartic.Out(time)),
				EType.Quintic     => Quaternion.Lerp(from, to, Quintic.Out(time)),
				EType.Sin         => Quaternion.Lerp(from, to, Sin.Out(time)),
				EType.Sinusoidal  => Quaternion.Lerp(from, to, Sinusoidal.Out(time)),
				EType.Exponential => Quaternion.Lerp(from, to, Exponential.Out(time)),
				EType.Circular    => Quaternion.Lerp(from, to, Circular.Out(time)),
				EType.Elastic     => Quaternion.Lerp(from, to, Elastic.Out(time)),
				EType.Back        => Quaternion.Lerp(from, to, Back.Out(time)),
				EType.Bounce      => Quaternion.Lerp(from, to, Bounce.Out(time)),
				_                 => Quaternion.Lerp(from, to, time)
		};

		public static Quaternion InOut(Quaternion from, Quaternion to, float time, EType type) => type switch {
				EType.Linear      => Quaternion.Lerp(from, to, time),
				EType.Quadratic   => Quaternion.Lerp(from, to, Quadratic.InOut(time)),
				EType.Cubic       => Quaternion.Lerp(from, to, Cubic.InOut(time)),
				EType.Quartic     => Quaternion.Lerp(from, to, Quartic.InOut(time)),
				EType.Quintic     => Quaternion.Lerp(from, to, Quintic.InOut(time)),
				EType.Sin         => Quaternion.Lerp(from, to, Sin.InOut(time)),
				EType.Sinusoidal  => Quaternion.Lerp(from, to, Sinusoidal.InOut(time)),
				EType.Exponential => Quaternion.Lerp(from, to, Exponential.InOut(time)),
				EType.Circular    => Quaternion.Lerp(from, to, Circular.InOut(time)),
				EType.Elastic     => Quaternion.Lerp(from, to, Elastic.InOut(time)),
				EType.Back        => Quaternion.Lerp(from, to, Back.InOut(time)),
				EType.Bounce      => Quaternion.Lerp(from, to, Bounce.InOut(time)),
				_                 => Quaternion.Lerp(from, to, time)
		};

		private static float PowIn(float t, float pow) => Mathf.Pow(t, pow);
		private static float PowOut(float t, float pow) => 1f - Mathf.Pow(1f - t, pow);

		private static float PowInOut(float t, float pow) {
			if (( t *= 2 ) < 1) {
				return 0.5f * Mathf.Pow(t, pow);
			}

			return 1f - 0.5f * Mathf.Abs(Mathf.Pow(2f - t, pow));
		}

		private static class Quadratic {
			public static float In(float t) => PowIn(t, 2);
			public static float Out(float t) => PowOut(t, 2);
			public static float InOut(float t) => PowInOut(t, 2);
		}

		private static class Cubic {
			public static float In(float t) => PowIn(t, 3);
			public static float Out(float t) => PowOut(t, 3);
			public static float InOut(float t) => PowInOut(t, 3);
		}

		private static class Quartic {
			public static float In(float t) => PowIn(t, 4);
			public static float Out(float t) => PowOut(t, 4);
			public static float InOut(float t) => PowInOut(t, 4);
		}

		private static class Quintic {
			public static float In(float t) => PowIn(t, 5);
			public static float Out(float t) => PowOut(t, 5);
			public static float InOut(float t) => PowInOut(t, 5);
		}

		private class Sin {
			public static float In(float t) => 1f - Mathf.Cos(t * Mathf.PI / 2f);
			public static float Out(float t) => Mathf.Sin(t                * Mathf.PI / 2f);
			public static float InOut(float t) => 0.5f * ( Mathf.Cos(Mathf.PI * t) - 1f );
		}

		private class Sinusoidal {
			public static float In(float k) => 1f - Mathf.Cos(k * Mathf.PI / 2f);

			public static float Out(float k) => Mathf.Sin(k * Mathf.PI / 2f);

			public static float InOut(float k) => 0.5f * ( 1f - Mathf.Cos(Mathf.PI * k) );
		}

		private static class Exponential {
			public static float In(float k) => k == 0f ? 0f : Mathf.Pow(1024f, k - 1f);

			public static float Out(float k) => Mathf.Approximately(k, 1f) ? 1f : 1f - Mathf.Pow(2f, -10f * k);

			public static float InOut(float k) {
				if (Mathf.Approximately(k, 0)) {
					return 0f;
				}

				if (Mathf.Approximately(k, 1)) {
					return 1f;
				}

				if (( k *= 2f ) < 1f) {
					return 0.5f * Mathf.Pow(1024f, k - 1f);
				}

				return 0.5f * ( -Mathf.Pow(2f, -10f * ( k - 1f )) + 2f );
			}
		}

		private static class Circular {
			public static float In(float t) => -( Mathf.Sqrt(1 - t * t) - 1 );
			public static float Out(float t) => Mathf.Sqrt(1 - --t * t);

			public static float InOut(float t) {
				if (( t *= 2 ) < 1) {
					return -0.5f * ( Mathf.Sqrt(1 - t * t) - 1 );
				}

				return 0.5f * ( Mathf.Sqrt(1 - ( t -= 2 ) * t) + 1 );
			}
		}

		private static class Elastic {
			private static float GetElasticIn(float t, float amplitude, float period) {
				float pi2 = Mathf.PI * 2;

				if (Mathf.Approximately(t, 0) || Mathf.Approximately(t, 1)) {
					return t;
				}

				float s = period / pi2 * Mathf.Asin(1f / amplitude);

				return -( amplitude * Mathf.Pow(2, 10 * ( t -= 1 )) * Mathf.Sin(( t - s ) * pi2 / period) );
			}

			private static float GetElasticOut(float t, float amplitude, float period) {
				float pi2 = Mathf.PI * 2;

				if (Mathf.Approximately(t, 0) || Mathf.Approximately(t, 1)) {
					return t;
				}

				float s = period / pi2 * Mathf.Asin(1f / amplitude);

				return amplitude * Mathf.Pow(2f, -10f * t) * Mathf.Sin(( t - s ) * pi2 / period) + 1;
			}

			private static float GetElasticInOut(float t, float amplitude, float period) {
				float pi2 = Mathf.PI     * 2;
				float s   = period / pi2 * Mathf.Asin(1f / amplitude);

				if (( t *= 2 ) < 1) {
					return -0.5f * ( amplitude * Mathf.Pow(2, 10 * ( t -= 1 )) * Mathf.Sin(( t - s ) * pi2 / period) );
				}

				return amplitude * Mathf.Pow(2, -10 * ( t -= 1 )) * Mathf.Sin(( t - s ) * pi2 / period) * 0.5f + 1;
			}

			public static float In(float t) => GetElasticIn(t, 1, 0.3f);
			public static float Out(float t) => GetElasticOut(t, 1f, 0.3f);
			public static float InOut(float t) => GetElasticInOut(t, 1f, 0.3f * 1.5f);
		}

		private static class Back {
			private static float GetBackIn(float t, float amount) => t * t * ( ( amount + 1 ) * t - amount );
			private static float GetBackOut(float t, float amount) => --t * t * ( ( amount + 1 ) * t + amount ) + 1;

			private static float GetBackInOut(float t, float amount) {
				amount *= 1.525f;

				if (( t *= 2 ) < 1) {
					return 0.5f * ( t * t * ( amount + 1 ) * t - amount );
				}

				return 0.5f * ( ( t -= 2 ) * t * ( ( amount + 1 ) * t + amount ) + 2 );
			}

			public static float In(float t) => GetBackIn(t, 1.7f);
			public static float Out(float t) => GetBackOut(t, 1.7f);
			public static float InOut(float t) => GetBackInOut(t, 1.7f);
		}

		private static class Bounce {
			public static float In(float t) => 1f - Out(1f - t);

			public static float Out(float t) {
				if (t < 1f / 2.75f) {
					return 7.5625f * t * t;
				}

				if (t < 2 / 2.75f) {
					return 7.5625f * ( t -= 1.5f / 2.75f ) * t + 0.75f;
				}

				if (t < 2.5 / 2.75) {
					return 7.5625f * ( t -= 2.25f / 2.75f ) * t + 0.9375f;
				}

				return 7.5625f * ( t -= 2.625f / 2.75f ) * t + 0.984375f;
			}

			public static float InOut(float t) {
				if (t < 0.5f) {
					return In(t * 2) * 0.5f;
				}

				return Out(t * 2 - 1) * 0.5f + 0.5f;
			}
		}
	}

}