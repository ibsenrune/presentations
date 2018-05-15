// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Lookup
open Datasource

[<EntryPoint>]
let main argv = 

    let getItemsInCustomersBasket' customerName =
        bind(getCustomer customerName, fun customerId ->
            bind(getBasket customerId, fun basketId ->
                bind(getItemsInBasket basketId, unit)))


    let customer = getItemsInCustomersBasket' "Hans"

    printfn "%A" customer
    0 // return an integer exit code
