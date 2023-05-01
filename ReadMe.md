# Azure Functions HealthEndpoints

This repo contains the sample code for an Azure Functions Extensions that exposes a `health` endpoint
in the same manner as comes out-of-the-box with ASP.Net Web API projects.

This "abuse" of the Azure Functions Runtime is the subject of a session at Global Azure Day London, held 12th May 2023 at Microsoft Reactor, London.

### Step-by-Step

#### Workspace Setup

```bash
> mkdir Azure.Functions.HealthEndpoints
> cd Azure.Functions.HealthEndpoints
> git init
> dotnet new sln
> dotnet new gitignore
```

#### ASP.Net Web Api

Let's set up the a basic ASP.Net Web App with a Swagger / OpenAPI discovery endpoint and a standard health endpoint.

Create a new ASP.Net Web App:

```bash
> mkdir Samples
> mkdir Samples/ASPNet.WebApi
> cd Samples/ASPNet.WebApi
> dotnet new webapi
```

The *Swashbuckle Middleware* to support the OpenAPI discovery endpoint is already enabled in `Program.cs`!

```c-sharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
...
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

To enable the standard health endpoint in `program.cs` add

```c-sharp
builder.Services.AddHealthChecks();
...
app.MapHealthChecks("/health");
```

And that's it - our sample is complete using ASP.Net WebApi and just _two_ extra lines of code.

#### Azure Functions Sample

```bash
> cd ..
> mkdir Azure.FunctionApp
> cd Azure.FunctionApp
> func init --worker-runtime dotnet --docker
> func new --template HttpTrigger --name HelloAzure
```

Adding an Open API discovery endpoint is supported using the `

```bash
> dotnet add package Microsoft.Azure.WebJobs.Extensions.OpenApi
```

But there's no `Program.cs` to change, and even if we add a `Startup.cs` there's no way to programatically add a new "route" to the function app.

But how does the `Microsoft.Azure.WebJobs.Extensions.OpenApi` package manage this?

The answer is by implementing a custom Azure Functions Runtime extension that registers the endpoints when the Functions Host starts up. And we can do the same!

By making a project reference from our sample Function App to the *Microsoft.Azure.WebJobs.Extensions.Health* project in the root of the repository, we get the same behaviour - with _zero_ lines of extra code needed!

#### How it works

TLDR: It's complex.
