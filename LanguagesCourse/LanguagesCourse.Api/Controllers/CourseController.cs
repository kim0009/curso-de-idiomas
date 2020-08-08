using LanguagesCourse.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult Save()
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return Ok(_courseService.Test());
        }


    }
}