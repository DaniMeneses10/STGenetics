using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Interfaces
{
    public interface IAnimalService
    {
        bool CreateAnimal(Animal animal);
        bool UpdateAnimalById(Animal animal);
        bool DeleteAnimalById(Guid animalId);
    }
}
