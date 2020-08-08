using LanguagesCourse.Model.Dto;
using LanguagesCourse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LanguagesCourse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpPost]
        public ActionResult Save([FromBody] CourseDto courseDto)
        {
            _courseService.Save(courseDto);
            return StatusCode(201, "Salvo com sucesso");
        }
        
        [HttpPut]
        public ActionResult Update([FromBody] CourseDto courseDto)
        {
            _courseService.Update(courseDto);
            return StatusCode(201, "Salvo com sucesso");
        }

        //[HttpGet]
        //public ActionResult Test()
        //{
        //    return Ok(_courseService.GetAll());
        //}
         
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_courseService.GetAll());
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_courseService.Get(id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _courseService.Delete(id);
            return Ok("Excluido com sucesso");
        }
    }
}