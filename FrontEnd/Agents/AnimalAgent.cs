using FrontEnd.Errors;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
namespace FrontEnd.Agents
{
    public interface IAnimalAgent
    {
        Task<IEnumerable<Animal>> GetAllAnimals();
        Animal GetAnimalById(int id);
        Animal GetAnimalByTitle(string title);
        void Create([FromForm] Animal animal);
    }

    public class AnimalAgent : BaseAgent, IAnimalAgent
    {
        // TO-DO: Check if this is needed
        private List<Animal> _animals;

        public AnimalAgent(HttpClient client)
        {
            //client.BaseAddress = new Uri("http://api");
            client.BaseAddress = new Uri("http://" + Environment.GetEnvironmentVariable("api"));
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        // TO-DO: Make Http Calls
        // Check what parts need to be async
        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "api/Animals"))
            {
                var content = await MakeRequestAsync(request);
                return JsonConvert.DeserializeObject<Animal[]>(content);
            }
        }

        public Animal GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Create([FromForm] Animal animal)
        {
            Debug.WriteLine(animal.Description + " " + animal.Title);

            throw new NotImplementedException();
        }
    }
}
