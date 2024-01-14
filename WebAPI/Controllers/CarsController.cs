using Business.Abstarct;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")] Api yazım kurallarında uymadığı için asagıdaki satndart olanı tercih ediyoruz
    [Route("api/cars")]
    public class CarsController : Controller
    {
        //private IBrandService _service = new BrandManager(new EfBrandDal());
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet("/details")]
        public IActionResult GetDetails()
        {
            var result=_service.GetCarDetails();
            return Ok(result);
        }

        //[HttpGet("getAll")]
        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }
     
       
        //[HttpGet("getById")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }
        [HttpGet("brand")]

        //[HttpPost("add")]
        [HttpPost()]
        public void Add(Car car)
        {

            _service.Add(car);
        }

        //[HttpPut("update")]
        [HttpPut()]
        public void Update(Car car)
        {
            _service.Update(car);
        }
        //[HttpDelete("delete")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
