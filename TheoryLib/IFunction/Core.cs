namespace TheoryLib.IFunction {

   using System;
   using System.Collections.Generic;

   internal class Template<TSource, TSource2, TResult> : Var<TSource , TSource2 , TResult> {

      /// <summary>
      /// Return an IEnumerable by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      internal static IEnumerable<TResult> SelectFromBoth( IEnumerable<TSource> A , IEnumerable<TSource2> B , Func<TSource , TSource2 , TResult> Function ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource2> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               yield return Function( AE.Current , BE.Current );
            } else {
               yield return Function( AE.Current , default( TSource2 ) );
            }
         }
         while( BE.MoveNext() ) {
            yield return Function( default( TSource ) , BE.Current );
         }
      }

      internal static TResult AccumulateFromBoth( IEnumerable<TSource> A , IEnumerable<TSource2> B , Func<TResult , TSource , TSource2 , TResult> Function ) {
         TResult result = default(TResult);
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource2> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               result = Function( result , AE.Current , BE.Current );
            } else {
               result = Function( result , AE.Current , default( TSource2 ) );
            }
         }
         while( BE.MoveNext() ) {
            result = Function( result , default( TSource ) , BE.Current );
         }
         return result;
      }
   }

   internal class Template<TSource, TResult> : Var<TSource , TResult> {

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      internal static TResult AccumulateFromBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Func<TResult , TSource , TSource , TResult> Function ) {
         TResult result = default(TResult);
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               result = Function( result , AE.Current , BE.Current );
            } else {
               result = Function( result , AE.Current , default( TSource ) );
            }
         }
         while( BE.MoveNext() ) {
            result = Function( result , default( TSource ) , BE.Current );
         }
         return result;
      }

      /// <summary>
      /// Apply Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Action">Action</param>
      internal static void ApplyBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Action<TSource , TSource> Action ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               Action( AE.Current , BE.Current );
            } else {
               Action( AE.Current , default( TSource ) );
            }
         }
         while( BE.MoveNext() ) {
            Action( default( TSource ) , BE.Current );
         }
      }

      /// <summary>
      /// Return an IEnumerable by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      internal static IEnumerable<TResult> SelectFromBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Func<TSource , TSource , TResult> Function ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               yield return Function( AE.Current , BE.Current );
            } else {
               yield return Function( AE.Current , default( TSource ) );
            }
         }
         while( BE.MoveNext() ) {
            yield return Function( default( TSource ) , BE.Current );
         }
      }
   }

   internal class Template<TResult> : Var<TResult> {

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      internal static TResult AccumulateFromBoth( IEnumerable<TResult> A , IEnumerable<TResult> B , Func<TResult , TResult , TResult , TResult> Function ) {
         TResult result = default(TResult);
         IEnumerator<TResult> AE = A.GetEnumerator();
         IEnumerator<TResult> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               result = Function( result , AE.Current , BE.Current );
            } else {
               result = Function( result , AE.Current , default( TResult ) );
            }
         }
         while( BE.MoveNext() ) {
            result = Function( result , default( TResult ) , BE.Current );
         }
         return result;
      }
   }
}