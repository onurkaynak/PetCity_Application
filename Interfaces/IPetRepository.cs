public interface IPetRepository{

    Pet CreatePetAsync(Pet pet);
    Pet GetPetById(int id);
    IEnumerable<Pet> GetAllPets();
    void DeletePet(int id);
    Pet UpdatePet(int id, Pet pet);
    void GetPetHealthStatus(int id);
    void SetPetHealthStatus(int id);
    IEnumerable<Pet> GetPetsByName(string name);
    IEnumerable<Pet> GetPetsByGender(PetGender gender);
    IEnumerable<Pet> GetByPetsSpecies(string species);
    IEnumerable<Pet> GetAllPetsHealthStatus(PetHealthStatus health);

}