using Business.Abstarct;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService; //loosely coupled (Gevşek bağımlılık) 

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet()]
        public IActionResult GetAll() 
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
    
          

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var result= _brandService.GetById(id);
            return Ok(result);
        }

        [HttpPost()]
        public void Add(Brand brand)
        {
            _brandService.Add(brand);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _brandService.Delete(id);
        }
        [HttpPut()]
        public void Update(Brand brand)
        { _brandService.Update(brand);}

    }
}
