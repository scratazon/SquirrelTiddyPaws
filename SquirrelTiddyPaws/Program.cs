using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SquirrelTiddyPaws
{
    public class SquirrelTiddyPaws
    {
            private readonly static string _url = "https://e621.net/posts.json";
            private readonly static string _userAgent = "Mlemminy henlo uwu";
            private readonly static string _tags = "?tags=rating%3Aexplicit+squirrel+paws+";
            private readonly static string[] _boobTags  = {
                    "boobs",
                    "breasts",
                    "boob_fuck",
                    "boob_size_difference"
            };

        static async Task Main()
        {
            var rand = new Random();
            var randomBoobs = _boobTags[rand.Next(_boobTags.Length)];
            var boobUrl = _url+_tags+randomBoobs;
            var client = new HttpClient();

            // e621 will shit on our nipples if I don't do this.
            client.DefaultRequestHeaders.Add("User-Agent", _userAgent);


            // Fetch the body of the HTTP Response.
            var boobResult = await client.GetStringAsync(boobUrl);
            JsonDocument boobJson = JsonDocument.Parse(boobResult);
            JsonElement boobRoot = boobJson.RootElement.GetProperty("posts");
            dynamic tiddyStrings = JsonConvert.DeserializeObject(boobRoot.ToString());
            List<string> boobList = new List<string>();
            foreach (var item in tiddyStrings)
            {
                if ((string)item.file.url == "" || (string)item.file.url == null)
                    continue;
                boobList.Add((string)item.file.url);
            }
	        foreach (var item in boobList)
                Console.WriteLine(item);

		        Console.WriteLine(boobList.Count);
                Console.WriteLine("DONE");
            }
    }
}
