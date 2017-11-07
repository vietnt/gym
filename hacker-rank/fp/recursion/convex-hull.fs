// https://www.hackerrank.com/challenges/convex-hull-fp/problem
// Andrew's Monotone Chain

open System

let cw (x0,y0) (x1,y1) (x2,y2) = (x1-x0)*(y2-y0)-(x2-x0)*(y1-y0) < 0.0

let chain ps =    
    let rec go acc xs =
        match acc, xs with
        | r1::r2::rs,x::xs ->
            if cw r2 r1 x then go (r2::rs) (x::xs)
            else go (x::acc) xs         
        | _, x::xs -> go (x::acc) xs
        | _::xs, [] -> List.rev xs        
    go [] ps  
    
let convexHull ps =
    let s = List.sort ps
    let lower = chain s
    let upper = chain (List.rev s)
    lower @ upper    

let dist (x0,y0) (x1,y1) = sqrt ((x0-x1)**2.0 + (y0-y1)**2.0)

let perimeter s =        
    let rec f xs =
        match xs with
        | [u] -> dist (List.head s) u
        | u::v::t -> dist u v + (f (v::t))        
    f s    
    
let n = Console.ReadLine() |> int

[
    for i = 1 to n do
        let [| a; b |] = Console.ReadLine().Split ' ' |> Array.map float
        yield a, b
]
|> convexHull
|> perimeter
|> printfn "%.2f"
