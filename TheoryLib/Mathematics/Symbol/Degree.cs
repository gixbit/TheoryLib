namespace TheoryLib.Mathematics.Symbol {

   using System;

   /// <summary>
   /// Defines a Degree type to be used in angular calculations. Also interchangeable with <see cref="Radian"/>.
   /// </summary>
   public struct Degree {
      private float deg;

      /// <summary>
      ///
      /// </summary>
      public float Value { get { return this.deg; } private set { this.deg = value; } }

      internal Degree( float d ) {
         this.deg = d;
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="d"></param>
      public static implicit operator float( Degree d ) {
         return d.deg;
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="d"></param>
      public static implicit operator Degree( float d ) {
         return new Degree( d );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="r"></param>
      public static implicit operator Degree( Radian r ) {
         return new Degree( ( float )( ( r * 180 ) / Math.PI ) );
      }

      /// <summary>
      ///
      /// </summary>
      /// <returns></returns>
      public Radian ToRadians() {
         return this;
      }

      /// <summary>
      ///
      /// </summary>
      /// <returns></returns>
      public override string ToString() {
         return string.Format( "T = {0} Degrees" , this.deg );
      }
   }
}