// https://www.hackerrank.com/challenges/making-anagrams/problem

let p a = a |> Seq.groupBy id |> Seq.map (fun (l,s) -> l, s |> Seq.length) |> Map.ofSeq

let a = System.Console.ReadLine() |> p
let b = System.Console.ReadLine() |> p

let f c k v  =
    match b |> Map.tryFind k with
    | None -> c + v
    | Some x -> c + abs(x-v)        
    
let g c k v =
    match a |> Map.tryFind k with
    | None -> c + v
    | _ -> c   
    
printfn "%i" (Map.fold f 0 a + Map.fold g 0 b)
