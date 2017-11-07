// https://www.hackerrank.com/challenges/pangrams/problem
let n = System.Console.ReadLine().Replace(" ","").ToLower()

let p = n |> Seq.distinct |> Seq.length = 26

printfn "%s" (if p then "pangram" else "not pangram")
