namespace TheoryLib.Physics {

   using TheoryLib.LinearAlgebra;

   /// <summary>
   ///
   /// </summary>
   public class Projectile2D {
      private Velocity2D v2d;

      /// <summary>
      ///
      /// </summary>
      public Velocity2D V_Vector { get { return this.v2d; } private set { this.v2d = value; } }

      /// <summary>
      ///
      /// </summary>
      public Velocity Velocity { get { return this.v2d; } }

      /// <summary>
      ///
      /// </summary>
      public float Range { get { return 0f; } }

      /// <summary>
      ///
      /// </summary>
      public float Time { get { return 0f; } }

      /// <summary>
      ///
      /// </summary>
      public Projectile2D( Vector2D O , Velocity2D V ) {
      }

      public Projectile2D( Vector2D O , Vector2D F , float T ) {
      }
   }
}