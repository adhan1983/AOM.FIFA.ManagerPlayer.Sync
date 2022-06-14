using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Grpc.Core;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base
{
    public class BasegRPCServiceClient
    {
        private readonly IGrpcServer _grpcChannelClient;
        private readonly IAuth0Properties _auth0Properties;
        public readonly GrpcChannel channel;
        public BasegRPCServiceClient(IGrpcServer grpcChannelClient, IAuth0Properties auth0Properties)
        {
            _grpcChannelClient = grpcChannelClient;
            _auth0Properties = auth0Properties;
            channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint);
        }

        public async Task<GrpcChannel> CreateAuthorizedChannel()
        {
            var accessToken = await GetAccessToken();

            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    metadata.Add("Authorization", $"Bearer {accessToken}");
                }
                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

            return channel;
        }

        private async Task<string> GetAccessToken() 
        {            
            var auth0Client = new AuthenticationApiClient(_auth0Properties.Domain);
            
            var tokenRequest = new ClientCredentialsTokenRequest()
            {
                ClientId = _auth0Properties.ClientId,
                ClientSecret = _auth0Properties.ClientSecret,
                Audience = _auth0Properties.Audience
            };
            
            var tokenResponse = await auth0Client.GetTokenAsync(tokenRequest);

            return tokenResponse.AccessToken;
        }
    }
}
