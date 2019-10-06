using FrontEnd.Agents;
using FrontEnd.Controllers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Test
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void IndexTest()
        {
            IAnimalAgent mock = new AnimalAgentMock();

            using (var target = new AnimalController(mock))
            {
                IActionResult result = target.Index().Result;

                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }

        [TestMethod]
        public void ModelFromIndexTest()
        {
            IAnimalAgent mock = new AnimalAgentMock();

            using (var target = new AnimalController(mock))
            {
                IActionResult result = target.Index().Result;
                var model = (result as ViewResult).Model as IEnumerable<Animal>;

                Assert.AreEqual(4, model.Count());

                Assert.IsTrue(model.Any(animal => animal.Title == "Croissant" && animal.Description == "Technically not an animal"));
                Assert.IsTrue(model.Any(animal => animal.Title == "Giraffe" && animal.Description == "Long necked creature"));
                Assert.IsTrue(model.Any(animal => animal.Title == "Monkey" && animal.Description == "Likes to swing on branches"));
                Assert.IsTrue(model.Any(animal => animal.Title == "Snoop Lion" && animal.Description == "420"));
            }
        }

        [TestMethod]
        public void CreateFromForm()
        {
            // Only tests up to the point where the HttpClient is used
        }
    }
}
