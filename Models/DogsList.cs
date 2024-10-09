using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATHEMIwebsite.Models
{
    public class DogsList
    {
        private static List<Dog> _dogs = new List<Dog>()
        {
            new Dog { DogId = "1", Name = "Midas", Description = "Biszkoptowy"},
            new Dog { DogId = "2", Name = "Helios", Description = "Rudy"},
            new Dog { DogId = "3", Name = "Atena", Description = "Czekoladowa"}
        };

        public static void AddDog(Dog dog)
        {
            var maxId = _dogs.Max(x => x.DogId);
            dog.DogId = maxId + 1;
            _dogs.Add(dog);
        }

        public static List<Dog> GetDogs() {  return _dogs; }

        public static Dog? GetDogById(string dogId)
        {
            var dog = _dogs.FirstOrDefault(x => x.DogId == dogId);
            if (dog != null)
            {
                return new Dog { DogId = dogId, Name = dog.Name, Description = dog.Description };
            }
            return null;
        }

        public static void UpdateDog(string dogId, Dog dog)
        {
            if (dogId != dog.DogId) return;

            var dogUpdate = _dogs.FirstOrDefault(x => x.DogId == dogId);
            if (dogUpdate != null)
            {
                dogUpdate.Name = dog.Name;
                dogUpdate.Description = dog.Description;
            }
        }

        public static void DeleteDog(string dogId)
        {
            var dog = _dogs.FirstOrDefault(x => x.DogId == dogId);
            if (dog != null) 
            {
                _dogs.Remove(dog);
            }
        }

    }
}
