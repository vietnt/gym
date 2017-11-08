// https://www.hackerrank.com/challenges/separate-the-numbers/problem

open System

let n = Console.ReadLine() |> int
let ts = [ for i in [1..n] -> Console.ReadLine()]

let g o =
    let rec c i a =    
        if i + 1 >= Array.Length a then true
        elif String.Length a.[i] > 1 && a.[i].[0] = '0' then false
        else
            if int64 a.[i] + 1L <> int64 a.[i+1] then false
            else c (i+1) a

    let a = 
        o 
        |> Seq.map (Seq.rev >> Seq.toArray >> String)         
        |> Seq.toArray
        
    if c 0 a then Some a.[0]
    else None
    

let f s =
    [(Seq.length s)..(-1)..2]
    |> Seq.map (fun i -> s |> Seq.rev |> Seq.splitInto i)
    |> Seq.map Seq.rev
    |> Seq.map g
    |> Seq.choose id
    |> Seq.tryHead
    
let fmt s =
    match s with
    | Some x -> sprintf "YES %s" x
    | None -> "NO"
    
ts
|> Seq.map f
|> Seq.map fmt
|> Seq.iter (printfn "%s")
