using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSLookupResult
{
    public static class Datastore
    {
        public static LookupResult<int> GetCustomer(string str)
        {
            if (str == "Hans")
                return LookupResult<int>.Create(3);
            else
                return LookupResult<int>.Nothing;
        }

        public static LookupResult<int> GetBasket(int customerId) 
        {
            if (customerId == 3)
                return LookupResult<int>.Create(5);
            else
                return LookupResult<int>.Nothing;
        }

        public static LookupResult<List<int>> GetItemsInBasket(int basketId) 
        {
            if (basketId == 5)
                return LookupResult<List<int>>.Create(new List<int>(new[] { 4, 5, 6 }));
            else
                return LookupResult<List<int>>.Nothing;
        }
    }
}
