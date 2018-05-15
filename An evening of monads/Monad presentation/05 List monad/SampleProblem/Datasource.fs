module Datasource

    open Lookup

//    //getCustomer : string -> LookupResult<int>
//    let getCustomer str = 
//        let customerId = 3
//        if str = "Hans" then Value(customerId) else Nothing
//
//    //getBasket : int -> LookupResult<int>
//    let getBasket customerId =
//        let basketId = 5
//        if customerId = 3 then Value(basketId) else Nothing
//
//    //getItemsInBasket : int -> LookupResult<int list>
//    let getItemsInBasket basketId =
//        let items = [ 1; 2; 3 ]
//        if basketId = 5 then Value(items) else Nothing