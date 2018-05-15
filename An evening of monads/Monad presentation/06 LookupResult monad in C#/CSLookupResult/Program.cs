using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSLookupResult
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = GetItemsInCustomersBasket("Hans");

            if (items.IsNothing)
                Console.WriteLine("Nothing");
            else
                Console.WriteLine(String.Join(",", items.Value.ToArray()));

            Console.ReadKey();
        }

        #region GetItemsInCustomersBasket / Straightforward version
        private static LookupResult<List<int>> GetItemsInCustomersBasket(string customerName) 
        {
            var customerId = Datastore.GetCustomer(customerName);
            if (customerId.IsNothing)
            {
                return LookupResult<List<int>>.Nothing;
            }
            else 
            {
                var basketId = Datastore.GetBasket(customerId.Value);
                if (basketId.IsNothing)
                {
                    return LookupResult<List<int>>.Nothing;
                }
                else 
                {
                    var items = Datastore.GetItemsInBasket(basketId.Value);
                    return items;
                }
            }
        }
        #endregion

        #region GetItemsInCustomersBasket / Monadic version
        private static LookupResult<List<int>> GetItemsInCustomersBasketLINQ(string customerName)
        {
            return (
                from customerId in Datastore.GetCustomer(customerName)
                from basketId in Datastore.GetBasket(customerId)
                from items in Datastore.GetItemsInBasket(basketId)
                select items
            );
        }
        #endregion
    }
}
