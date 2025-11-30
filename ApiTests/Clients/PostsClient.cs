using RestSharp;
using Newtonsoft.Json;
using ApiTests.Config;
using ApiTests.DTOs;
using System.Threading.Tasks;

namespace ApiTests.Clients
{
    public class PostsClient
    {
        private readonly RestClient _client;

        public PostsClient()
        {
            _client = new RestClient(ApiConfig.baseUrl);
        }

        public async Task<RestResponse> GetPost(int id)
        {
            var request = new RestRequest($"/posts/{id}", Method.Get);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> CreatePost(PostDto body)
        {
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(body);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdatePost(int id, PostDto body)
        {
            var request = new RestRequest($"/posts/{id}", Method.Put);
            request.AddJsonBody(body);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DeletePost(int id)
        {
            var request = new RestRequest($"/posts/{id}", Method.Delete);
            return await _client.ExecuteAsync(request);
        }
    }
}
