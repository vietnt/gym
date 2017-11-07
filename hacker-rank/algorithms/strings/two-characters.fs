// https://www.hackerrank.com/challenges/two-characters/problem

let _ = System.Console.ReadLine()
let s = System.Console.ReadLine()

let cs = s |> Seq.distinct |> Seq.toList

let f (a, b) =    
    let r = s |> Seq.filter (fun c -> c = a || c = b)        
    let g = r |> Seq.pairwise |> Seq.forall (fun (a,b) -> a <> b)            
    if g then         
        r |> Seq.length
    else 0    

let ps = List.allPairs cs cs |> List.filter (fun (x,y) -> x > y)

match ps with
| [] -> printfn "0"
| s ->
    s
    |> Seq.map f
    |> Seq.max
    |> printfn "%i"       
