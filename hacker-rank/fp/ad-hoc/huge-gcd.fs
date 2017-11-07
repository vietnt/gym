// https://www.hackerrank.com/challenges/huge-gcd-fp/problem
open System

let read() =
    let n = Console.ReadLine() |> int
    let a = Console.ReadLine().Split ' ' |> Array.map bigint.Parse
    a
    
let rec gcd a b =
    if a < b then gcd b a
    elif a%b = 0I then b
    else gcd b (a%b)
    
// huge ?

let a = read() |> Seq.reduce (*)
let b = read() |> Seq.reduce (*)

(gcd a b)%1000000007I |> printfn "%A"
