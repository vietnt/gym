// https://www.hackerrank.com/challenges/filter-elements/problem
open System

let readTest() =
    let [| _; k |] = Console.ReadLine().Split ' ' |> Array.map int
    let a = Console.ReadLine().Split ' ' |> Array.map int
    k, a
    
let n = Console.ReadLine() |> int

let f (k,s) =
    s
    |> Seq.mapi (fun i c -> i,c) 
    |> Seq.groupBy snd 
    |> Seq.filter (fun (l,s) -> Seq.length s >= k) 
    |> Seq.map (fun (l,s) -> l, Seq.head s) 
    |> Seq.sortBy snd 
    |> Seq.map fst

[1..n]
|> Seq.map (fun _ -> readTest())
|> Seq.map f
|> Seq.map (Seq.map string >> String.concat " ")
|> Seq.map (fun s -> if s = "" then "-1" else s)
|> Seq.iter (printfn "%s")
