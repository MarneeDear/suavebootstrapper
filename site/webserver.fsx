// --------------------------------------------------------------------------------------
// Start up Suave.io
// --------------------------------------------------------------------------------------

#r "../packages/FAKE/tools/FakeLib.dll"
#r "../packages/Suave/lib/net40/Suave.dll"

open Fake
open Suave
open System.Net
let serverConfig = 
    let port = getBuildParamOrDefault "port" "8083" |> Sockets.Port.Parse
    { defaultConfig with bindings = [ HttpBinding.create HTTP IPAddress.Loopback port ] }

startWebServer serverConfig 
    (Successful.OK  
        ("Hello JULIAN! It's Suave.io on Azure Websites.<br /><ul>" + 
          "<li>Sample git Repo: <a href='https://github.com/shanselman/suavebootstrapper'>https://github.com/shanselman/suavebootstrapper</a></li>" +
          "<li>Intro blog post: <a href='http://www.hanselman.com/blog/RunningSuaveioAndFWithFAKEInAzureWebAppsWithGitAndTheDeployButton.aspx'>http://www.hanselman.com/blog/RunningSuaveioAndFWithFAKEInAzureWebAppsWithGitAndTheDeployButton.aspx</a></li>" +
          "</ul>"))
