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
            //dynamic tiddyStrings = JsonConvert.DeserializeObject(boobRoot.ToString());
            JArray tiddyStrings = (JArray)JsonConvert.DeserializeObject(boobRoot.ToString());
            Console.WriteLine(tiddyStrings.Count);
            foreach (var item in tiddyStrings)
            {
                // nipples
            }
            //List<string> boobList = new List<string>();
            //int count = 0;
            //foreach (var item in tiddyStrings)
            //{
            //    Console.WriteLine(tiddyStrings.Length);
            //    string tmp = item.file.url;
            //    boobList.Add(tmp);
            //    count++;
            //}
            //var boobArray = new string[count];
            //int i = 0;
            //foreach (var item in boobList)
            //{
            //    boobArray[i] = item;
            //    i++;
            //}
            //Console.WriteLine(boobArray[rand.Next(0,boobArray.Length)]);
            Console.WriteLine("DONE");
        }
    }
}