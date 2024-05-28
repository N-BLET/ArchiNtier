﻿using Domaine.Models;

namespace IDataRepository
{
    public interface IStudentRepository : IDisposable // Pattern de gestion de la mémoire
    {
        // Méthode qui renvoit  la liste des étudiants
        IQueryable<Student> GetStudents(string? searchString);

        // Méthode pour créer un étudiant
        Task<Student> CreateStudent(Student student);
        // Méthode pour éditer un étudiant
        Task<Student> EditStudent(Student student);
        // Méthode pour récupérer les détails d'un étudiant
        Task<Student> DetailsStudent(int id);
        // Méthode pour supprimer un étudiant
        Task DeleteStudent(Student student);


    }
}
