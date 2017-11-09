// https://www.hackerrank.com/challenges/dice-path/problem
open System

let z i j t f r = (((i*61 + j)*7 + t)*7 + f)*7 + r  //ew

let a = Array.create (61*61*7*7*7) 0


let w i j t f r =
    match i, j, t, f, r with
    | 0, _, _, _, _ 
    | _, 0, _, _, _ -> 0
    | 1, 1, 1, 2, 4 -> 1
    | i, j, t, f, r ->
        let x = a.[z i (j-1) r f (7-t)]
        let y = a.[z (i-1) j f (7-t) r]
        max (if x > 0 then x+t else 0) (if y > 0 then y+t else 0)        

for i = 0 to 60 do
    for j = 0 to 60 do
        for t = 1 to 6 do
            for f = 1 to 6 do
                for r = 1 to 6 do
                    a.[z i j t f r] <- w i j t f r                    
let g m n =
    [
        for i = 1 to 6 do
            for j = 1 to 6 do
                for k = 1 to 6 do 
                    yield a.[z m n i j k]
    ] |> Seq.max
    
    
    
let n = Console.ReadLine() |> int

[1..n]
|> Seq.map (fun _ -> Console.ReadLine().Split ' ' |> Array.map int)
|> Seq.map (fun [| m; n |] -> g m n)
|> Seq.iter (printfn "%i")
