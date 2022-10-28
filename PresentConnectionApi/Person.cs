using System.ComponentModel.DataAnnotations;

namespace PresentConnectionApi;

public class Person
{
    

    public int Id { get; set; }
    public string? NameSurname { get; set; }
    public double Hight { get; set; }
    public int Age { get; set; }
    public string? Description { get; set; }
    
    public Person(int id, string? nameSurname, double hight, int age, string? description)
    {
        Id = id;
        NameSurname = nameSurname;
        Hight = hight;
        Age = age;
        Description = description;
    }

    public Person()
    {
    }
}