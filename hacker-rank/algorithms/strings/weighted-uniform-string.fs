// https://www.hackerrank.com/challenges/weighted-uniform-string/problem
open System

let s = Console.ReadLine()
let qs =
    let n = Console.ReadLine() |> int
    [ for i in [1..n] -> Console.ReadLine() |> int]
    
let w c = int c - int 'a' + 1    
    
let rec f (s,c) i =    
    let s = if c = i then s else 0
    s + w i, i        
    
let m = s.[1..] |> Seq.scan f (w s.[0], s.[0]) |> Map.ofSeq

let g m q =
    match m |> Map.tryFind q with
    | Some _ -> true
    | _ -> false 

qs
|> Seq.map (g m)
|> Seq.map (fun b -> if b then "Yes" else "No")
|> Seq.iter (printfn "%s")
