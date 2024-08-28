using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.API.Controllers // Plural form
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = new string[] { "balaji", "raja" };
            return Ok(students);
        }
    }
}
