// https://www.hackerrank.com/challenges/down-to-zero-ii/problem
// medium-40p really?

open System
open System.Collections.Generic

let n = Console.ReadLine() |> int
let qs = 
    [ 
        for i in [1..n] -> Console.ReadLine() |> int
    ]
        
let M = Seq.max qs + 1

let moves n = seq {
    for i = 2 to int (floor(sqrt(float n))) do
        if n%i = 0 then yield n/i
    yield n-1
}


let bfs n  =    
    let q = new Queue<_>([n])
    let st = Dictionary<_,_>()
    st.[n] <- 0                
    
    while not (st.ContainsKey 0) do    
        let t = q.Dequeue()        
        let s = st.[t] + 1
        
        for m in moves t do
            if not (st.ContainsKey m) then
                st.[m] <- s
                q.Enqueue m
                
    st.[0]
        
            
qs
|> Seq.map bfs
|> Seq.iter (printfn "%i")

