// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open Lookup
open Datasource

[<EntryPoint>]
let main argv = 

    let lookup = new LookupResultBuilder()

    let getItemsInCustomersBasket'' customerName =
        lookup {
            let! x = [1;2;3]
            let! y = [4;5;6]
            let! z = [7;8;9]
            return (x,y,z)
        }

    let customer = getItemsInCustomersBasket'' "Hans"

    printfn "%A" customer
    0 // return an integer exit code
