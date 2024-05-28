using DataRepository;
using Domaine.Models;
using IBusinessLayer;
using IDataRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class StudentBL : IStudentBL
    {
        // On doit passer par l'interface de la couche DataAccessLayer
        IStudentRepository _dataFactory;

        // Constructeur visible - celui qui sera appelé
        public StudentBL() : this(new StudentRepository())
        {
        }

        // Constructeur privé
        public StudentBL(IStudentRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }

        /// <summary>
        /// Création d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Student> CreateStudent(Student student)
        {
            return _dataFactory.CreateStudent(student);
        }

        /// <summary>
        /// Retourne la liste des étudiants
        /// </summary>
        /// <returns>Collection de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>   
        public IQueryable<Student> GetStudents(string? searchString)
        {
                return _dataFactory.GetStudents(searchString);
        }

        /// <summary>
        /// Édition d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Student> EditStudent(Student student)
        {
            return _dataFactory.EditStudent(student);
        }

        /// <summary>
        /// Détails d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Student> DetailsStudent(int id)
        {
            return _dataFactory.DetailsStudent(id);
        }

        /// <summary>
        /// Suppression d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteStudent(Student student)
        {
            return _dataFactory.DeleteStudent(student);
        }

        /// <summary>
        /// Libère les ressources
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            if (_dataFactory != null)
            {
                _dataFactory.Dispose();
            }
        }
    }

}
