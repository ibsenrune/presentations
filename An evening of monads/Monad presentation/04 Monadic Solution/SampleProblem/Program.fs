// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Lookup
open Datasource

[<EntryPoint>]
let main argv = 

    let lookup = new LookupResultBuilder()

    let getItemsInCustomersBasket'' customerName =
        lookup {
            let! customerId = getCustomer customerName
            let! basketId = getBasket customerId
            let! items = getItemsInBasket basketId
            return items
        }

    let customer = getItemsInCustomersBasket'' "Hans"

    printfn "%A" customer
    0 // return an integer exit code
