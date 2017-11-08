// https://www.hackerrank.com/challenges/hackerrank-in-a-string/problem
open System

let n = Console.ReadLine() |> int    
let qs = [ for i in [1..n] -> Console.ReadLine() ]

let rec g p s =
    match s, p with
    | _, [] -> true
    | [], _ -> false
    | x::xs, y::ps when x <> y -> g p xs
    | x::xs, y::ps when x = y -> g ps xs       
    
let f p s = g (Seq.toList p) (Seq.toList s)    
    
qs
|> Seq.map (f "hackerrank")
|> Seq.map (fun b -> if b then "YES" else "NO")
|> Seq.iter (printfn "%s")
