namespace TheoryLib.Physics {

   using LinearAlgebra;
   using Mathematics;
   using Mathematics.Symbol;

   /// <summary>
   /// Describes the 3-Space velocity vector
   /// </summary>
   public struct Velocity3D {
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
      /// The Z-component of the velocity vector
      /// </summary>
      public float Vz { get { return v * Function.Cos( Tz ); } }

      /// <summary>
      /// The X-component of the angular vector
      /// </summary>
      public float Tx { get { return this.angle[ 0 ]; } private set { this.angle[ 0 ] = value; } }

      /// <summary>
      /// The Y-component of the angular vector
      /// </summary>
      public float Ty { get { return this.angle[ 1 ]; } private set { this.angle[ 1 ] = value; } }

      /// <summary>
      /// The Z-component of the angular vector
      /// </summary>
      public float Tz { get { return this.angle[ 2 ]; } private set { this.angle[ 2 ] = value; } }

      /// <summary>
      /// The constructor for a 3-Space velocity vector
      /// </summary>
      /// <param name="V">Vector3D</param>
      public Velocity3D( Vector3D V ) {
         this.angle = new Radian[ 3 ];
         this.v = V.Magnitude;
         this.angle[ 0 ] = Function.Arccos( V.X / this.v );
         this.angle[ 1 ] = Function.Arccos( V.Y / this.v );
         this.angle[ 2 ] = Function.Arccos( V.Z / this.v );
      }

      /// <summary>
      /// Converts a 3-Space velocity vector into its <see cref="Vector3D"/> form.
      /// </summary>
      /// <returns>Vector3D</returns>
      public Vector3D ToVector3D() {
         return new Vector3D( Vx , Vy , Vz );
      }

      /// <summary>
      /// Implicit conversion operator for converting Velocity3D into Vector3D.
      /// </summary>
      /// <param name="V">Velocity3D</param>
      public static implicit operator Vector3D( Velocity3D V ) {
         return V.ToVector3D();
      }

      /// <summary>
      /// Implicit conversation operator for converting Vector3D into Velocity3D
      /// </summary>
      /// <param name="V"></param>
      public static implicit operator Velocity3D( Vector3D V ) {
         return new Velocity3D( V );
      }
   }
}