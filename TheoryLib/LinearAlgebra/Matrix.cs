namespace TheoryLib.LinearAlgebra {

    using Exceptions;
    using IFunction;
    using Mathematics;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Matrix {

        public struct Row {
            private int y;

            public Row( int y ) {
                this.y = y;
            }

            public static Row operator ++( Row R ) {
                R.y++;
                return R;
            }

            public static implicit operator int( Row R ) {
                return R.y;
            }

            public static implicit operator Row( int Y ) {
                return new Row( Y );
            }

            public override string ToString() {
                return string.Format( "{0}" , this.y );
            }
        }

        public struct Column {
            private int x;

            public Column( int x ) {
                this.x = x;
            }

            public static Column operator ++( Column C ) {
                C.x++;
                return C;
            }

            public static implicit operator int( Column C ) {
                return C.x;
            }

            public static implicit operator Column( int X ) {
                return new Column( X );
            }

            public override string ToString() {
                return string.Format( "{0}" , this.x );
            }
        }

        #region Instance Variables and Properties

        private int c;
        private decimal[][] matrix;
        private int r;
        public int Columns { get { return this.c; } }
        public IEnumerable<decimal[ ]> ElementsX { get { return this.GetColumns(); } }
        public IEnumerable<decimal[ ]> ElementsY { get { return this.GetRows(); } }
        public int Rows { get { return this.r; } }
        public decimal this[ int Row , int Column ] { get { return this.matrix[ Row ][ Column ]; } set { this.matrix[ Row ][ Column ] = value; } }
        public bool Square { get { return this.Rows == this.Columns; } }

        #endregion Instance Variables and Properties
        #region Row/Column Manipulation

        public decimal[ ] this[ Column X ] {
            get { return this.GetColumn( X ).ToArray(); }
            set {
                for( int y = 0; y < this.Columns; ++y ) {
                    this[ y , X ] = value[ y ];
                }
            }
        }

        public decimal[ ][ ] ArrayMatrix { get { return this.matrix; } set { this.matrix = value; } }

        public decimal[ ] this[ Row Y ] {
            get { return this.matrix[ Y ]; }
            set {
                this.matrix[ Y ] = value;
            }
        }

        //Columns
        public IEnumerable<decimal> GetColumn( int Column ) {
            for( int Row = 0; Row < this.Rows; ++Row ) {
                yield return this[ Row , Column ];
            }
        }

        public IEnumerable<decimal[ ]> GetColumns() {
            for( int Column = 0; Column < this.Columns; ++Column ) {
                yield return this.GetColumn( Column ).ToArray();
            }
        }

        public IEnumerable<decimal> GetColumn( int Column , int IgnoreY ) {
            for( int Row = 0; Row < this.Rows; ++Row ) {
                if( Row != IgnoreY )
                    yield return this[ Row , Column ];
            }
        }

        public IEnumerable<decimal[ ]> GetColumns( int IgnoreX , int IgnoreY ) {
            for( int Column = 0; Column < this.Columns; ++Column ) {
                if( Column != IgnoreX )
                    yield return this.GetColumn( Column , IgnoreY ).ToArray();
            }
        }

        //Rows
        public IEnumerable<decimal> GetRow( int Row ) {
            for( int Column = 0; Column < this.Columns; ++Column ) {
                yield return this[ Row , Column ];
            }
        }

        public IEnumerable<decimal[ ]> GetRows() {
            for( int Row = 0; Row < this.Rows; ++Row ) {
                yield return GetRow( Row ).ToArray();
            }
        }

        public IEnumerable<decimal> GetRow( int Row , int IgnoreX ) {
            for( int Column = 0; Column < this.Columns; ++Column ) {
                if( Column != IgnoreX )
                    yield return this[ Row , Column ];
            }
        }

        public IEnumerable<decimal[ ]> GetRows( int IgnoreX , int IgnoreY ) {
            for( int Row = 0; Row <= this.Rows; ++Row ) {
                if( Row != IgnoreY )
                    yield return GetRow( Row , IgnoreX ).ToArray();
            }
        }

        #endregion Row/Column Manipulation
        #region Constructors

        public Matrix() {
            this.matrix = null;
            this.c = -1;
            this.r = -1;
        }

        public Matrix( Column Columns , Row Rows ) {
            this.matrix = new decimal[ this.r = Rows ][ ];
            this.c = Columns;
            for( int i = 0; i < this.r; ++i ) {
                this.matrix[ i ] = new decimal[ this.c ];
            }
        }

        public Matrix( int Columns , int Rows , decimal Identity ) {
            this.matrix = new decimal[ this.r = Rows ][ ];
            this.c = Columns;
            for( int i = 0; i < this.Columns && i < this.Rows; ++i ) {
                this.matrix[ i ] = new decimal[ this.c ];
                this[ i , i ] = Identity;
            }
        }

        public Matrix( params decimal[ ][ ] array ) {
            this.c = array[ 0 ].Length;
            this.r = array.Length;
            this.matrix = new decimal[ this.r ][ ];
            for( int Row = 0; Row < array.Length; ++Row )
                this.matrix[ Row ] = array[ Row ];
        }

        #endregion Constructors
        #region Operators

        public static Matrix operator -( Matrix A , Matrix B ) {
            if( A.Columns == B.Columns && A.Rows == B.Rows ) {
                Matrix C = new Matrix(A.Columns,B.Rows);
                Column col = 0;
                foreach( decimal[ ] r in A.ElementsX.Zip( B.ElementsX , ( a , b ) => a.Zip( b , ( x , y ) => x - y ).ToArray() ) ) {
                    C[ col++ ] = r;
                }
                return C;
            } else {
                throw new MatrixDimensionException( "Incompatible MxN Matrices" );
            }
        }

        public static Matrix operator *( Matrix A , decimal B ) {
            Matrix C = new Matrix(A.Columns, A.Rows);
            Column col = 0;
            foreach( decimal[ ] r in A.ElementsX.Select( FromA => FromA.Select( X => X * B ).ToArray() ) ) {
                C[ col++ ] = r;
            }
            return C;
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
                Matrix C = new Matrix(B.Columns, A.Rows);
                Column col = 0;
                foreach( decimal[ ] r in B.ElementsX.Select( FromB => A.ElementsY.Select( FromA => FromA.Zip( FromB , ( Col , Row ) => Col * Row ).Sum() ).ToArray() ) ) {
                    C[ col++ ] = r;
                }
                return C;
            } else {
                throw new MatrixDimensionException( "Incompatible MxN Matrices" );
            }
        }

        public static Matrix operator /( Matrix A , decimal B ) {
            return A * ( 1 / B );
        }

        public static Matrix operator +( Matrix A , Matrix B ) {
            if( A.Columns == B.Columns && A.Rows == B.Rows ) {
                Matrix C = new Matrix(A.Columns,B.Rows);
                Column col = 0;
                foreach( decimal[ ] r in A.ElementsX.Zip( B.ElementsX , ( a , b ) => a.Zip( b , ( x , y ) => x + y ).ToArray() ) ) {
                    C[ col++ ] = r;
                }
                return C;
            } else {
                throw new MatrixDimensionException( "Incompatible MxN Matrices" );
            }
        }

        #endregion Operators
        #region Matrix Functions

        public Matrix Upper() {
            Matrix UpperT = new Matrix(this.Columns, this.Rows);
            for( Row R = 0; R < UpperT.Rows; ++R ) {
                UpperT[ R ] = this[ R ];
            }
            for( Row i = 0; i < UpperT.Rows; ++i ) {
                if( UpperT[ i , i ] != 0 )
                    UpperT[ i ] = UpperT[ i ].Select( Element => Element / UpperT[ i , i ] ).ToArray();
                else {
                    bool swapped = false;
                    for( int swap = i + 1; swap < UpperT.Rows; ++swap ) {
                        if( UpperT[ swap , i ] != 0 ) {
                            UpperT.Swap( i , swap );
                            swapped = true;
                            break;
                        }
                    }
                    if( !swapped ) {
                        continue;
                    } else {
                        UpperT[ i ] = UpperT[ i ].Select( Element => Element / UpperT[ i , i ] ).ToArray();
                    }
                }
                for( Row j = i + 1; j < UpperT.Rows; ++j ) {
                    decimal op = UpperT[j][i];
                    UpperT[ j ] = UpperT[ j ].Zip( UpperT[ i ] , ( Rj , Ri ) => Rj - op * Ri ).ToArray();
                }
            }
            return UpperT;
        }

        private void Swap( Row a , Row b ) {
            var temp = this[ a ];
            this[ a ] = this[ b ];
            this[ b ] = temp;
        }

        private void Swap( Column a , Column b ) {
            var temp = this[ a ];
            this[ b ] = this[ a ];
            this[ a ] = temp;
        }

        public Matrix Lower() {
            Matrix LowerT = new Matrix(this.Rows, this.Columns);
            for( Row R = 0; R < LowerT.Rows; ++R ) {
                var Col = this[ new Column(R) ];
                LowerT[ R ] = Col;
            }
            for( Row i = 0; i < LowerT.Rows; ++i ) {
                for( Row j = i + 1; j < LowerT.Rows; ++j ) {
                    decimal Op = LowerT[j,i] / LowerT[i,i];
                    LowerT[ j ] = LowerT[ j ].Zip( LowerT[ i ] , ( Rj , Ri ) => Rj - Op * Ri ).ToArray();
                }
            }

            return LowerT.Transpose();
        }

        public decimal Determinant() {
            Matrix Lower = this.Lower();
            decimal Determinant = 1;
            for( Row i = 0; i < Lower.Rows; ++i ) {
                Determinant *= Lower[ i ][ i ];
            }
            return Determinant;
        }

        public Matrix Transpose() {
            return new Matrix( this.ElementsX.ToArray() );
        }

        #endregion Matrix Functions

        public override string ToString() {
            List<string> str = new List<string>();
            foreach( decimal[ ] x in this.GetRows() ) {
                str.Add( "|" + string.Join( " " , x.Select( A => string.Format( "{0,8}" , ( A ).ToString( "0.0" ) ) ).ToArray() ) + "|" );
            }
            return string.Format( "{0}" , string.Join( "\n" , str.ToArray() ) );
        }
    }
}