using System;
using System.Collections.Generic;
using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;

namespace CPFinalProject.Data
{
    public class PreferenceContextDAO : IPreferenceContextDAO
    {
        private StudentsContext _context;

        public PreferenceContextDAO(StudentsContext context)
        {
            _context = context;
        }

        public List<Preference> GetAllPreferences()
        {
            return _context.Preferences.ToList();
        }

        public Preference GetPreferenceById(int? id)
        {
            return _context.Preferences.Where(x => x.PreferenceId.Equals(id)).FirstOrDefault();
        }

        public int? RemovePreferenceById(int id)
        {
            var preference = this.GetPreferenceById(id);
            if (preference == null) return null;
            try
            {
                _context.Preferences.Remove(preference);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? UpdatePreference(Preference preference)
        {
            var preferenceToUpdate = this.GetPreferenceById(preference.PreferenceId);

            if (preferenceToUpdate == null)
                return null;

            preferenceToUpdate.FavoriteHobby = preference.FavoriteHobby;
            preferenceToUpdate.FavoriteFood = preference.FavoriteFood;
            preferenceToUpdate.FavoriteBand = preference.FavoriteBand;
            preferenceToUpdate.FavoriteNumber = preference.FavoriteNumber;
            try
            {
                _context.Preferences.Update(preferenceToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? AddPreference(Preference preference)
        {
            var preferences = _context.Preferences.Where(x => x.FavoriteHobby.Equals(preference.FavoriteHobby)
                && x.FavoriteFood.Equals(preference.FavoriteFood)
                && x.FavoriteBand.Equals(preference.FavoriteBand)
                && x.FavoriteNumber.Equals(preference.FavoriteNumber)).FirstOrDefault();

            if(preferences != null)
                return null;

            try
            {
                _context.Preferences.Add(preference);
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