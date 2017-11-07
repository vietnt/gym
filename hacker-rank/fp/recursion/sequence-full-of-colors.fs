// https://www.hackerrank.com/challenges/sequence-full-of-colors/problem
open System

let n = Console.ReadLine() |> int
let a = [1..n] |> Seq.map (fun _ -> Console.ReadLine())

let test s =
    let sub c (r,g,b,y) =
        match c with
        | 'R' -> r-1,g,b,y
        | 'G' -> r,g-1,b,y
        | 'B' -> r,g,b-1,y
        | 'Y' -> r,g,b,y-1
        
    let t (r,g,b,y) = g - r <= 1 && b - y <= 1

    let f c s =    
        let rec l c s =    
            match s with
            | [] -> true
            | h :: xs ->
                let c = c |> sub h
                if t c then l c xs
                else 
                    false
                    
        let (r,g,b,y) = c        
        if r <> g || b <> y then false
        else
            l c s
         
    
    let count c = s |> Seq.filter ((=)c) |> Seq.length
        
    s |> List.rev |> f (count 'R', count 'G', count 'B', count 'Y')
    
a
|> Seq.map (Seq.toList >> test)
|> Seq.map (fun b -> if b then "True" else "False")
|> Seq.iter (printfn "%s")
