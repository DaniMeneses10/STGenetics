using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Requests;

namespace STGeneticsProject.Models.Validator
{
    public class ValidatorOrderAnimals : IValidatorOrderAnimals
    {
        public string ValidateOrderAnimalList(List<AnimalDetailsRequest> animals)
        {
            var animalError = ValidateAnimalsList(animals);            

            return animalError;
        }

        public string ValidateAnimalsList(List<AnimalDetailsRequest> animals)
        {
            var duplicates = animals.GroupBy(x => new { x.AnimalId }).Where(g => g.Count() > 1).SelectMany(g => g);

            if(duplicates.Any())
            {
                foreach(var duplicate in duplicates)
                {
                    return ($"The animal with Id: {duplicate.AnimalId} is repetead");
                    //throw new Exception($"The AnimalId: {duplicate.AnimalId} is repetead, you can't repeat");
                }                
            }
            return "";
        }
    }
}
