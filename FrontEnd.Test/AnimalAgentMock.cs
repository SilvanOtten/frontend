using FrontEnd.Agents;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Test
{
    class AnimalAgentMock : IAnimalAgent
    {

        private readonly List<Animal> _animals = new List<Animal>
        {
            new Animal { Title = "Croissant",       Description = "Technically not an animal"   },
            new Animal { Title = "Giraffe",         Description = "Long necked creature"        },
            new Animal { Title = "Monkey",          Description = "Likes to swing on branches"  },
            new Animal { Title = "Snoop Lion",      Description = "420"                         },
        };

        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            return await Task.FromResult(_animals);
        }

        public Animal GetAnimalById(int id)
        {
            var query = from animal in _animals
                        where animal.Id == id
                        select animal;

            return query.First();
        }

        public Animal GetAnimalByTitle(string title)
        {
            var query = from animal in _animals
                        where animal.Title == title
                        select animal;

            return query.First();
        }

        public void Create([FromForm] Animal animal)
        {
            _animals.Add(animal);
        }
    }
}