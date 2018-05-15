using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSLookupResult
{
    public static class LookupResultMonad
    {
        // bind : (LookupResult<T>, T -> LookupResult<U>) -> LookupResult<U>
        public static LookupResult<U> SelectMany<T, U>(this LookupResult<T> p, Func<T, LookupResult<U>> rest) 
        {
            if (p.IsNothing) //if p is nothing, return nothing;
                return LookupResult<U>.Nothing;
            else //else apply rest to p
                return rest(p.Value);
        }

        public static LookupResult<V> SelectMany<T, U,V>(this LookupResult<T> p, Func<T, LookupResult<U>> rest, Func<T,U,V> proj)
        {
            return p.SelectMany( //if p is nothing, return nothing. Else
                x => rest(x).SelectMany( //if rest(x) is nothing, return nothing. Else
                    y => LookupResult<V>.Create(proj(x, y)))); //apply proj to x and y and return the result wrapped in a LookupResult
        }
    }
}
