namespace TheoryLib.LinearAlgebra {

   /// <summary>
   ///
   /// </summary>
   public struct Line3D {
      #region Line3D Instance Variables

      private Vector3D o;
      private Vector3D t;
      private Vector3D f;
      private Vector3D d;
      private float len;

      #endregion Line3D Instance Variables

      #region Line3D Properties

      /// <summary>
      ///
      /// </summary>
      public Vector3D Origin { get { return this.o; } private set { this.o = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector3D Terminal { get { return this.t; } private set { this.t = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector3D Final { get { return this.f; } private set { this.f = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector3D Direction { get { return this.d; } private set { this.d = value; } }

      /// <summary>
      ///
      /// </summary>
      public float Length { get { return this.len; } private set { this.len = value; } }

      #endregion Line3D Properties

      #region Line3D Overloaded Operators

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line3D operator +( Line3D A , float B ) {
         return new Line3D( A.o , A.d , A.len + B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line3D operator -( Line3D A , float B ) {
         return new Line3D( A.o , A.d , A.len - B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line3D operator *( Line3D A , float B ) {
         return new Line3D( A.o , A.d , A.len * B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line3D operator /( Line3D A , float B ) {
         return new Line3D( A.o , A.d , A.len / B );
      }

      #endregion Line3D Overloaded Operators

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      public Line3D( Vector3D A , Vector3D B ) {
         this.o = A;
         this.f = B;
         this.t = ( B - A );
         this.len = t.Magnitude;
         this.d = t.UnitVector;
      }

      private Line3D( Vector3D O , Vector3D D , float T ) {
         this.o = O;
         this.d = D;
         this.len = T;
         this.t = this.len * this.d;
         this.f = this.t + this.o;
      }

      /// <summary>
      ///
      /// </summary>
      /// <returns></returns>
      public override string ToString() {
         return string.Format( "Line3D[x,y,z] = [{0:0.0},{1:0.0},{2:0.0}] + [{3:0.0},{4:0.0},{5:0.0}]" , this.Origin.X , this.Origin.Y , this.Origin.Z , this.Terminal.X , this.Terminal.Y , this.Terminal.Z );
      }
   }
}