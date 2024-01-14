using Business.Abstarct;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    [ApiController]
    [Route("api/colors")]
    public class ColorsController : Controller
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet()]
        public IActionResult GetAll()
        { 
            var result = _colorService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result= _colorService.GetById(id);
            return Ok(result);
        }
        [HttpPost()]
            public void Add(Color color)
        {
            _colorService.Add(color);
        }
        [HttpPut()]
        public void Update(Color color)
        {
            _colorService.Update(color);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _colorService.Delete(id);
        }
    }
}
