using System;

namespace CPFinalProjet.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }
    }

    public class Appearance
    {
        public int AppearanceId { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public int HeightInCM { get; set; }
    }

    public class Preference
    {
        public int PreferenceId { get; set; }
        public string FavoriteHobby { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteBand { get; set; }
        public int FavoriteNumber { get; set; }
    }

    public class Family
    {
        public int FamilyId { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public int NumberOfSiblings { get; set; }
        public int NumberOfPets { get; set; }
    }
}