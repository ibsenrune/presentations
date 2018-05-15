module Lookup

    type LookupResult<'t> = | Value of 't
                            | Nothing


