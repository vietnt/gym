// https://www.hackerrank.com/challenges/missing-numbers-fp/problem

open System

let read() =
    let n = Console.ReadLine() |> int
    let a = Console.ReadLine().Split ' ' |> Array.map int
    a
    
let p a = a |> Seq.groupBy id |> Seq.map (fun (n,s) -> n, Seq.length s)
    
let a = read() |> p |> Map.ofSeq
let b = read() |> p

[| 
    for (n,f0) in b do
        match a |> Map.tryFind n with
        | Some f1 when f1 = f0 -> ()
        | _ -> yield n
|] 
|> Array.sort
|> Array.map string
|> String.concat " "
|> printfn "%s"
