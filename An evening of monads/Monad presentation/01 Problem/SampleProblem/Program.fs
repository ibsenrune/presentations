// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Lookup
open Datasource

[<EntryPoint>]
let main argv = 

    let getItemsInCustomersBasket customerName = 
        let customerResult = getCustomer customerName
        match customerResult with
        | Nothing -> Nothing
        | Value (customerId) -> 
            let basketResult = getBasket customerId
            match basketResult with
            | Nothing -> Nothing
            | Value (basketId) ->
                let basketItemsResult = getItemsInBasket basketId
                match basketItemsResult with
                | Nothing -> Nothing
                | Value(items) -> Value(items)

    let getItemsInCustomersBasket' customerName =
        let customerId = getCustomer customerName
        let basketId = getBasket customerId
        let items = getItemsInCustomersBasket basketId
        items

    let customer = getItemsInCustomersBasket "Hans"

    printfn "%A" customer
    0 // return an integer exit code
