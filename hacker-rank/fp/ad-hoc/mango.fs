// https://www.hackerrank.com/challenges/mango/problem

open System

let readArray() = Console.ReadLine().Split ' ' |> Array.map int64 

let g a m e = 
    e
    |> Seq.map (fun (a,b) -> a + (m - 1L)*b)
    |> Seq.sort
    |> Seq.truncate (int m)
    |> Seq.sum
    |> ((>=) a)

let rec f m a b s =
    if a = b then a
    else
       let t = (a + b + 1L)/2L
       if g m t s then f m t b s
       else f m a (t - 1L) s
        
let [| n; m |] = readArray()
let a = readArray()
let h = readArray()        

Seq.zip a h
|> Seq.sortWith (fun (a,x) (b,y) -> compare x y)
|> f m 0L n
|> printfn "%i"
