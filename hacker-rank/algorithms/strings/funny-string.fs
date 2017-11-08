// https://www.hackerrank.com/challenges/funny-string/problem
open System

let n = Console.ReadLine() |> int

let ts = [ for i in [1..n] -> Console.ReadLine()]

let r s = s |> Seq.pairwise |> Seq.map (fun (a,b) -> int a - int b |> abs) |> Seq.toList

let f s = 
    r s = r (Seq.rev s)
    
ts
|> Seq.map f
|> Seq.map (fun b -> if b then "Funny" else "Not Funny")
|> Seq.iter (printfn "%s")    
