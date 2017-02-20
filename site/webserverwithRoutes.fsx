// --------------------------------------------------------------------------------------
// Start up Suave.io
// --------------------------------------------------------------------------------------

#r "../packages/FAKE/tools/FakeLib.dll"
#r "../packages/Suave/lib/net40/Suave.dll"

open Fake
open Suave
open System.Net
open Suave.Successful
open Suave.Operators
open Suave.Filters

let serverConfig = 
    let port = getBuildParamOrDefault "port" "8083" |> Sockets.Port.Parse
    { defaultConfig with bindings = [ HttpBinding.create HTTP IPAddress.Loopback port ] }

let app = 
    choose [
        GET >=> choose
            [
                path "/hello" >=> OK "Hello GET"
            ]
        POST >=> choose
            [
                path "/hello" >=> CREATED "Hello POST"
            ]
    ]

startWebServer serverConfig app