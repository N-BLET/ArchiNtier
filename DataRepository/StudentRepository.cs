using Domaine.Models;
using IDataRepository;
using ORM;

namespace DataRepository
{
    public class StudentRepository : IStudentRepository
    {
        // Context DB
        private BddArchiNtierContext _context;

        // Injectionde dépendance par le constructeur
        public StudentRepository(){
            _context = BddArchiNtierContext.Instance; // On appelle le singleton
        }

        /// <summary>
        /// Création d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        /// <summary>
        /// Édition d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Student> EditStudent(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            existingStudent.Nom = student.Nom;
            existingStudent.Prenom = student.Prenom;

            _context.Students.Update(existingStudent);
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        /// <summary>
        /// Détails d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Student> DetailsStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            return student;
        }

        /// <summary>
        /// Suppression d'un étudiant
        /// </summary>
        /// <param name="student">objet Student</param>
        /// <returns>Task de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteStudent(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retourne la liste des étudiants
        /// </summary>
        /// <returns>Collection de type Student</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<Student> GetStudents(string searchString)
        {
            var students = from s in _context.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Nom.Contains(searchString));
            }

            return students;
        }

        /// <summary>
        /// Libère les ressources
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
           if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
