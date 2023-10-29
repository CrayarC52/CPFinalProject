using System;
using System.Collections.Generic;
using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;

namespace CPFinalProject.Data
{
    public class FamilyContextDAO : IFamilyContextDAO
    {
        private StudentsContext _context;

        public FamilyContextDAO(StudentsContext context)
        {
            _context = context;
        }

        public List<Family> GetAllFamilies()
        {
            return _context.Families.ToList();
        }

        public Family GetFamilyById(int? id)
        {
            return _context.Families.Where(x => x.FamilyId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveFamilyById(int id)
        {
            var family = this.GetFamilyById(id);
            if (family == null) return null;
            try
            {
                _context.Families.Remove(family);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? UpdateFamily(Family family)
        {
            var familyToUpdate = this.GetFamilyById(family.FamilyId);

            if (familyToUpdate == null)
                return null;

            familyToUpdate.MotherName = family.MotherName;
            familyToUpdate.FatherName = family.FatherName;
            familyToUpdate.NumberOfSiblings = family.NumberOfSiblings;
            familyToUpdate.NumberOfPets = family.NumberOfPets;
            try
            {
                _context.Families.Update(familyToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? AddFamily(Family family)
        {
            var families = _context.Families.Where(x => x.MotherName.Equals(family.MotherName)
                && x.FatherName.Equals(family.FatherName)
                && x.NumberOfSiblings.Equals(family.NumberOfSiblings)
                && x.NumberOfPets.Equals(family.NumberOfPets)).FirstOrDefault();

            if(families != null)
                return null;

            try
            {
                _context.Families.Add(family);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}