using System;
using System.Net.Http;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Extensions;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Nation;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFIFAGatewayConfig _fifaGatewayConfig;
        private readonly IFIFAUrl _url;
        private readonly IFIFAUrlQueryString _queryString;
        private readonly IAuth0Properties _auth0Properties;

        public HttpClientFactoryService(IAuth0Properties auth0Properties, IHttpClientFactory httpClientFactory, IFIFAGatewayConfig fifaGatewayConfig, IFIFAUrl url, IFIFAUrlQueryString queryString)
        {
            this._httpClientFactory = httpClientFactory;
            this._fifaGatewayConfig = fifaGatewayConfig;
            this._url = url;
            this._queryString = queryString;
            _auth0Properties = auth0Properties ?? throw new ArgumentNullException(nameof(_auth0Properties));
        }
        private HttpRequestMessage BuildHttpRequestMessage(string urlRequest)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlRequest),
                Headers =
                    {
                        { _fifaGatewayConfig.FIFAApiKey , _fifaGatewayConfig.FIFAApiToken },
                    },
            };
        }

        public async Task<LeagueListResponse> GetLeaguesAsync(Request request)
        {
            string urlLeague = string.Concat(_url.league, _queryString.Page);

            return await SendRequestAsync<LeagueListResponse>(request, urlLeague);
        }

        public async Task<ClubListResponse> GetClubsAsync(Request request)
        {
            string urlClub = string.Concat(_url.club, _queryString.Page);

            return await SendRequestAsync<ClubListResponse>(request, urlClub);
        }

        public async Task<PlayerListResponse> GetPlayersAsync(Request request)
        {
            string urlPlayer = string.Concat(_url.player, _queryString.Page);

            return await SendRequestAsync<PlayerListResponse>(request, urlPlayer);
        }

        public async Task<NationListResponse> GetNationsAsync(Request request)
        {
            string urlLeague = string.Concat(_url.nation, _queryString.Page);

            return await SendRequestAsync<NationListResponse>(request, urlLeague);
        }

        public async Task<ResponseToKen> GetTokenAsync()
        {
            using var client = new HttpClient();

            var paramsRequest = new Dictionary<string, string>();

            paramsRequest.Add("client_id", _auth0Properties.ClientId);
            paramsRequest.Add("client_secret", _auth0Properties.ClientSecret);
            paramsRequest.Add("audience", _auth0Properties.Audience);
            paramsRequest.Add("grant_type", _auth0Properties.GrantType);

            var requestSerialized = JsonSerializer.Serialize(paramsRequest);

            var request = new HttpRequestMessage(HttpMethod.Post, _auth0Properties.UrlToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(requestSerialized, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);

            var result = response.EnsureSuccessStatusCode();            

            var responseToken = await response.DeserializeResponseObj<ResponseToKen>();

            return responseToken;
        }


        private async Task<TResponse> SendRequestAsync<TResponse>(Request request, string url) where TResponse : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(_fifaGatewayConfig.FIFAClient))
            {
                string urlRequest = string.Concat(httpClient.BaseAddress, url, request.Page, _queryString.Limit, request.MaxItemPerPage);

                HttpRequestMessage requestMessage = BuildHttpRequestMessage(urlRequest);

                using (var response = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
                {
                    var responseMessage = response.EnsureSuccessStatusCode();

                    var result = await responseMessage.DeserializeResponseObj<TResponse>();

                    return result;
                }
            }

        }

    }
}
