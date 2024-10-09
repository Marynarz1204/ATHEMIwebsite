using Microsoft.AspNetCore.Mvc;
using ATHEMIwebsite.Models;
using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Driver;
using ATHEMIwebsite.Services;

namespace ATHEMIwebsite.Controllers
{
    public class DogsController : Controller
    {
        private readonly DogDBService _dogDBService;


        public DogsController(DogDBService dogDBService)
        {
            _dogDBService = dogDBService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dogs = _dogDBService.GetDogsAsync().Result;
            return View(dogs);
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            Dog? dog;
            if (string.IsNullOrEmpty(id))
            {
                dog = _dogDBService.GetDogByIDAsync(id).Result;
            }
            else
            {
                dog = _dogDBService.GetDogByIDAsync(id).Result;
            }
            return View(dog);
        }


    }
}
