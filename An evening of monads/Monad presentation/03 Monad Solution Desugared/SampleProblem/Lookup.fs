module Lookup

    type LookupResult<'t> = | Value of 't
                            | Nothing


    let bind (p,rest) =
        match p with
            | Nothing -> Nothing
            | Value(v) -> rest v

    let unit x = Value(x)
            