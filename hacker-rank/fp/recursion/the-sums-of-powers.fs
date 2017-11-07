// https://www.hackerrank.com/challenges/functional-programming-the-sums-of-powers/problem
open System

let x = Console.ReadLine() |> int
let n = Console.ReadLine() |> int

let p = 
    let rec f i x =
        match i with
        | 0 -> 1
        | i -> x * (f (i-1) x)
        
    [0..31] |> List.map (f n) |> List.takeWhile (fun i -> i <= x) |> List.rev
    
let rec f n s =
    if n = 0 then 1
    else
        match s with
        | h :: xs -> (if h <= n then f (n-h) xs else 0) + f n xs
        | [] -> 0            
        
f x p |> printfn "%i"
