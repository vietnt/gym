// https://www.hackerrank.com/challenges/queue-using-two-stacks/problem
open System

let rec f s op =
    let o, c = s
    match op with
    | [|1; x |] -> o,x::c
    | [| 2 |] -> 
        match o with
        | h::os -> os, c
        | [] -> f (List.rev c, [])  op
    | [| 3 |] ->
        match o with
        | h :: _ -> 
            printfn "%i" h
            s            
        | [] -> f (List.rev c, []) op
        
let n = Console.ReadLine() |> int
let ts = [ for i in [1..n] -> Console.ReadLine().Split ' ' |> Array.map int]

ts
|> Seq.fold f ([], [])
|> ignore
