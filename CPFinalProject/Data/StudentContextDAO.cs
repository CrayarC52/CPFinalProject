using System;
using System.Collections.Generic;
using System.Linq;
using CPFinalProject.Interfaces;
using CPFinalProjet.Models;

namespace CPFinalProject.Data
{
    public class StudentContextDAO : IStudentContextDAO
    {
        private StudentsContext _context;

        public StudentContextDAO(StudentsContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int? id)
        {
            return _context.Students.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveStudentById(int id)
        {
            var student = this.GetStudentById(id);
            if (student == null) return null;
            try
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? UpdateStudent(Student student)
        {
            var studentToUpdate = this.GetStudentById(student.Id);

            if (studentToUpdate == null)
                return null;

            studentToUpdate.FullName = student.FullName;
            studentToUpdate.Birthdate = student.Birthdate;
            studentToUpdate.CollegeProgram = student.CollegeProgram;
            studentToUpdate.YearInProgram = student.YearInProgram;
            try
            {
                _context.Students.Update(studentToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? AddStudent(Student student)
        {
            var students = _context.Students.Where(x => x.Birthdate.Equals(student.Birthdate) && x.FullName.Equals(student.FullName)).FirstOrDefault();

            if(students != null)
                return null;

            try
            {
                _context.Students.Add(student);
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