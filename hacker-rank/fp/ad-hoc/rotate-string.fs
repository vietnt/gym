// https://www.hackerrank.com/challenges/rotate-string/problem
open System

let n = Console.ReadLine() |> int

let t = [1..n] |> Seq.map (fun _ -> Console.ReadLine())


let r i (s: string) = s.[i..] + s.[0..(i-1)]

let f (s : string) =
    let n = s.Length
    [ for i in [1..n] -> r i s] |> String.concat " "
    
t
|> Seq.map f
|> Seq.iter (printfn "%s")
        
    
