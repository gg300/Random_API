using test.Entities;

namespace test.Repository;

public interface IStudentRepository
{
    Student? GetById(int id);
    List<Student> GetAll();
    void Add(Student student);
    void Delete(int id);
    void Update (Student student);
}