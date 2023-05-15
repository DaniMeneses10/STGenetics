using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Interfaces
{
    public interface IValidatorOrderAnimals
    {
        string ValidateOrderAnimalList(List<AnimalDetailsRequest> animals);
        string ValidateAnimalsList(List<AnimalDetailsRequest> animals);
    }
}
