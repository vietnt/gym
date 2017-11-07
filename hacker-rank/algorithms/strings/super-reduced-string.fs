// https://www.hackerrank.com/challenges/reduced-string/problem
let s = System.Console.ReadLine() |> Seq.toList

let rec f s acc =
    match s with
    | [] -> acc |> List.rev
    | x :: y :: xs when x = y -> 
        match acc with
        | [] -> f xs []
        | h :: t -> f (h::xs) t
    | x :: xs -> f xs (x::acc)
    
match f s [] with
| [] -> printfn "Empty String"
| r -> Array.ofList r |> System.String |> printfn "%s"
