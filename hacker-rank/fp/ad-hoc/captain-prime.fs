// https://www.hackerrank.com/challenges/captain-prime/problem
open System

let n = Console.ReadLine() |> int
let a = [ for i in [1..n] -> Console.ReadLine() |> int ]

let ip =
    let n = Seq.max a 
    let t = Array.create (n+1) -1    
    
    let f p =
        t.[p] <- 1
        for i = 2 to n/p do        
            t.[i*p] <- 2
                        
    for i = 2 to n do
        if t.[i] < 0 then f i
        
    t |> Array.map ((=)1)
        
type Location = | Central | Left | Right | Dead   

let rec tryR x =
    if x < 10 then Right
    elif ip.[x/10] then tryR (x/10)
    else Dead
        
let rec tryL s =
    if String.length s <= 1 then Left
    elif ip.[int s.[1..]] then tryL s.[1..]
    else Dead
        
let rec tryC x (s: string) =
    if x < 10 then Central
    else 
        let s = s.[1..]
        let x = x/10
        match ip.[x], ip.[int s] with
        | true, true -> tryC x s
        | true, false -> tryR x
        | false, true -> tryL s
        | _ -> Dead        
        
let w id =    
    let s = string id
    if not ip.[id] || s.Contains "0" then 
        Dead
    else
        tryC id s
        
a 
|> Seq.map w 
|> Seq.map (fun l -> (string l).ToUpper()) 
|> Seq.iter (printfn "%s")
    
