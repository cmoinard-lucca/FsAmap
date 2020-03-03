open System.Threading.Tasks
open Saturn
open FSharp.Control.Tasks.V2

open FsAmap.Web.Helpers

let port = 8085us

let getToto () =
    task {
        do! Task.Delay 300
        return {| toto = "toto" |} // {|  |} est un record anonyme. « Équivalent » C# : new { Toto = "toto" } 
    }
    
type WaitDto = { wait: int }

let wait dto =
    task {
        do! Task.Delay dto.wait
    }

let mainRouter =
    router {
        get "/" ( getToto |> toJson)
        post "/wait" (wait |> withJsonBody)
    }

let app =
    application {
        use_router mainRouter
        url ("http://0.0.0.0:" + port.ToString() + "/")
        memory_cache
        use_gzip
    }

let exitCode = 0

[<EntryPoint>]
let main _ =        
    run app
    exitCode