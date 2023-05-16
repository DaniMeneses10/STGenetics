using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Interfaces
{
    public interface IAnimalService
    {
        string CreateNAnimals(int n);
        Animal GetAnimalById(Guid animalId);
        bool CreateAnimal(Animal animal);
        bool UpdateAnimalById(Animal animal);
        bool DeleteAnimalById(Guid animalId);
        List<Animal> GetAnimalsByFilter(string? animalId, string? name, string? sex, string? status);
    }
}
