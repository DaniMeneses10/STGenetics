using Microsoft.EntityFrameworkCore;
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

        public Animal GetAnimalById(Guid animalId)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == animalId && x.DeleteDate == null).FirstOrDefault();
            return animal;
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

            animal.Name = request.Name;
            animal.Breed = request.Breed;
            animal.BirthDate = request.BirthDate;
            animal.Sex = request.Sex;
            animal.Price = request.Price;
            animal.Status = request.Status;
            animal.CreateDate = request.CreateDate;

            this._context.SaveChanges();

            return true;
        }

        public bool DeleteAnimalById(Guid animalId)
        {
            var animal = this._context.Animals.Where(x => x.AnimalId == animalId && x.DeleteDate == null).FirstOrDefault();

            animal.DeleteDate = DateTime.UtcNow;
            this._context.SaveChanges();
            return true;
        }

        public List<Animal> GetAnimalsByFilter(string? animalId, string? name, string? sex, string? status)
        {
            var listOfParameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(animalId))
                listOfParameters.Add("animalId", animalId);

            if (!string.IsNullOrEmpty(name))
                listOfParameters.Add("name", name);

            if (!string.IsNullOrEmpty(sex))
                listOfParameters.Add("sex", sex);

            if (!string.IsNullOrEmpty(status))
                listOfParameters.Add("status", status);

            var listOfResults = Database.Helpers.StoredProcedureHelper.ExecuteStoredProcedure<Animal>("[dbo].[GetAnimalsByFilter]", listOfParameters, this._context.Database.GetDbConnection());

            return listOfResults;
        }
    }
}
