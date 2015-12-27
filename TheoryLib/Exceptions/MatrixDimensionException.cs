namespace TheoryLib.Exceptions {

   using System;

   public class MatrixDimensionException : Exception {

      public MatrixDimensionException( string x ) : base( x ) {
      }

      public MatrixDimensionException() : base() {
      }
   }
}