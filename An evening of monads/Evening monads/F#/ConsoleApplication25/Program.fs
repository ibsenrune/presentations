// Learn more about F# at http://fsharp.net


let tryParseWith tryParseFunc = tryParseFunc >> function
    | true, v    -> Some v
    | false, _   -> None

let tryParseWith' tryParseFunc = 
    let wrap = function
        | true, v    -> Some v
        | false, _   -> None
    in 
        fun() -> wrap( tryParseFunc() )

let pakkefun v = 
    match v with
        | true, v    -> Some v
        | false, _   -> None
    


let parseInt    = tryParseWith System.Int32.TryParse
let parseDateTime = tryParseWith System.DateTime.TryParse

let readInput = System.Console.ReadLine >> parseInt

let readAndAdd() = 
    match readInput() with
    | None -> None
    | Some(n) -> 
      match readInput() with
      | None -> None
      | Some(m) -> Some(n+m)

let readAndAdd'() =
    match readInput() with
    | None -> None
    | Some(n) -> readInput() |> Option.map (fun m -> m + n)


let readAndAdd''() =
    readInput() |> Option.bind (fun num -> 
    readInput() |> Option.map ((+) num ))