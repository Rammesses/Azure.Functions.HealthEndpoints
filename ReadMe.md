# Azure Functions HealthEndpoints

TODO: Describe the repo

### Step-by-Step

#### Workspace Setup

```bash
> mkdir Azure.Functions.HealthEndpoints
> cd Azure.Functions.HealthEndpoints
> git init
> dotnet new sln
> dotnet new gitignore
```

#### ASP.Net Web App Sample

For comparison, let's set up the equivalent in an ASP.Net Web App

```bash
> mkdir Samples
> mkdir Samples/ASPNet.WebApp
> cd Samples/ASPNet.WebApp
> dotnet new webapp
```

In `program.cs` add

```c-sharp
builder.Services.AddHealthChecks();
...
app.MapHealthChecks("/health");
```

And that's it!

#### Azure Functions Sample

```bash
> cd ..
> mkdir Azure.FunctionApp
> cd Azure.FunctionApp
> func init --worker-runtime dotnet --docker
> func new --template HttpTrigger --name HelloAzure
```