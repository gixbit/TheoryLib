namespace TheoryLib.Physics {

   using LinearAlgebra;
   using Mathematics;
   using Mathematics.Symbol;

   /// <summary>
   /// Describes the 2-Space velocity vector
   /// </summary>
   public struct Velocity2D {
      private float v;
      private Radian[] angle;

      /// <summary>
      /// The magnitude of the velocity vector
      /// </summary>
      public float Value { get { return this.v; } private set { this.v = value; } }

      /// <summary>
      /// The X-component of the velocity vector
      /// </summary>
      public float Vx { get { return v * Function.Cos( Tx ); } }

      /// <summary>
      /// The Y-component of the velocity vector
      /// </summary>
      public float Vy { get { return v * Function.Cos( Ty ); } }

      /// <summary>
      /// The X-component of the angular vector
      /// </summary>
      public float Tx { get { return this.angle[ 0 ]; } private set { this.angle[ 0 ] = value; } }

      /// <summary>
      /// The Y-component of the angular vector
      /// </summary>
      public float Ty { get { return this.angle[ 1 ]; } private set { this.angle[ 1 ] = value; } }

      /// <summary>
      /// The constructor for a 2-Space velocity vector
      /// </summary>
      /// <param name="V">Vector2D</param>
      public Velocity2D( Vector2D V ) {
         this.angle = new Radian[ 2 ];
         this.v = V.Magnitude;
         this.angle[ 0 ] = Function.Arccos( V.X / this.v );
         this.angle[ 1 ] = Function.Arccos( V.Y / this.v );
      }

      /// <summary>
      /// Converts a 2-Space velocity vector into its <see cref="Vector2D"/> form.
      /// </summary>
      /// <returns>Vector2D</returns>
      public Vector2D ToVector2D() {
         return new Vector2D( Vx , Vy );
      }

      /// <summary>
      /// Implicit conversion operator for converting Velocity2D into Vector2D.
      /// </summary>
      /// <param name="V">Velocity2D</param>
      public static implicit operator Vector2D( Velocity2D V ) {
         return V.ToVector2D();
      }

      /// <summary>
      /// Implicit conversion operator for converting Vector2D into Velocity2D.
      /// </summary>
      /// <param name="V"></param>
      public static implicit operator Velocity2D( Vector2D V ) {
         return new Velocity2D( V );
      }
   }
}