using BusinessLayer;
using Castle.Windsor;
using Domaine.Models;
using IBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiArchiNtiers.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentApiController : Controller
    {
        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<IStudentBL>().ImplementedBy<StudentBL>());
            return container;
        }

        IStudentBL context = InitDependency().Resolve<IStudentBL>();

        // GET: StudentApiController
        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
       public IEnumerable<Student> Index(string? searchString)
        {
            return context.GetStudents(searchString).ToList<Student>();
        }

        // GET: StudentApiController/Details/5
        [HttpGet]
        [Route("{id}", Name = "GetDetails")]
        public Task<Student> Details(int id)
        {
            return context.DetailsStudent(id);
        }

        // POST: StudentApiController/Create
        [HttpPost]
        [Route("NewStudent", Name = "Create")]
        public Task<Student> Create([FromBody] StudentDto studentDto) 
        {
            return context.CreateStudent(new Student(studentDto));
        }

        // PACTH: StudentApiController/Edit/5
        [HttpPatch]
        [Route("EditStudent/{id}", Name = "Edit")]
        public Task<Student> Edit(int id, [FromBody] StudentDto studentDto)
        {
            return context.EditStudent(new Student(id, studentDto));
        }

        // DELETE: StudentApiController/Delete/5
        [HttpDelete]
        [Route("DeleteStudent/{id}", Name = "Delete")]
        public Task Delete(int id)
        {
            return context.DeleteStudent(new Student(id));
        }
    }
}
