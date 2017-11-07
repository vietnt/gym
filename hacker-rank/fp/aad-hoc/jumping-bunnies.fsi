// https://www.hackerrank.com/challenges/jumping-bunnies/problem

open System

let rec gcd a b =
    if a < b then gcd b a
    elif a%b = 0I then b
    else gcd b (a%b)
    
let lcm a b = a*b/(gcd a b)    

let n = Console.ReadLine() |> int
let a = Console.ReadLine().Split ' ' |> Array.map bigint.Parse

a 
|> Seq.fold lcm 1I 
|> printfn "%A"
