// https://www.hackerrank.com/challenges/common-divisors/problem
open System

let n = Console.ReadLine() |> int
let tests = 
    [1..n]
    |> Seq.map (fun _ ->Console.ReadLine().Split ' ' |> Array.map int)
    |> Seq.map (fun [| a; b |] -> a, b)
    
    
let divs n =
    [1.. (sqrt (float n) |> int)]
    |> List.collect (fun i -> if n%i = 0 then [i; n/i] else [])    

let f (l, m) =

    let l, m = max l m, min l m

    let a = divs l |> List.map (fun i -> i, 1) |> Map.ofList
    let b = divs m    
    
    b     
    |> Seq.filter (fun i -> a |> Map.containsKey i) 
    |> Seq.distinct
    |> Seq.length
    
tests 
|> Seq.map f    
|> Seq.iter (printfn "%i")
    
