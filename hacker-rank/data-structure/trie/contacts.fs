// https://www.hackerrank.com/challenges/contacts/problem
open System
open System.Collections.Generic


type Node = {    
    mutable count       : int
    children            : Dictionary<char, Node>
}


let newNode() = { count = 0; children = Dictionary<_,_>()}


let add (s: string) r =

    let rec f i (n: Node) =
        let c =
            match n.children.TryGetValue s.[i] with
            | true, c -> c
            | _ ->
                let c = newNode()
                n.children.[s.[i]] <- c
                c
        c.count <- c.count + 1
        if i + 1 < s.Length then f (i+1) c
    
    f 0 r
    
    
let find (p: string) r =

    let rec f i (n: Node) =                
        match n.children.TryGetValue p.[i] with
        | false, _ -> 0
        | true, c -> 
            if i + 1 < p.Length then f (i+1) c
            else c.count
            
    f 0 r
    
    
let f r o g =    
    match o with
    | "add" -> r |> add g
    | "find" -> r |> find g |> printfn "%i"


let r = newNode()
let n = Console.ReadLine() |> int
[
    for i in [1..n] -> Console.ReadLine().Split ' '
]
|> Seq.iter (fun [| o; g |] -> f r o g)
