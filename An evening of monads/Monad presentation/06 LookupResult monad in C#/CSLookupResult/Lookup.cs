using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSLookupResult
{
    public class LookupResult<T>
    {
        private T _value;
        private static LookupResult<T> nothing = new LookupResult<T>();
        

        private LookupResult() { }
        
        private LookupResult(T t)
        {
            _value = t;
        }

        public static LookupResult<T> Create(T t)
        {
            return new LookupResult<T>(t);
        }

        public static LookupResult<T> Nothing 
        {
            get
            {
                return nothing;
            }
        }

        public bool IsNothing 
        {
            get { return this == nothing; }
        }

        public T Value 
        {
            get
            {
                if (this.IsNothing)
                    throw new InvalidOperationException();

                return _value;
            }
        }
    }
}
