// https://www.hackerrank.com/challenges/subset-sum/problem

open System

let n = Console.ReadLine() |> int
let a = Console.ReadLine().Split ' ' |> Array.map int64
let tests = 
    let t = Console.ReadLine() |> int
    [ for i in [1..t] -> Console.ReadLine() |> int64 ]


let ids =    
    a
    |> Array.sortDescending
    |> Array.scan (+) 0L

let f x =
    let s = 
        let t = Array.BinarySearch (ids, x)
        if t < 0 then ~~~t else t
    
    if s >= ids.Length then -1
    else s             
        
tests
|> Seq.map f
|> Seq.iter (printfn "%i")
