// https://www.hackerrank.com/challenges/fibonacci-fp/problem

open System

let n = Console.ReadLine() |> int

let a = [ for i in [1..n] -> Console.ReadLine() |> int]

let m = Seq.max a

let fib = Array.create (m+1) 0I

fib.[1] <- 1I
fib.[2] <- 1I

for i = 3 to m do
    fib.[i] <- fib.[i-1] + fib.[i-2]
    
let M = bigint (1e8+7.0)
    
a
|> Seq.map (fun i -> fib.[i]%M)
|> Seq.iter (printfn "%A")
    
