using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Services
{
    public class AnimalService : IAnimalService
    {
        public bool CreateAnimal(Animal animal)
        {
            var newAnimal = new Animal();

            newAnimal.AnimalId = Guid.NewGuid();
            newAnimal.Name = animal.Name;
            newAnimal.Breed = animal.Breed;
            newAnimal.BirthDate = animal.BirthDate;
            newAnimal.Sex = animal.Sex;
            newAnimal.Price = animal.Price;
            newAnimal.Status = animal.Status;
            newAnimal.CreateDate = DateTime.UtcNow; ;

            //this._context.Animals.Add(newAnimal);
            //this._context.SaveChanges();

            return true;
        }

        public bool UpdateAnimalById(Animal animal)
        {
            return true;
        }

        public bool DeleteAnimalById(Guid animalId)
        {
            return true;
        }
    }
}
