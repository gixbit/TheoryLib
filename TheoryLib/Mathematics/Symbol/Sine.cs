namespace TheoryLib.Mathematics.Symbol {

   /// <summary>
   /// Representation of a Cosine value;
   /// </summary>
   public struct Sine {
      private float s;

      /// <summary>
      /// The value of cosine
      /// </summary>
      public float Value { get { return this.s; } private set { this.s = value; } }

      #region Implicit/Explicit Overloads

      /// <summary>
      /// Implicit cast from float to Sine
      /// </summary>
      /// <param name="f">float</param>
      /// <exception cref="System.ArgumentException">Must be within -1 &lt;= X &lt;= 1</exception>
      public static implicit operator Sine( float f ) {
         return new Sine( f );
      }

      /// <summary>
      /// Implicit cast from Radian to Sine
      /// </summary>
      /// <param name="R">Radian</param>
      public static implicit operator Sine( Radian R ) {
         return Function.Sin( R.Value );
      }

      /// <summary>
      /// Implicit cast to double from Sine
      /// </summary>
      /// <param name="S">Sine</param>
      public static implicit operator double( Sine S ) {
         return S.s;
      }

      /// <summary>
      /// Implicit cast to float from Sine
      /// </summary>
      /// <param name="S">Sine</param>
      public static implicit operator float( Sine S ) {
         return S.s;
      }

      /// <summary>
      /// Explicit cast from double to Sine
      /// </summary>
      /// <param name="f">double</param>
      /// <exception cref="System.ArgumentException">Must be within -1 &lt;= X &lt;= 1</exception>
      public static explicit operator Sine( double f ) {
         return ( float )f;
      }

      #endregion Implicit/Explicit Overloads

      internal Sine( float f ) {
         if( System.Math.Abs( f ) > 1f ) {
            throw new System.ArgumentException( string.Format( "Value [{0}], must be less than equal to |1|" , f ) );
         } else {
            this.s = f;
         }
      }

      /// <summary>
      /// String representation of Sine
      /// </summary>
      /// <returns>Formatted String</returns>
      public override string ToString() {
         return string.Format( "Sin T = {0}" , this.s );
      }
   }
}