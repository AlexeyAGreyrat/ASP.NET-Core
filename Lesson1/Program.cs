using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Lesson1
{
    class Program
    {
        private static HttpClient _client = new HttpClient();
        private static void Create()
        {
            if (!File.Exists("result.txt"))
            {
                File.Create("result.txt").Close();
            }
            else
            {
               File.Delete("result.txt");
               File.Create("result.txt").Close();
            }
        }
        static async Task Main(string[] args)
        {
            Create();

            for (int i = 4; i < 14; i++)
            {
                WritePost(await GetPost(i));
            }
        }

        static async Task<Post> GetPost(int num)
        {
            var request = await _client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{num}");

            if (!request.IsSuccessStatusCode)
            {
                Console.WriteLine("Ошибка}");
                return null;
            }

            var result = request.Content.ReadAsStringAsync().Result;

            
            var post = JsonConvert.DeserializeObject<Post>(result);
            return post;
            
        }
        private static void WritePost(Post post)
        {
            using (StreamWriter stream = new StreamWriter("result.txt", true, Encoding.Default))
            {
                stream.WriteLine(post.UserId);
                stream.WriteLine(post.Id);
                stream.WriteLine(post.Title);
                stream.WriteLine(post.Body);
                stream.WriteLine();
            }
        }
    }        
}
