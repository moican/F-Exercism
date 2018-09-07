module Program

open System
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

[<MemoryDiagnoser>]
[<CoreJob>]
type ReverseStringImp () =
    let mutable stringInput : string = ""
 
    let rec reverse1 (a:string): string = if a.Length>0  then reverse1 a.[1..]+a.[..0] else ""
    let reverse2 (input: string): string = input |> Seq.rev |> Array.ofSeq |> String
    let reverse3 (input: string): string = input |> Seq.rev |> System.String.Concat 

    [<Params (1000, 10000, 100000, 1000000)>] 
    member val public StringSize = 0 with get, set

    [<GlobalSetup>]
    member self.SetupData() =
        stringInput <- new System.String('a', self.StringSize)

    [<Benchmark(Description = "if a.Length>0  then reverse1 a.[1..]+a.[..0] else \"\"")>]
    member self.Solution1 () = reverse1 stringInput

    [<Benchmark(Description = "input |> Seq.rev |> Array.ofSeq |> String")>]
    member self.Solution2 () = reverse2 stringInput

    [<Benchmark(Description = "input |> Seq.rev |> System.String.Concat")>]
    member self.Solution3 () = reverse3 stringInput

[<EntryPoint>]
let main argv =              
    // Run the executable with the argument "ReverseStringImp" 
    // Example: dotnet run -c RELEASE -- --filter ReverseStringImp    
    let switch = BenchmarkSwitcher [| typeof<ReverseStringImp> |]

    switch.Run argv |> ignore
    0

