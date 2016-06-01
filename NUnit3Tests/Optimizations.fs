namespace NUnit3Tests

module Optimizations =
    // All find versions become while loops in both debug and release modes
    let rec find haystack needle =
        match haystack with
        | [] -> false
        | x::xs when x = needle -> true
        | _::xs -> find xs needle

    // using an already-defined variable in a pattern match doesn't
    // mean "match only if this part is equal to the already-defined variable"
    // You need a when clause like we have above to do that.
    let rec find2 haystack needle =
        match haystack with
        | [] -> false
        // needle here actually overrides the needle parameter
        // and therefore matches on any non-empty list!
        | needle::xs -> true
        | _::xs -> find xs needle

    let rec find3 haystack needle =
        match haystack with
        | [] -> false
        | x::xs -> if x = needle then true else (find3 xs needle)




