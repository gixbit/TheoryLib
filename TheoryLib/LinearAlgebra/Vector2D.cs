namespace TheoryLib.LinearAlgebra {

   using System;
   using System.Linq;

   /// <summary>
   /// 2-Space Vector struct
   /// </summary>
   public struct Vector2D {
      #region R2 Constant Vectors

      private static Vector2D z = new Vector2D(0,0);
      private static Vector2D n = new Vector2D(0,1);
      private static Vector2D s = new Vector2D(0,-1);
      private static Vector2D w = new Vector2D(-1,0);
      private static Vector2D e = new Vector2D(1,0);

      /// <summary>
      /// 2-Space Vector&lt;0,0&gt;
      /// </summary>
      public static Vector2D Zero { get { return z; } }

      /// <summary>
      /// 2-Space Vector&lt;0,1&gt;
      /// </summary>
      public static Vector2D North { get { return n; } }

      /// <summary>
      /// 2-Space Vector&lt;0,-1&gt;
      /// </summary>
      public static Vector2D South { get { return s; } }

      /// <summary>
      /// 2-Space Vector&lt;-1,0&gt;
      /// </summary>
      public static Vector2D West { get { return w; } }

      /// <summary>
      /// 2-Space Vector&lt;1,0&gt;
      /// </summary>
      public static Vector2D East { get { return e; } }

      #endregion R2 Constant Vectors

      #region R2 Vector Properties and Instance Variables

      private float[] component;
      private float mag;

      /// <summary>
      /// 2-Space Vector Magnitude
      /// </summary>
      public float Magnitude { get { return this.mag; } private set { this.mag = value; } }

      /// <summary>
      /// 2-Space UnitVector Representation of the current Vector
      /// </summary>
      public Vector2D UnitVector { get { return this / this.Magnitude; } }

      /// <summary>
      /// 2-Space Components
      /// </summary>
      public float[ ] Components { get { return this.component; } }

      /// <summary>
      /// 2-Space X Quantity
      /// </summary>
      public float X { get { return component[ 0 ]; } set { this.component[ 0 ] = value; Magnitude2D( X , Y ); } }

      /// <summary>
      /// 2-Space Y Quantity
      /// </summary>
      public float Y { get { return component[ 1 ]; } set { this.component[ 1 ] = value; Magnitude2D( X , Y ); } }

      #endregion R2 Vector Properties and Instance Variables

      #region R2 Overloaded Operators

      /// <summary>
      /// 2-Space Vector Addition
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator +( Vector2D A , Vector2D B ) {
         return new Vector2D( IFunction.Template<float , float>.SelectFromBoth( A.component , B.component , ( X , Y ) => X + Y ).ToArray() );
      }

      /// <summary>
      /// 2-Space Vector Substraction
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator -( Vector2D A , Vector2D B ) {
         return new Vector2D( IFunction.Template<float , float>.SelectFromBoth( A.component , B.component , ( X , Y ) => X - Y ).ToArray() );
      }

      /// <summary>
      /// 2-Space Negation
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator -( Vector2D A ) {
         return new Vector2D( A.X * -1.0f , A.Y * -1.0f );
      }

      /// <summary>
      /// 2-Space Scalar Quantity
      /// </summary>
      /// <param name="A">float</param>
      /// <param name="B">Vector2D</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator *( float A , Vector2D B ) {
         return new Vector2D( A * B.X , A * B.Y );
      }

      /// <summary>
      /// 2-Space Scalar Quantity
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">float</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator *( Vector2D A , float B ) {
         return B * A;
      }

      /// <summary>
      /// 2-Space Scalar Quantity
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">float</param>
      /// <returns>Vector2D</returns>
      public static Vector2D operator /( Vector2D A , float B ) {
         return A * ( 1 / B );
      }

      /// <summary>
      /// 2-Space Dot Product
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>float</returns>
      public static float operator *( Vector2D A , Vector2D B ) {
         return IFunction.Template<float>.AccumulateFromBoth( A.component , B.component , ( C , X , Y ) => C + ( X * Y ) );
      }

      /// <summary>
      /// 2-Space Equality
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>bool</returns>
      public static bool operator ==( Vector2D A , Vector2D B ) {
         return ( A.X == B.X ) && ( A.Y == B.Y );
      }

      /// <summary>
      /// 2-Space Inequality
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>bool</returns>
      public static bool operator !=( Vector2D A , Vector2D B ) {
         return ( A.X != B.X ) && ( A.Y != B.Y );
      }

      #endregion R2 Overloaded Operators

      #region R2 UnityEngine Vector Implicit Conversion

      /// <summary>
      /// Implicit conversion from <see cref="Vector2D"/> to <see cref="UnityEngine.Vector2"/>
      /// </summary>
      /// <param name="A">Vector2D</param>
      public static implicit operator UnityEngine.Vector2( Vector2D A ) {
         return new UnityEngine.Vector2( A.X , A.Y );
      }

      /// <summary>
      /// Implicit conversion from <see cref="UnityEngine.Vector2"/> to <see cref="Vector2D"/>
      /// </summary>
      /// <param name="A">UnityEngine.Vector2 </param>
      public static implicit operator Vector2D( UnityEngine.Vector2 A ) {
         return new Vector2D( A.x , A.y );
      }

      #endregion R2 UnityEngine Vector Implicit Conversion

      /// <summary>
      /// Constructor for a 2-Space Vector
      /// </summary>
      /// <param name="x">float</param>
      /// <param name="y">float</param>
      public Vector2D( float x , float y ) {
         this.component = new float[ ] { x , y };
         this.mag = Magnitude2D( x , y );
      }

      /// <summary>
      /// Constructor for a 2-Space Vector
      /// </summary>
      /// <param name="Components">float[]</param>
      /// <exception cref="System.ArgumentException">Throws Exception with wrong number of components</exception>
      public Vector2D( float[ ] Components ) {
         if( Components.Length > 2 ) {
            throw new System.ArgumentException( "Incorrect number of Components" );
         } else {
            this.component = Components;
            this.mag = Magnitude2D( this.component[ 0 ] , this.component[ 1 ] );
         }
      }

      internal Vector2D( ref float x , ref float y ) {
         this.component = new float[ ] { x , y };
         this.mag = Magnitude2D( x , y );
      }

      /// <summary>
      /// Returns the 3-Space equivalent of the current 2-Space Vector
      /// <para/> Vector2D&lt;X,Y&gt; -> Vector3D&lt;X,0,Y&gt;
      /// </summary>
      /// <returns>Vector3D</returns>
      public Vector3D ToR3() {
         return new Vector3D( X , 0 , Y );
      }

      /// <summary>
      /// Determinant of two 2-Space vectors
      /// <para /> Returns (A.X*B.Y) - (A.Y*B.X)
      /// </summary>
      /// <param name="A">Vector2D</param>
      /// <param name="B">Vector2D</param>
      /// <returns>float</returns>
      public static float Determinant( Vector2D A , Vector2D B ) {
         return A.Determinant( B );
      }

      /// <summary>
      /// Determinant in relation to another 2-Space vector
      /// </summary>
      /// <param name="B">Vector2D</param>
      /// <returns>float</returns>
      public float Determinant( Vector2D B ) {
         return Mathematics.Function.Determinant( this , B );
      }

      private static float Magnitude2D( float A , float B ) {
         return ( float )Math.Sqrt( Math.Pow( A , 2 ) + Math.Pow( B , 2 ) );
      }

      /// <summary>
      /// Equality comparison of an object
      /// </summary>
      /// <param name="obj">object</param>
      /// <returns>bool</returns>
      public override bool Equals( object obj ) {
         Vector2D Other = Zero;
         if( obj is Vector2D ) {
            Other = ( Vector2D )obj;
         } else return false;
         return this == Other;
      }

      /// <summary>
      /// Returns the HashCode of the object
      /// </summary>
      /// <returns>int</returns>
      public override int GetHashCode() {
         return base.GetHashCode();
      }

      /// <summary>
      /// String representation of a 2-Space Vector
      /// </summary>
      /// <returns>Formatted String</returns>
      public override string ToString() {
         return string.Format( "Vector2D[x={0},y={1}]" , X , Y );
      }
   }
}