// https://www.hackerrank.com/challenges/different-ways-fp/problem
// dp with memorization = )
open System

let a = Array2D.create 1001 1001 0

let c n k =
    let rec f n k  =       
        match k with
        | 0  -> 1
        | x when x = n -> 1
        | _ -> 
            if a.[n,k] = 0 then
                a.[n,k] <- (f (n-1) (k-1) + f (n-1) k)%100000007
            a.[n,k]
            
    f n k
    
let t = Console.ReadLine() |> int    
[1..t]
|> Seq.map (fun _ -> Console.ReadLine().Split ' ' |> Array.map int)
|> Seq.map (fun [| n; k |] -> c n k)
|> Seq.iter (printfn "%i")
