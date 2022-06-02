using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public class GrpcPortsExtensions
    {
        private readonly IConfiguration configuration;

        public GrpcPortsExtensions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void BuildgRPCAddress() 
        { 

        }

        public Action<KestrelServerOptions> BuildGrpcPorts() 
        {
            Action<KestrelServerOptions> option = options =>
            {
                var restSectionValue = configuration.GetSection("Ports").GetSection("REST").Value;
                var gRpcSectionValue = configuration.GetSection("Ports").GetSection("GRPC").Value;

                if (restSectionValue == null || !int.TryParse(restSectionValue, out var restPort))
                {
                    restPort = 5000;
                }

                if (gRpcSectionValue == null || !int.TryParse(gRpcSectionValue, out var gRpcPort))
                {
                    gRpcPort = 5001;
                }

                options.ListenAnyIP(restPort, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1;
                });

                options.ListenAnyIP(gRpcPort, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });

                options.Limits.MaxRequestBodySize = null;
            };

            return option;
        }
    }
}
