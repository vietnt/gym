// https://www.hackerrank.com/challenges/two-characters/problem

let _ = System.Console.ReadLine()
let s = System.Console.ReadLine()

let cs = s |> Seq.distinct |> Seq.toArray

let f (a, b) =    
    let r = s |> Seq.filter (fun c -> c = a || c = b)        
    let g = r |> Seq.pairwise |> Seq.forall (fun (a,b) -> a <> b)            
    if g then         
        r |> Seq.length
    else 0    

Seq.allPairs cs cs
|> Seq.filter (fun (x,y) -> x > y)
|> Seq.map f
|> Seq.max
|> printfn "%i"
