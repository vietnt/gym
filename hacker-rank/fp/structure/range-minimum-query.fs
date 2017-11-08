// https://www.hackerrank.com/challenges/range-minimum-query/problem
// Segment what?

open System

let [| n; m |] = Console.ReadLine().Split ' ' |> Array.map int

let a = Console.ReadLine().Split ' ' |> Array.map int
let ts = [ for i in [1..m] -> Console.ReadLine().Split ' ' |> Array.map int ] |> Seq.map (fun [| a; b |] -> a, b)

// introducting skip list = )
let inline seqMin l r (a: _ []) =
    let mutable s = Int32.MaxValue
    for i = l to r do 
        s <- min s a.[i]
    s

let build (a : _ []) =
    let n = a.Length/8
    let t = Array.zeroCreate n
    for i = 0 to n-1 do        
        t.[i] <- a |> seqMin (i*8) (i*8+7)
    t
    
let b = build a    

let f (l,r) =

    if r - l < 8 then    
        a |> seqMin l r 
    else
        let l' = (l+7)/8
        let r' = (r-7)/8
        let m = b |> seqMin ((l+7)/8) ((r-7)/8)        
        
        let h = a |> seqMin l (l+7)
        let t = a |> seqMin (r-7) r                
        min (min h t) m

ts
|> Seq.map f
|> Seq.iter (printfn "%i")
