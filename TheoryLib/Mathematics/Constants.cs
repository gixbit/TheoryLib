namespace TheoryLib.Mathematics {

   using System;

   /// <summary>
   /// This class is used to define constants for gravity, etc.
   /// </summary>
   public static class Constants {
      private static float G = (float)(6.67408E-11); // Gravitational Constant; Cannot be altered
      private static float m = (float)(5.972E+24); // Mass Constant
      private static float r = (float)(6.371E+6); // Radius Constant

      /// <summary>
      /// Returns the gravity based on the values given to the class <see cref="Constants"/>
      /// <para>Default Constants:</para>
      /// <para />Mass = 5.972E+24
      /// <para />Radius = 6.371E+6
      /// <para />Gravitational Constant = 6.67408E-11
      /// </summary>
      public static float Gravity { get { return -Grav(); } }

      /// <summary>
      /// Mass variable for the object influencing gravity
      /// </summary>
      public static float Mass { get { return m; } set { m = value; } }

      /// <summary>
      /// Radius variable for the object influencing gravity;
      /// </summary>
      public static float Radius { get { return r; } set { r = value; } }

      /// <summary>
      /// Function for calculating gravity derived from the constants in <see cref="Constants"/> obtained from the property used by <seealso cref="Gravity"/>
      /// </summary>
      private static Func<float> Grav = () => {
         return G * (m / (float) Math.Pow(r, 2));
      };

      /// <summary>
      /// This method returns the constants to their original defined state.
      /// </summary>
      public static void Reset() {
         m = ( float )( 5.972E+24 );
         r = ( float )( 6.371E+6 );
      }
   }
}