// https://www.hackerrank.com/challenges/lists-and-gcd/problem

open System

let n = Console.ReadLine() |> int

let ts =
    [
        for i = 1 to n do
            yield 
                Console.ReadLine().Split ' ' 
                |> Seq.map int 
                |> Seq.chunkBySize 2 
                |> Seq.map (fun [| a; b |] -> a, b) 
                |> Map.ofSeq
    ]
    
let gcd a b =

    let f s k v =
        match b |> Map.tryFind k with
        | Some c -> (k, min c v) :: s
        | None -> s
        
    a |> Map.fold f [] |> Map.ofSeq
    
ts 
|> Seq.reduce gcd
|> Seq.collect (fun p -> [p.Key; p.Value])
|> Seq.map string
|> String.concat " "
|> printfn "%s"
