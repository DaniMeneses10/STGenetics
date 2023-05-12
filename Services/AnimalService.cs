using STGeneticsProject.Database;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Services
{
    public class AnimalService : IAnimalService
    {
        STGeneticsDBContext _context;

        public AnimalService(STGeneticsDBContext context)
        {
            this._context = context;
        }

        public bool CreateAnimal(Animal request)
        {
            var animal = new Animal();

            animal.AnimalId = Guid.NewGuid();
            animal.Name = request.Name;
            animal.Breed = request.Breed;
            animal.BirthDate = request.BirthDate;
            animal.Sex = request.Sex;
            animal.Price = request.Price;
            animal.Status = request.Status;
            animal.CreateDate = DateTime.UtcNow;

            this._context.Animals.Add(animal);
            this._context.SaveChanges();

            return true;
        }

        public bool UpdateAnimalById(Animal request)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == request.AnimalId && x.DeleteDate == null).FirstOrDefault();

            animal.Name = animal.Name;
            animal.Breed = animal.Breed;
            animal.BirthDate = animal.BirthDate;
            animal.Sex = animal.Sex;
            animal.Price = animal.Price;
            animal.Status = animal.Status;
            animal.CreateDate = animal.CreateDate;

            this._context.SaveChanges();

            return true;
        }

        public bool DeleteAnimalById(Guid animalId)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == animalId && x.DeleteDate == null).FirstOrDefault();

            animal.DeleteDate = DateTime.UtcNow;
            return true;
        }
    }
}
