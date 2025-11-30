using NUnit.Framework;
using ApiTests.Clients;
using ApiTests.DTOs;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiTests.Tests
{
    [TestFixture]
    public class PostsTests
    {
        private PostsClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new PostsClient();
        }

        [Test]
        public async Task GetPost_ReturnsSuccess()
        {
            var response = await _client.GetPost(1);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var post = JsonConvert.DeserializeObject<PostDto>(response.Content);
            Assert.That(post.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task CreatePost_ReturnsCreated()
        {
            var newPost = new PostDto
            {
                UserId = 1,
                Title = "Test Post",
                Body = "Test Body"
            };

            var response = await _client.CreatePost(newPost);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

            var created = JsonConvert.DeserializeObject<PostDto>(response.Content);
            Assert.That(created.Title, Is.EqualTo("Test Post"));
        }

        [Test]
        public async Task UpdatePost_ReturnsOk()
        {
            var updated = new PostDto
            {
                UserId = 1,
                Title = "Updated Post",
                Body = "Updated Body"
            };

            var response = await _client.UpdatePost(1, updated);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task DeletePost_ReturnsOk()
        {
            var response = await _client.DeletePost(1);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task GetPost_InvalidId_ReturnsNotFound()
        {
            var response = await _client.GetPost(999999);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
    }
}
