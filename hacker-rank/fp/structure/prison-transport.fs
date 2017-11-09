// https://www.hackerrank.com/challenges/prison-transport/problem
// disjoint set with union-by-rank
open System

let n = Console.ReadLine() |> int

let p = Array.init (n+1) id
let r = Array.create (n+1) 0
let g = Array.create (n+1) 1

let rec find i =
    if p.[i] = i then i
    else find p.[i]

let uion a b =
    let u = find a
    let v = find b
    if u <> v then
        match compare r.[u] r.[v] with
        | -1 -> p.[u] <- v
        | 1 -> p.[v] <- u
        |  0 ->        
            p.[v] <- u
            r.[u] <- r.[u] + 1
            
let cost x = float x |> sqrt |> ceil |> int
            
let m = Console.ReadLine() |> int
seq {1..m}
|> Seq.map (fun _ -> Console.ReadLine().Split ' ' |> Array.map int )
|> Seq.map (fun [| a; b |] -> a, b)
|> Seq.iter (fun (a,b) -> uion a b)
    
for i = 1 to n do
    let r = find i
    if i <> r then 
        g.[i] <- 0
        g.[r] <- g.[r] + 1
    
g
|> Seq.skip 1
|> Seq.choose (fun x -> if x > 0 then Some x else None)    
|> Seq.map cost
|> Seq.sum
|> printfn "%i"
