module Lookup

    type MyList<'t> = 't list


    let bind (p : MyList<'t>,rest : ('t -> MyList<'s>)) =
        match p with
            | [] -> []
            | _  -> List.concat (List.map rest p)

    let unit x = [x]
            
    type LookupResultBuilder() =
        member this.Bind(p,rest) = bind(p,rest)
        member this.Return(x) = unit x