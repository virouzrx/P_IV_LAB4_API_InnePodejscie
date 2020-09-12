using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using RestSharp;
using System.Linq;

using JsonSerializer = System.Text.Json.JsonSerializer;
namespace Zadanie4_InnePodejscie
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new Website("https://api.collegefootballdata.com/");
            var teams = api.DownloadAsync("/teams/fbs").Result.Content;
            //------------------

            using var db = new FootballContext();
            db.Database.EnsureCreated();
            var deserialization = JsonSerializer.Deserialize<Teams[]>(teams, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var tasks = new List<Task<IRestResponse>>();
            foreach (var item in deserialization)
            {
                var advanced = api.DownloadAsync($"/stats/season/advanced?year=2020&conference={item.Conference}");
                tasks.Add(advanced);
            //------
            }
            var responses = await Task.WhenAll(tasks);

            var deserializationOfAdvanced = responses.SelectMany(x => JsonSerializer.Deserialize<Advanced[]>
            (x.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
            foreach (var item in deserializationOfAdvanced)
            {
                deserialization.FirstOrDefault(x => x.Conference == item.Conference).Advanced.Add(item);
            }
            var addTasks = deserialization.Select(x => db.Add(x));
            await db.SaveChangesAsync();
        }
    }
}