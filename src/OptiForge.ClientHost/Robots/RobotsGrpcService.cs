using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace OptiForge.ClientHost.Robots;

public class RobotsGrpcService : Robots.RobotsBase
{
    public override Task<GetRecentResponse> GetRecent(Empty request, ServerCallContext context)
    {
        var response = new GetRecentResponse
        {
            Items = { new RecentRobot { Name = "Test Robot", Path = @"C:\Code\TestRobot" } },
        };

        return Task.FromResult(response);
    }
}
