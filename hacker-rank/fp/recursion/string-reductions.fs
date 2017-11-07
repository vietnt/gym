// https://www.hackerrank.com/challenges/string-reductions/problem

let s = System.Console.ReadLine()

s
|> Seq.mapi (fun i c -> i,c)
|> Seq.groupBy snd
|> Seq.map (fun (c,s) -> c, Seq.head s)
|> Seq.sortBy snd
|> Seq.map fst
|> Seq.toArray
|> System.String
|> printfn "%s"
