namespace TheoryLib.LinearAlgebra {

   using Mathematics.Symbol;
   using System;
   using System.Linq;

   /// <summary>
   /// Definition of a 3-Space Vector
   /// </summary>
   public struct Vector3D {
      #region R3 Constant Vectors

      private static Vector3D z = new Vector3D(0,0,0);
      private static Vector3D u = new Vector3D(0,1,0);
      private static Vector3D d = new Vector3D(0,-1,0);
      private static Vector3D w = new Vector3D(-1,0,0);
      private static Vector3D e = new Vector3D(1,0,0);
      private static Vector3D n = new Vector3D(0,0,1);
      private static Vector3D s = new Vector3D(0,0,-1);

      /// <summary>
      /// 3-Space Zero Quantity Vector&lt;0,0,0&gt;
      /// </summary>
      public static Vector3D Zero { get { return z; } }

      /// <summary>
      /// 3-Space Vector&lt;0,1,0&gt;
      /// </summary>
      public static Vector3D Up { get { return u; } }

      /// <summary>
      /// 3-Space Vector&lt;0,-1,0&gt;
      /// </summary>
      public static Vector3D Down { get { return d; } }

      /// <summary>
      /// 3-Space Vector&lt;-1,0,0&gt;
      /// </summary>
      public static Vector3D West { get { return w; } }

      /// <summary>
      /// 3-Space Vector&lt;1,0,0&gt;
      /// </summary>
      public static Vector3D East { get { return e; } }

      /// <summary>
      /// 3-Space Vector&lt;0,0,1&gt;
      /// </summary>
      public static Vector3D North { get { return n; } }

      /// <summary>
      /// 3-Space Vector&lt;0,0,-1&gt;
      /// </summary>
      public static Vector3D South { get { return s; } }

      #endregion R3 Constant Vectors

      #region R3 Vector Properties and Instance Variables

      private float[] component;
      private float mag;

      /// <summary>
      /// 3-Space Vector Magnitude (or Distance) Value
      /// </summary>
      public float Magnitude { get { return this.mag; } private set { this.mag = value; } }

      /// <summary>
      /// 3-Space UnitVector equivalent of the current 3-Space Vector
      /// </summary>
      public Vector3D UnitVector { get { return this / this.Magnitude; } }

      /// <summary>
      /// 3-Space Components
      /// </summary>
      public float[ ] Components { get { return this.component; } }

      /// <summary>
      /// X-Value of the 3-Space Vector
      /// </summary>
      public float X { get { return this.component[ 0 ]; } set { this.component[ 0 ] = value; this.mag = Magnitude3D( X , Y , Z ); } }

      /// <summary>
      /// Y-Value of the 3-Space Vector
      /// </summary>
      public float Y { get { return this.component[ 1 ]; } set { this.component[ 1 ] = value; this.mag = Magnitude3D( X , Y , Z ); } }

      /// <summary>
      /// Z-Value of the 3-Space Vector
      /// </summary>
      public float Z { get { return this.component[ 2 ]; } set { this.component[ 2 ] = value; this.mag = Magnitude3D( X , Y , Z ); } }

      #endregion R3 Vector Properties and Instance Variables

      #region R3 Overloaded Operators

      /// <summary>
      /// 3-Space Vector Addition
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">Vector3D</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator +( Vector3D A , Vector3D B ) {
         return new Vector3D( IFunction.Template<float , float>.SelectFromBoth( A.component , B.component , ( X , Y ) => X + Y ).ToArray() );
      }

      /// <summary>
      /// 3-Space Vector Subtraction
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator -( Vector3D A ) {
         return new Vector3D( -A.X , -A.Y , -A.Z );
      }

      /// <summary>
      /// 3-Space Vector Subtraction
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">Vector3D</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator -( Vector3D A , Vector3D B ) {
         return new Vector3D( A.X - B.X , A.Y - B.Y , A.Z - B.Z );
      }

      /// <summary>
      /// 3-Space Scalar Quantity
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">float</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator *( Vector3D A , float B ) {
         return new Vector3D( A.X * B , A.Y * B , A.Z * B );
      }

      /// <summary>
      /// 3-Space Scalar Quantity
      /// </summary>
      /// <param name="A">float</param>
      /// <param name="B">Vector3D</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator *( float A , Vector3D B ) {
         return B * A;
      }

      /// <summary>
      /// 3-Space Scalar Quantity
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">float</param>
      /// <returns>Vector3D</returns>
      public static Vector3D operator /( Vector3D A , float B ) {
         return A * ( 1 / B );
      }

      /// <summary>
      /// 3-Space Dot Product
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">Vector3D</param>
      /// <returns>float</returns>
      public static float operator *( Vector3D A , Vector3D B ) {
         return IFunction.Template<float>.AccumulateFromBoth( A.component , B.component , ( C , X , Y ) => C + ( X * Y ) );
      }

      /// <summary>
      /// 3-Space Equality
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">Vector3D</param>
      /// <returns>Vector3D</returns>
      public static bool operator ==( Vector3D A , Vector3D B ) {
         return ( A.X == B.X ) && ( A.Y == B.Y ) && ( A.Z == B.Z );
      }

      /// <summary>
      /// 3-Space Inequality
      /// </summary>
      /// <param name="A">Vector3D</param>
      /// <param name="B">Vector3D</param>
      /// <returns>bool</returns>
      public static bool operator !=( Vector3D A , Vector3D B ) {
         return ( A.X != B.X ) && ( A.Y != B.Y ) && ( A.Z != B.Z );
      }

      #endregion R3 Overloaded Operators

      #region R3 UnityEngine Vector Implicit Conversion

      /// <summary>
      /// Implicit conversion from <see cref="UnityEngine.Vector3"/> to <see cref="Vector3D"/>
      /// </summary>
      /// <param name="A">UnityEngine.Vector3</param>
      public static implicit operator Vector3D( UnityEngine.Vector3 A ) {
         return new Vector3D( A.x , A.y , A.z );
      }

      /// <summary>
      /// Implicit conversion from <see cref="Vector3D"/> to <see cref="UnityEngine.Vector3"/>
      /// </summary>
      /// <param name="A">Vector3D</param>
      public static implicit operator UnityEngine.Vector3( Vector3D A ) {
         return new UnityEngine.Vector3( A.X , A.Y , A.Z );
      }

      #endregion R3 UnityEngine Vector Implicit Conversion

      /// <summary>
      /// 3-Space Vector Constructor with a 2-Space vector. The Y-Quantity is shifted to the Z-Axis
      /// </summary>
      /// <param name="v"></param>
      /// <param name="y"></param>
      public Vector3D( Vector2D v , float y ) {
         this.component = new float[ 3 ] { v.X , y , v.Y };
         this.mag = Magnitude3D( v.X , y , v.Y );
      }

      /// <summary>
      /// 3-Space Vector Constructor
      /// </summary>
      /// <param name="x">float</param>
      /// <param name="y">float</param>
      /// <param name="z">float</param>
      public Vector3D( float x , float y , float z ) {
         this.component = new float[ 3 ] { x , y , z };
         this.mag = Magnitude3D( x , y , z );
      }

      /// <summary>
      /// Constructor for a 3-Space Vector
      /// </summary>
      /// <param name="Components">float[]</param>
      /// <exception cref="System.ArgumentException">Throws Exception with wrong number of components</exception>
      public Vector3D( float[ ] Components ) {
         if( Components.Length > 3 ) {
            throw new System.ArgumentException( "Incorrect number of Components" );
         } else {
            this.component = Components;
            this.mag = Magnitude3D( this.component[ 0 ] , this.component[ 1 ] , this.component[ 2 ] );
         }
      }

      internal Vector3D( ref float x , ref float y , ref float z ) {
         this.component = new float[ 3 ] { x , y , z };
         this.mag = Magnitude3D( x , y , z );
      }

      /// <summary>
      /// 3-Space Vector to 2-Space Vector excluding one of the components
      /// </summary>
      /// <param name="V">Variable</param>
      /// <returns>Vector2D</returns>
      public Vector2D ToR2Exclude( Variable V ) {
         switch( V ) {
            case Variable.X:
               return new Vector2D( ref this.component[ 1 ] , ref this.component[ 2 ] );

            case Variable.Y:
               return new Vector2D( ref this.component[ 0 ] , ref this.component[ 2 ] );

            case Variable.Z:
               return new Vector2D( ref this.component[ 0 ] , ref this.component[ 1 ] );

            default:
               return Vector2D.Zero;
         }
      }

      /// <summary>
      /// Returns the 3-Space Vector that is orthogonal to both the parameter Vectors
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Vector3D CrossProduct( Vector3D A , Vector3D B ) {
         return A.CrossProduct( B );
      }

      /// <summary>
      /// Returns the 3-Space Vector that is orthogonal to both itself and the parameter Vector
      /// </summary>
      /// <param name="B">Vector3D</param>
      /// <returns>Vector3D</returns>
      public Vector3D CrossProduct( Vector3D B ) {
         //              |  i  |  j  |  k  |
         //              |-----+-----+-----|
         //  C = A X B = | A_X | A_Y | A_Z | = (Ay*Bz-By*Az)i-(Ax*Bz-Bx*Az)j+(Ax*By-Bx*Ay)k = C<i,j,k>
         //              |-----+-----+-----|
         //  C = A X B = | B_X | B_Y | B_Z | = (Ay*Bz-Az*By)i+(Az*Bx-Ax*By)j+(Ax*By-Ay*Bx)k = C<i,j,k>
         //              |-----------------|
         return new Vector3D(
             this.ToR2Exclude( Variable.X ).Determinant( B.ToR2Exclude( Variable.X ) ) ,
            -this.ToR2Exclude( Variable.Y ).Determinant( B.ToR2Exclude( Variable.Y ) ) ,
             this.ToR2Exclude( Variable.Z ).Determinant( B.ToR2Exclude( Variable.Z ) )
            );
      }

      private static float Magnitude3D( float x , float y , float z ) {
         return ( float )Math.Sqrt( Math.Pow( x , 2 ) + Math.Pow( y , 2 ) + Math.Pow( z , 2 ) );
      }

      /// <summary>
      /// Equality comparison of an object
      /// </summary>
      /// <param name="obj">obj</param>
      /// <returns>bool</returns>
      public override bool Equals( object obj ) {
         Vector3D Other = Zero;
         if( obj is Vector3D ) {
            Other = ( Vector3D )obj;
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
      /// String representation of a 3-Space Vector
      /// </summary>
      /// <returns>string</returns>
      public override string ToString() {
         return string.Format( "Vector3D[x={0},y={1},z={2}]" , this.X , this.Y , this.Z );
      }
   }
}