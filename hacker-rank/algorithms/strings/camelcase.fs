// https://www.hackerrank.com/challenges/camelcase/problem

open System

Console.ReadLine()
|> Seq.fold (fun s c -> if Char.IsUpper c then s + 1 else s) 1
|> printfn "%i"
