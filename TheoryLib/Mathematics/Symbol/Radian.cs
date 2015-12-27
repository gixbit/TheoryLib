namespace TheoryLib.Mathematics.Symbol {

   using System;

   /// <summary>
   /// Defines a Radian type to be used in angular calculations. Also interchangeable with <see cref="Degree"/>.
   /// </summary>
   public struct Radian {
      private float rad;

      /// <summary>
      /// The floating point value of this radian type
      /// </summary>
      public float Value { get { return this.rad; } private set { this.rad = value; } }

      internal Radian( float d ) {
         this.rad = d;
      }

      /// <summary>
      /// Implicit Radian to float conversion
      /// </summary>
      /// <param name="r">Radian</param>
      public static implicit operator float( Radian r ) {
         return r.rad;
      }

      /// <summary>
      /// Implicit float to Radian conversion
      /// </summary>
      /// <param name="d"></param>
      public static implicit operator Radian( float d ) {
         return new Radian( d );
      }

      /// <summary>
      /// Explicit Radian to Degree conversion
      /// </summary>
      /// <param name="d"></param>
      public static implicit operator Radian( Degree d ) {
         return new Radian( ( float )( ( d / 180 ) * Math.PI ) );
      }

      /// <summary>
      /// Convert to degrees from radians
      /// </summary>
      /// <returns></returns>
      public Degree ToDegrees() {
         return this;
      }

      /// <summary>
      /// String representation of Radians
      /// </summary>
      /// <returns>string</returns>
      public override string ToString() {
         return string.Format( "T = {0} Rads" , this.rad );
      }
   }
}