// https://www.hackerrank.com/challenges/mars-exploration/problem

open System

Console.ReadLine()
|> Seq.chunkBySize 3
|> Seq.map (fun s -> Seq.zip s "SOS" |> Seq.filter (fun (a,b) -> a <> b) |> Seq.length)
|> Seq.sum
|> printfn "%i"
