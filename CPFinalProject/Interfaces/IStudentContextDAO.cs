using System.Collections.Generic;
using CPFinalProjet.Models;

namespace CPFinalProject.Interfaces
{
    public interface IStudentContextDAO
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int? id);
        int? RemoveStudentById(int id);
        int? UpdateStudent(Student student);
        int? AddStudent(Student student);
    }

    public interface IAppearanceContextDAO
    {
        List<Appearance> GetAllAppearances();
        Appearance GetAppearanceById(int? id);
        int? RemoveAppearanceById(int id);
        int? UpdateAppearance(Appearance appearance);
        int? AddAppearance(Appearance appearance);
    }

    public interface IPreferenceContextDAO
    {
        List<Preference> GetAllPreferences();
        Preference GetPreferenceById(int? id);
        int? RemovePreferenceById(int id);
        int? UpdatePreference(Preference preference);
        int? AddPreference(Preference preference);
    }

    public interface IFamilyContextDAO
    {
        List<Family> GetAllFamilies();
        Family GetFamilyById(int? id);
        int? RemoveFamilyById(int id);
        int? UpdateFamily(Family family);
        int? AddFamily(Family family);
    }
}