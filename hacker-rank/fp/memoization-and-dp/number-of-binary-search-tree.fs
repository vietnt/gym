// https://www.hackerrank.com/challenges/number-of-binary-search-tree/problem
open System    
    
let M = 100000007L    
let a = Array.create 1001 0L
a.[0] <- 1L
a.[1] <- 1L        
    
let rec f n =    
    if a.[n] = 0L then
        let t = [0..n-1] |> Seq.sumBy (fun i -> f i * (f(n-1-i))% M)
        a.[n] <- t%M
    a.[n]    
    
let n = Console.ReadLine() |> int
[ for i in [1..n] -> Console.ReadLine() |> int ]        
|> Seq.map f
|> Seq.iter (printfn "%i")
