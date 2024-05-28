using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Models
{
    public partial class Student
    {
        public Student() { }

        public Student(int id)
        {
            this.Id = id;
            this.Nom = "";
            this.Prenom = "";
        }

        public Student(StudentDto studentDto)
        {
            this.Nom = studentDto.Nom;
            this.Prenom = studentDto.Prenom;
        }

        public Student(int id, StudentDto studentDto)
        {
            this.Id = id;
            this.Nom = studentDto.Nom;
            this.Prenom = studentDto.Prenom;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
    }

    public partial class StudentDto
    {
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
    }
}
