using Microsoft.AspNetCore.Mvc;
using STGeneticsProject.Interfaces;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            this._animalService = animalService;
        }

        [HttpGet]
        [Route("GetAnimalById")]
        public ActionResult<Animal> GetAnimalById(Guid animalId)
        {
            return this._animalService.GetAnimalById(animalId);
        }

        [HttpPost]
        [Route("CreateAnimal")]
        public ActionResult<bool> CreateAnimal(Animal animal)
        {
            return this._animalService.CreateAnimal(animal);
        }

        [HttpPost]
        [Route("UpdateAnimalById")]
        public ActionResult<bool> UpdateAnimalById(Animal animal)
        {
            return this._animalService.UpdateAnimalById(animal);
        }

        [HttpDelete]
        [Route("DeleteAnimalById")]
        public ActionResult<bool> DeleteAnimalById(Guid animalId)
        {
            return this._animalService.DeleteAnimalById(animalId);
        }

        [HttpGet]
        [Route("GetAnimalsByFilter")]
        public ActionResult<List<Animal>> GetAnimalsByFilter(string? animalId, string? name, string? sex, string? status)
        {
            return this._animalService.GetAnimalsByFilter(animalId, name, sex, status);
        }
    }
}
