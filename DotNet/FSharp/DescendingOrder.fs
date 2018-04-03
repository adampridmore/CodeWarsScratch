module DescendingOrder

let descendingOrder n =  
    let toCharArray (s:string) = s.ToCharArray()
        
    n
    |> string
    |> toCharArray
    |> Seq.map string
    |> Seq.map (System.Int32.Parse)
    |> Seq.sortBy id
    |> Seq.map (string)
    |> String.concat ""
    |> (fun s -> System.Int32.Parse(s) )
    