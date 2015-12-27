namespace TheoryLib.Physics {

   using LinearAlgebra;
   using Mathematics;

   /// <summary>
   /// This class is for impliciting finding the velocity of a <see cref="Velocity2D"/> or <see cref="Velocity3D"/>.
   /// </summary>
   public class Velocity {
      private object v;
      private NSpace N;

      /// <summary>
      /// The Magnitude of the velocity
      /// </summary>
      public float Value {
         get {
            switch( N ) {
               case ( NSpace.R2 ):
                  return ( ( Velocity2D )v ).Value;

               case ( NSpace.R3 ):
                  return ( ( Velocity3D )v ).Value;

               default:
                  return 0f;
            }
         }
      }

      #region 2-Space Overloads

      /// <summary>
      /// Implicit cast Velocity2D to Velocity. The magnitude of V;
      /// </summary>
      /// <param name="V">Vector2D</param>
      public static implicit operator Velocity( Velocity2D V ) {
         return new Velocity( V , NSpace.R2 );
      }

      /// <summary>
      /// Implicit cast Vector2D to Velocity. The magnitude of V;
      /// </summary>
      /// <param name="V">Vector2D</param>
      public static implicit operator Velocity( Vector2D V ) {
         return ( Velocity2D )V;
      }

      /// <summary>
      /// Explicit cast Velocity to Velocity2D.
      /// </summary>
      /// <param name="V">Velocity</param>
      public static explicit operator Velocity2D( Velocity V ) {
         return ( Velocity2D )V.v;
      }

      /// <summary>
      /// Explicit cast Velocity to Vector2D.
      /// </summary>
      /// <param name="V">Velocity</param>
      public static explicit operator Vector2D( Velocity V ) {
         return ( Velocity2D )V;
      }

      #endregion 2-Space Overloads

      #region 3-Space Overloads

      /// <summary>
      /// Implicit cast Vector3D to Velocity. The magnitude of V;
      /// </summary>
      /// <param name="V">Vector3D</param>
      public static implicit operator Velocity( Vector3D V ) {
         return ( Velocity3D )V;
      }

      /// <summary>
      /// Implicit cast Velocity3D to Velocity. The magnitude of V;
      /// </summary>
      /// <param name="V">Vector3D</param>
      public static implicit operator Velocity( Velocity3D V ) {
         return new Velocity( V , NSpace.R3 );
      }

      /// <summary>
      /// Explicit cast Velocity to Velocity3D.
      /// </summary>
      /// <param name="V">Velocity</param>
      public static explicit operator Velocity3D( Velocity V ) {
         return ( Velocity3D )V.v;
      }

      /// <summary>
      /// Explicit cast Velocity to Vector3D.
      /// </summary>
      /// <param name="V">Velocity</param>
      public static explicit operator Vector3D( Velocity V ) {
         return ( Velocity3D )V;
      }

      #endregion 3-Space Overloads

      internal Velocity( object V , NSpace NS ) {
         this.v = V;
         this.N = NS;
      }

      /// <summary>
      /// Implicit cast Velocity to float
      /// </summary>
      /// <param name="V">Velocity</param>
      public static implicit operator float( Velocity V ) {
         return V.Value;
      }

      /// <summary>
      /// Implicit cast to Velocity to Vector
      /// </summary>
      /// <param name="V">Velocity</param>
      public static implicit operator Vector( Velocity V ) {
         return new Velocity( V.v , V.N );
      }

      /// <summary>
      /// String representation of Velocity Magnitude
      /// </summary>
      /// <returns>Formatted String</returns>
      public override string ToString() {
         return string.Format( "Velocity[v={0}]" , this.Value );
      }
   }
}