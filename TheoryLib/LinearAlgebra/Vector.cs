namespace TheoryLib.LinearAlgebra {

   using Mathematics;
   using Physics;

   /// <summary>
   /// This class is for impliciting finding the Vector of a <see cref="Vector2D"/> or <see cref="Vector3D"/>.
   /// </summary>
   public class Vector {
      private object v;
      private NSpace n;

      /// <summary>
      /// The Magnitude of the Vector
      /// </summary>
      public float Value {
         get {
            switch( n ) {
               case ( NSpace.R2 ):
                  return ( ( Vector2D )v ).Magnitude;

               case ( NSpace.R3 ):
                  return ( ( Vector3D )v ).Magnitude;

               default:
                  return 0f;
            }
         }
      }

      /// <summary>
      /// Returns the N-Space enumerated value of the Vector
      /// </summary>
      public NSpace N { get { return this.n; } private set { this.n = value; } }

      internal Vector( object V , NSpace NS ) {
         this.v = V;
         this.n = NS;
      }

      /// <summary>
      /// Implicit cast Vector to float
      /// </summary>
      /// <param name="V">Vector</param>
      public static implicit operator float( Vector V ) {
         return V.Value;
      }

      /// <summary>
      /// Implicit cast Vector to Velocity
      /// </summary>
      /// <param name="V"></param>
      public static implicit operator Velocity( Vector V ) {
         return new Velocity( V.v , V.N );
      }

      #region 2-Space Overloads

      /// <summary>
      /// Implicit cast Vector2D to Vector. The magnitude of V;
      /// </summary>
      /// <param name="V"></param>
      public static implicit operator Vector( Vector2D V ) {
         return new Vector( V , NSpace.R2 );
      }

      /// <summary>
      /// Explicit cast Vector to Velocity2D.
      /// </summary>
      /// <param name="V">Vector</param>
      public static explicit operator Vector2D( Vector V ) {
         return ( Vector2D )V.v;
      }

      #endregion 2-Space Overloads

      #region 3-Space Overloads

      /// <summary>
      /// Implicit cast Vector3D to Vector. The magnitude of V;
      /// </summary>
      /// <param name="V"></param>
      public static implicit operator Vector( Vector3D V ) {
         return new Vector( V , NSpace.R3 );
      }

      /// <summary>
      /// Explicit cast Vector to Velocity3D.
      /// </summary>
      /// <param name="V">Vector</param>
      public static explicit operator Vector3D( Vector V ) {
         return ( Vector3D )V.v;
      }

      #endregion 3-Space Overloads

      /// <summary>
      /// String representation of Vector Magnitude
      /// </summary>
      /// <returns></returns>
      public override string ToString() {
         return string.Format( "Vector[v={0}]" , this.Value );
      }
   }
}