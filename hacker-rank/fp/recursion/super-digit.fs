// https://www.hackerrank.com/challenges/super-digit/problem
let [| a; b |] = System.Console.ReadLine().Split ' '
let k = int64 b

let t s =
    s 
    |> Seq.map  (fun c -> int c - int '0') 
    |> Seq.sum 
    |> int64

let rec f n = 
    if n < 10L then n
    else
        f (t (string n))
    
f (t a * k)
|> printfn "%i"

