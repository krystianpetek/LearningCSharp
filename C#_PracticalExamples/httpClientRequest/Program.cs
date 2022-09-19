using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace httpClientRequest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                
                // GET
                var result = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                var json = await result.Content.ReadAsStringAsync();

                var posts = JsonConvert.DeserializeObject<List<Post>>(json);

                var selectedPost = posts.First(p => p.Id == 30);
                Console.WriteLine($"Title: {selectedPost.Title}\nBody: {selectedPost.Body}");

                // POST
                var postJsonContent = new StringContent(JsonConvert.SerializeObject(selectedPost));
                var postResult = await httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts",postJsonContent);
                

                using (var postRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://jsonplaceholder.typicode.com/posts"))
                {
                    postJsonContent = new StringContent(JsonConvert.SerializeObject(selectedPost));

                    // dodawanie headerow
                    postRequestMessage.Headers.Add("someHeader", "someValue");
                    
                    // wywolanie contentu Clientem
                    postRequestMessage.Content = postJsonContent;
                    var post2Result = await httpClient.SendAsync(postRequestMessage);
                };


                // aby dołaczać parametry zapytania, mamy klase
                var queryParams = HttpUtility.ParseQueryString(String.Empty);
                queryParams["postId"] = "1";
                queryParams["someParams"] = "someValues";

                var formattedParams = queryParams.ToString();
                Console.WriteLine($"formatted params: {formattedParams}");
                Console.ReadKey();
            }
        }
    }
}
