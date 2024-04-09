namespace PetStoreCRUDWebsite.Models
{
    public interface ICatRepository
    {
        public IEnumerable<Cat> GetAllCats();

        Cat GetCat(int id);

        void UpdateCat(Cat cat);

        public void InsertCat(Cat catToInsert);

        public void DeleteCat(Cat cat);


    }
}
