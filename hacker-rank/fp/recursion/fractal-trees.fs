// https://www.hackerrank.com/challenges/fractal-trees/submissions/code/58359872
open System

let n = Console.ReadLine() |> int

let rec g n (x,y,r) =
    if n = 1 then [x, y, r]
    else
        (x,y,r) :: ([x-r,y-r-r/2,r/2; x+r,y-r-r/2,r/2] |> List.collect (g (n-1)))
        
let board = Array2D.zeroCreate 100 63        
    
let draw (x,y,r) =
    //board.[x,y] <- 1
    //printfn "%A" (x,y,r)
    for i = 0 to r-1 do board.[x,y+i] <- 1
    for i = 1 to r do
        board.[x-i,y-i] <- 1
        board.[x+i,y-i] <- 1         

let printTree() =
    for i = 0 to 62 do
         let s = String [| for j in [0..99] -> if board.[j,i] = 1 then '1' else '_' |]
         printfn "%s" s

g n (49,63-16,16) |> Seq.iter draw

printTree()
