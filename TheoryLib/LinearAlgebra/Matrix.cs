namespace TheoryLib.LinearAlgebra {

   using Exceptions;
   using IFunction;
   using Mathematics;
   using System.Collections.Generic;
   using System.Linq;

   public class Matrix {
      #region Instance Variables and Properties

      private int c;
      private float[,] matrix;
      private int r;
      public int Columns { get { return this.c; } }
      public IEnumerable<float[ ]> ElementsX { get { return this.GetColumns(); } }
      public IEnumerable<float[ ]> ElementsY { get { return this.GetRows(); } }
      public int Rows { get { return this.r; } }
      public float this[ int Row , int Column ] { get { return this.matrix[ Column , Row ]; } set { this.matrix[ Column , Row ] = value; } }

      #endregion Instance Variables and Properties

      #region Row/Column Manipulation

      private IEnumerable<float> GetAll() {
         foreach( float X in this.matrix ) {
            yield return X;
         }
      }

      private IEnumerable<float> GetColumn( int Column ) {
         for( int Row = 0; Row <= this.matrix.GetUpperBound( 1 ); ++Row ) {
            yield return this[ Row , Column ];
         }
      }

      private IEnumerable<float[ ]> GetColumns() {
         for( int Column = 0; Column <= this.matrix.GetUpperBound( 0 ); ++Column ) {
            yield return this.GetColumn( Column ).ToArray();
         }
      }

      private IEnumerable<float> GetRow( int Row ) {
         for( int Column = 0; Column <= this.matrix.GetUpperBound( 0 ); ++Column ) {
            yield return this[ Row , Column ];
         }
      }

      private IEnumerable<float[ ]> GetRows() {
         for( int Row = 0; Row <= this.matrix.GetUpperBound( 1 ); ++Row ) {
            yield return GetRow( Row ).ToArray();
         }
      }

      #endregion Row/Column Manipulation

      #region Constructors

      public Matrix( float[ , ] array ) {
         this.matrix = new float[ ( this.c = array.GetUpperBound( 0 ) + 1 ) - 1 , ( this.r = array.GetUpperBound( 1 ) + 1 ) - 1 ];
         this.matrix = array;
      }

      public Matrix( params float[ ][ ] array ) {
         this.r = array[ 0 ].Length;
         this.c = array.Length;
         this.matrix = new float[ this.c , this.r ];
         for( int y = 0; y < array.Length; ++y )
            for( int x = 0; x < array[ y ].Length; ++x )
               this[ x , y ] = array[ y ][ x ];
      }

      public Matrix( params Vector[ ] vectors ) {
         switch( vectors[ 0 ].N ) {
            case NSpace.R3:
               this.matrix = new float[ this.c = vectors.Length , this.r = 3 ];
               for( int y = 0; y < vectors.Length; ++y ) {
                  for( int x = 0; x < 3; ++x ) {
                     this[ x , y ] = ( ( Vector3D )vectors[ y ] ).Components[ x ];
                  }
               }
               break;

            case NSpace.R2:
               this.matrix = new float[ this.c = vectors.Length , this.r = 2 ];
               for( int y = 0; y < vectors.Length; ++y ) {
                  for( int x = 0; x < 2; ++x ) {
                     this[ x , y ] = ( ( Vector2D )vectors[ y ] ).Components[ x ];
                  }
               }
               break;

            default:
               this.matrix = null;
               this.c = -1;
               this.r = -1;
               break;
         }
      }

      #endregion Constructors

      public static Matrix operator -( Matrix A , Matrix B ) {
         if( A.Columns == B.Columns && A.Rows == B.Rows ) {
            return new Matrix( Template<float[ ] , float[ ]>.SelectFromBoth( A.ElementsX , B.ElementsX , ( FromA , FromB ) => Template<float , float>.SelectFromBoth( FromA , FromB , ( C , D ) => C - D ).ToArray() ).ToArray() );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      public static Matrix operator *( Matrix A , float B ) {
         return new Matrix( A.ElementsX.ToList().Select( FromA => FromA.Select( X => X * B ).ToArray() ).ToArray() );
      }

      public static Matrix operator *( Matrix A , Matrix B ) {
         #region Theory

         //|123| |A   D|     |(1*A+2*B+3*C)(1*D+2*E+3*F)|
         //|(A)| |B(B)E|   = |                          |
         //|456| |C   F|     |(4*A+5*B+6*C)(4*D+5*E+6*F)|
         //
         //A=[MxN]=[2x3]
         //B=[MxN]=[3x2]
         //C=AxB=[2x3][3x2]
         //D=BxA=[3x2][2x3]

         #endregion Theory
         if( A.Rows == B.Columns && A.Columns == B.Rows ) {
            var x = B.ElementsX.Select( FromB => A.ElementsY.Select( FromA => Template<float , float>.AccumulateFromBoth( FromB , FromA , ( Sum , Column , Row ) => Sum + (Column * Row) ) ).ToArray() ).ToArray();
            return new Matrix( x );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      public static Matrix operator /( Matrix A , float B ) {
         return A * ( 1 / B );
      }

      public static Matrix operator +( Matrix A , Matrix B ) {
         if( A.Columns == B.Columns && A.Rows == B.Rows ) {
            return new Matrix( Template<float[ ] , float[ ]>.SelectFromBoth( A.ElementsX , B.ElementsX , ( FromA , FromB ) => Template<float , float>.SelectFromBoth( FromA , FromB , ( X , Y ) => X + Y ).ToArray() ).ToArray() );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      public override string ToString() {
         List<string> str = new List<string>();
         foreach( float[ ] x in this.GetRows() ) {
            str.Add( "|" + string.Join( "  " , x.Select( A => string.Format( "{0,3}" , A.ToString() ) ).ToArray() ) + "|" );
         }
         return string.Format( "{0}" , string.Join( "\n" , str.ToArray() ) );
      }
   }
}