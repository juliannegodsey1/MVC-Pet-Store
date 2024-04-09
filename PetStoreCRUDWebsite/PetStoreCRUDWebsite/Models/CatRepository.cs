
using Dapper;
using System.Data;

namespace PetStoreCRUDWebsite.Models
{
    public class CatRepository : ICatRepository
    {
        
        private readonly IDbConnection _conn;

        public CatRepository(IDbConnection conn)
        {
            _conn = conn;
        }

   
        public IEnumerable<Cat> GetAllCats()
        {
            return _conn.Query<Cat>("SELECT * FROM CATS;");

        }


        public Cat GetCat(int id)
        {
            return _conn.QuerySingle<Cat>("SELECT * FROM CATS WHERE PETID = @id", new { id = id });
        }

        public void UpdateCat(Cat cat)
        {
            _conn.Execute("UPDATE cats SET Name = @name, Age = @age WHERE PetID = @id",
             new { name = cat.Name, age = cat.Age, id = cat.PetID });
        }


        public void InsertCat(Cat catToInsert)
        {
            _conn.Execute("INSERT INTO cats (NAME, AGE, NEUTERED, GOODWITHOTHERPETS, SEX, PICTUREURL)  VALUES (@name, @age, @neutered, @goodwithotherpets, @sex, @pictureURL);",
                new { name = catToInsert.Name, age = catToInsert.Age, neutered = catToInsert.Neutered, goodwithotherpets = catToInsert.GoodWithOtherPets, sex = catToInsert.Sex, pictureURL = catToInsert.PictureURL });
        }

        public void DeleteCat(Cat cat)
        {
            _conn.Execute("DELETE FROM CATS WHERE PetID = @id;", new { id = cat.PetID });
        }
    }
}
