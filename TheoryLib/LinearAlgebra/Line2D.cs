namespace TheoryLib.LinearAlgebra {

   /// <summary>
   ///
   /// </summary>
   public struct Line2D {
      #region Line2D Instance Variables

      private Vector2D o;
      private Vector2D t;
      private Vector2D f;
      private Vector2D d;
      private float len;

      #endregion Line2D Instance Variables

      #region Line2D Properties

      /// <summary>
      ///
      /// </summary>
      public Vector2D Origin { get { return this.o; } private set { this.o = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector2D Terminal { get { return this.t; } private set { this.t = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector2D Final { get { return this.f; } private set { this.f = value; } }

      /// <summary>
      ///
      /// </summary>
      public Vector2D Direction { get { return this.d; } private set { this.d = value; } }

      /// <summary>
      ///
      /// </summary>
      public float Length { get { return this.len; } private set { this.len = value; } }

      #endregion Line2D Properties

      #region Line2D Overloaded Operators

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line2D operator +( Line2D A , float B ) {
         return new Line2D( A.o , A.d , A.len + B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line2D operator -( Line2D A , float B ) {
         return new Line2D( A.o , A.d , A.len - B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line2D operator *( Line2D A , float B ) {
         return new Line2D( A.o , A.d , A.len * B );
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public static Line2D operator /( Line2D A , float B ) {
         return new Line2D( A.o , A.d , A.len / B );
      }

      #endregion Line2D Overloaded Operators

      /// <summary>
      ///
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      public Line2D( Vector2D A , Vector2D B ) {
         this.o = A;
         this.f = B;
         this.t = ( B - A );
         this.len = t.Magnitude;
         this.d = t.UnitVector;
      }

      private Line2D( Vector2D O , Vector2D D , float T ) {
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
         return string.Format( "Line2D[x,y] = [{0:0.0},{1:0.0}] + [{2:0.0},{3:0.0}]" , this.Origin.X , this.Origin.Y , this.Terminal.X , this.Terminal.Y );
      }
   }
}