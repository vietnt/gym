// https://www.hackerrank.com/challenges/maximum-element/problem
open System

type Op = 
    | Push of int
    | Pop
    | PrintMax

let rec f s o =
    match o with
    | Push x ->
        match s with
        | [] -> [x,1]
        | h::xs ->
            let y, c = h        
            if x > y then (x,1)::s
            else (y,c+1)::xs
    | Pop ->
        match s with
        | [] -> []
        | (x,c)::xs->
            let nc = c - 1
            if nc = 0 then xs
            else (x,nc)::xs
    | PrintMax ->
        match s with
        | (x,_)::_ ->
            printfn "%i" x
            s
            
let parse a =
    match a with
    | [| 2 |] -> Pop
    | [| 1; x |] -> Push x
    | [| 3 |] -> PrintMax
    
let n = Console.ReadLine() |> int
let cmds = [ for i in [1..n] -> Console.ReadLine().Split ' ' |> Array.map int]

cmds
|> Seq.map parse
|> Seq.fold f []
|> ignore
