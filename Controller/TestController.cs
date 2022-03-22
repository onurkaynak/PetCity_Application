using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase {
    private readonly PetRepository _petRepository = new PetRepository();

    [HttpPost]
    public Pet PostPet(Pet pet)
    {
        return _petRepository.CreatePetAsync(pet);
    }
    

}