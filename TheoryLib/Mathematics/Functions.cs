namespace TheoryLib.Mathematics {

   using LinearAlgebra;
   using Symbol;
   using System;

   /// <summary>
   /// Defines general mathematical functions inside or outside of this library.
   /// </summary>
   public static class Function {

      /// <summary>
      /// Returns the determinant off two <see cref="Vector2D"/> variables.
      /// </summary>
      public static Func<Vector2D,Vector2D,float> Determinant = (A, B)=>{
         return (A.X*B.Y) - (A.Y*B.X);
      };

      /// <summary>
      /// Angle between Vectors or Velocities
      /// </summary>
      public static Func<Vector,Vector,Cosine> AngleBetween = (U,V) => {
         Cosine X = 0f;
         if (U.N == NSpace.R2) {
            X = (Vector2D)U*(Vector2D)V/(U * V);
         } else if (U.N == NSpace.R3) {
            X = (Vector3D)U*(Vector3D)V/(U * V);
         }
         return X;
      };

      /// <summary>
      /// Returns the Cosine value of the Radian
      /// </summary>
      public static Func<Radian, Cosine> Cos = (R) => {
         return (Cosine)Math.Cos(R);
      };

      /// <summary>
      /// Returns the Radian from the Cosine value
      /// </summary>
      public static Func<Cosine, Radian> Arccos = (F) => {
         return (Radian)(Math.Acos(F));
      };

      /// <summary>
      /// Returns the Sine value of the Radian
      /// </summary>
      public static Func<Radian, Sine> Sin = (R) => {
         return (Sine)Math.Sin(R);
      };

      /// <summary>
      /// Returns the Radian from the Sine value
      /// </summary>
      public static Func<Sine, Radian> Arcsin = (F) => {
         return (Radian)(Math.Asin(F));
      };
   }
}