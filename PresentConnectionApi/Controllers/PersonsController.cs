using Microsoft.AspNetCore.Mvc;

namespace PresentConnectionApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    static List<Person> _persons = new List<Person>()  
    {  
        new Person( 1, "Petras Petraitis", 1.86, 21, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"),  
        new Person( 2, "Jonas Jonaitis", 1.9, 20, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam"), 
        new Person( 3, "Antanas Antanaitis", 1.95, 24, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"), 
        new Person( 4, "Vardas Pavardenis", 1.6, 19, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam"),   
        new Person( 5, "Petras Antanaitis", 2.0, 22, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto")
    };  

    private readonly ILogger<PersonsController> _logger;

    public PersonsController(ILogger<PersonsController> logger)
        => _logger = logger;


    [HttpGet]
    public IEnumerable<Person> Get()
    {
        return _persons;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var person = _persons.Find(person1 => person1.Id == id);
        return person == null ? NotFound() : Ok(person);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create(Person person)
    {
        person.Id = _persons.Last().Id + 1;
        _persons.Add(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }
}