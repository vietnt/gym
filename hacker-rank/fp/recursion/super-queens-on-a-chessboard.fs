// https://www.hackerrank.com/challenges/super-queens-on-a-chessboard/problem
let go n = 
    let hs = Array.create n false
    let ds = Array.create (n*2) false
    let ads = Array.create (n*2) false

    let rec f x (y1,y2) = seq {
        if x = n then yield 0
        else
            for y = 0 to n-1 do
                let d = y - x + n 
                let a = y + x

                if abs (y2-y) = 2 || abs (y1-y) = 1 || hs.[y] || ds.[d] || ads.[a] then ()
                else
                    hs.[y] <- true; ds.[d] <- true; ads.[a] <- true
                    
                    yield! f (x+1) (y2,y)
                    
                    hs.[y] <- false; ds.[d] <- false; ads.[a] <- false
    }

    f 0 (20, 20)
   
System.Console.ReadLine() 
|> int
|> go 
|> Seq.length
|> printfn "%i"    
