// https://www.hackerrank.com/challenges/castle-on-the-grid/problem
open System
open System.Collections.Generic

let M = 100000
let J = [| 1,0; -1,0; 0,1; 0,-1 |]    

let n = Console.ReadLine() |> int
let ts = [| for i in [1..n] -> Console.ReadLine() |]
let [| sx; sy; gx; gy |] = Console.ReadLine().Split ' ' |> Array.map int

let gr = Array2D.init n n (fun i j -> if ts.[i].[j] = 'X' then -1 else M)    
let q = new Queue<_>([sx, sy])



let cr x = x >= 0 && x < n


let fill sx sy c = 

    let rec f jx jy i =
    
        let x = sx + i*jx
        let y = sy + i*jy                    
        
        if cr x && cr y && gr.[x,y] >= 0 then            
            if gr.[x,y] > c then
                q.Enqueue (x, y)
                gr.[x,y] <- c            
            f jx jy (i+1)                
                                    
    for jx, jy in J do f jx jy 1
    
    
gr.[sx,sy] <- 0  

while gr.[gx,gy] = M do
    let x, y = q.Dequeue()
    let c = gr.[x,y] + 1
    fill x y c

gr.[gx,gy]
|> printfn "%i"
