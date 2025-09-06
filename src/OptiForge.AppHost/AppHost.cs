var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.OptiForge_Server>("server");

var clientHost = builder.AddProject<Projects.OptiForge_ClientHost>("client-host")
    .WithHttpsEndpoint(6101)
    .WithHttpEndpoint(6100)
    .WithReference(server)
    .WaitFor(server);

builder.AddNpmApp("client", "../OptiForge.Client", "dev")
    .WithHttpEndpoint(env: "PORT")
    .WithReference(clientHost)
    .WaitFor(clientHost);

builder.Build().Run();
