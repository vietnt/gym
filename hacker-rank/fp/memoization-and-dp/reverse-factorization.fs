// https://www.hackerrank.com/challenges/reverse-factorization/problem
// bfs-with-care

open System
open System.Collections.Generic

let [| n; k |] = Console.ReadLine().Split ' ' |> Array.map int
let a = 
    Console.ReadLine().Split ' ' 
    |> Array.map int
    |> Array.sort
    |> Array.filter (fun x -> n%x=0)
    

let rec p o t m =
    if t = 1 then 1::o
    else
        p (t::o) (m |> Map.find t) m
    

let rec bfs (q: Queue<_>) n m = 
    if q.Count = 0 then
        None
    else
        let c = q.Dequeue()
        if c = n  then 
            Some m
        else
            let f m x =
                let k = c*x
                if k > n || Map.containsKey k m then 
                    m
                else
                    q.Enqueue k
                    Map.add k c m
            a 
            |> Array.fold f m
            |> bfs q n
            
            
match bfs (Queue<_>([1])) n (Map.add 1 0 Map.empty) with
| None -> printfn "-1"
| Some s ->
    s 
    |> p [] n    
    |> Seq.map string
    |> String.concat " "
    |> printfn "%s"    
