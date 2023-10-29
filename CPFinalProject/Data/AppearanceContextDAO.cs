using System;
using System.Collections.Generic;
using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;

namespace CPFinalProject.Data
{
    public class AppearanceContextDAO : IAppearanceContextDAO
    {
        private StudentsContext _context;

        public AppearanceContextDAO(StudentsContext context)
        {
            _context = context;
        }

        public List<Appearance> GetAllAppearances()
        {
            return _context.Appearances.ToList();
        }

        public Appearance GetAppearanceById(int? id)
        {
            return _context.Appearances.Where(x => x.AppearanceId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveAppearanceById(int id)
        {
            var appearance = this.GetAppearanceById(id);
            if (appearance == null) return null;
            try
            {
                _context.Appearances.Remove(appearance);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? UpdateAppearance(Appearance appearance)
        {
            var appearanceToUpdate = this.GetAppearanceById(appearance.AppearanceId);

            if (appearanceToUpdate == null)
                return null;

            appearanceToUpdate.EyeColor = appearance.EyeColor;
            appearanceToUpdate.HairColor = appearance.HairColor;
            appearanceToUpdate.HeightInCM = appearance.HeightInCM;
            appearanceToUpdate.SkinColor = appearance.SkinColor;
            try
            {
                _context.Appearances.Update(appearanceToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? AddAppearance(Appearance appearance)
        {
            var appearances = _context.Appearances.Where(x => x.EyeColor.Equals(appearance.EyeColor)
                && x.HairColor.Equals(appearance.HairColor)
                && x.HeightInCM.Equals(appearance.HeightInCM)
                && x.SkinColor.Equals(appearance.SkinColor)).FirstOrDefault();

            if(appearances != null)
                return null;

            try
            {
                _context.Appearances.Add(appearance);
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