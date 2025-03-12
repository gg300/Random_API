using Microsoft.AspNetCore.Mvc;
using test.Repository;
using test.Entities;
namespace test.Controller;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(_studentRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = _studentRepository.GetById(id);
        if(student == null)
            return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        var exist = _studentRepository.GetById(student.Id);
        if(exist!=null)
            return BadRequest("Student already exists");
        _studentRepository.Add(student);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateStudent(Student student)
    {
        _studentRepository.Update(student);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentRepository.Delete(id);
        return Ok();
    }

}