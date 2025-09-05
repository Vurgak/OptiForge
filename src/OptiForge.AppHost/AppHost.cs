var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.OptiForge_Server>("server");

var clientHost = builder.AddProject<Projects.OptiForge_ClientHost>("client-host")
    .WithHttpEndpoint()
    .WithReference(server)
    .WaitFor(server);

builder.AddNpmApp("client", "../OptiForge.Client", "dev")
    .WithHttpEndpoint(env: "PORT")
    .WithReference(clientHost)
    .WaitFor(clientHost);

builder.Build().Run();
