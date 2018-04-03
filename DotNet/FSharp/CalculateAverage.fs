module CalculateAverage

let avg list = 
  list 
  |> Seq.fold (fun (sum, count) x -> ( (sum+x) , (count + 1 ) ) ) (0.0 , 0)
  |> (fun (sum, count) -> sum / (count |> float) )

[1.0;1.0;1.0] |> avg