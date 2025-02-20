using System.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireAppWebApiDoc_ApiService>("apiservice")
    // Add command to apiservice to navigate to the documentation generator
    .WithSwaggerUI()
    .WithScalar()
    .WithReDoc();

builder.AddProject<Projects.AspireAppWebApiDoc_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
