// https://www.hackerrank.com/challenges/kundu-and-bubble-wrap/problem
// Coupon collector's problem

open System

let [| n; m |] = Console.ReadLine().Split ' ' |> Array.map int

let f n = float n * ([1..n] |> Seq.map (fun i -> 1.0/float i) |> Seq.sum)

printfn "%.2f" (f (n*m))
