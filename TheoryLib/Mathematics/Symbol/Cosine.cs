namespace TheoryLib.Mathematics.Symbol {

   /// <summary>
   /// Representation of a Cosine value;
   /// </summary>
   public struct Cosine {
      private float c;

      /// <summary>
      /// The value of cosine
      /// </summary>
      public float Value { get { return this.c; } private set { this.c = value; } }

      #region Implicit/Explicit Overloads

      /// <summary>
      /// Implicit cast from float to Cosine
      /// </summary>
      /// <param name="f">float</param>
      /// <exception cref="System.ArgumentException">Must be within -1 &lt;= X &lt;= 1</exception>
      public static implicit operator Cosine( float f ) {
         return new Cosine( f );
      }

      /// <summary>
      /// Explicit cast from double to Cosine
      /// </summary>
      /// <param name="f">double</param>
      /// <exception cref="System.ArgumentException">Must be within -1 &lt;= X &lt;= 1</exception>
      public static explicit operator Cosine( double f ) {
         return ( float )f;
      }

      /// <summary>
      /// Implicit cast from Radian to Cosine
      /// </summary>
      /// <param name="R">Radian</param>
      public static implicit operator Cosine( Radian R ) {
         return Function.Cos( R.Value );
      }

      /// <summary>
      /// Implicit cast to double from Cosine
      /// </summary>
      /// <param name="C"></param>
      public static implicit operator double( Cosine C ) {
         return C.c;
      }

      /// <summary>
      /// Implicit cast to float from Cosine
      /// </summary>
      /// <param name="C">Cosine</param>
      public static implicit operator float( Cosine C ) {
         return C.c;
      }

      #endregion Implicit/Explicit Overloads

      internal Cosine( float f ) {
         if( System.Math.Abs( f ) > 1f ) {
            throw new System.ArgumentException( string.Format( "Value [{0}], must be less than equal to |1|" , f ) );
         } else {
            this.c = f;
         }
      }

      /// <summary>
      /// String representation of Cosine
      /// </summary>
      /// <returns>Formatted String</returns>
      public override string ToString() {
         return string.Format( "Cos T = {0}" , this.c );
      }
   }
}