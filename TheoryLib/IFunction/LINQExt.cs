using System;
using System.Collections.Generic;
using System.Linq;

namespace TheoryLib.IFunction {

    public static class LINQExt {

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>( this TFirst[ ] src , TSecond[ ] other , Func<TFirst , TSecond , TResult> operation ) {
            if( ( src.Count() != other.Count() ) || ( src.Count() == 0 ) ) {
                throw new InvalidOperationException( "Empty set or unequal sizes" );
            }
            System.Collections.IEnumerator A = src.GetEnumerator();
            System.Collections.IEnumerator B = other.GetEnumerator();
            while( A.MoveNext() && B.MoveNext() ) {
                yield return operation( ( TFirst )A.Current , ( TSecond )B.Current );
            }
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>( this IEnumerable<TFirst> src , IEnumerable<TSecond> other , Func<TFirst , TSecond , TResult> operation ) {
            var A = src.GetEnumerator();
            var B = other.GetEnumerator();
            if( src.Count() != other.Count() || src.Count() == 0 ) {
                throw new InvalidOperationException( "Empty Set or unequal sizes" );
            }
            while( A.MoveNext() && B.MoveNext() ) {
                yield return operation( A.Current , B.Current );
            }
        }
    }
}