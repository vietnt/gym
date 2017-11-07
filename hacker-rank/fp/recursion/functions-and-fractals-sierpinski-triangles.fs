// https://www.hackerrank.com/challenges/functions-and-fractals-sierpinski-triangles/submissions/code/58355934
let rec split n t =
    if n = 0 then [t]
    else
        let x, y, h = t
        [x,y,h/2;  x-h/2,y+h/2,h/2; x+h/2,y+h/2,h/2] |> List.collect (split (n-1))
        
let n = System.Console.ReadLine() |> int

let board = Array2D.init 63 32 (fun i j -> 0)

let draw (x,y,h) =
    for i = 0 to h-1 do
        for j = -i to i do
            board.[x+j,y+i] <- 1
            
let print_ascii() =            
    for i = 0 to 31 do
        for j = 0 to 62 do
            printf "%s" (if board.[j,i] = 0 then "_" else "1")
        printfn ""

split n (31,0,32) 
|> Seq.iter draw

print_ascii()
