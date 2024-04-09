namespace PetStoreCRUDWebsite.Models
{
    public class Cat
    {

        public Cat() 
        {
            Name = "";
            Neutered = "";
            GoodWithOtherPets = "";
            PictureURL = "";
            Sex = "";
        }

        public int PetID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Neutered { get; set; }
        public string GoodWithOtherPets { get; set; }
        public string PictureURL { get; set; }
        public string Sex { get; set; }


    }

}
