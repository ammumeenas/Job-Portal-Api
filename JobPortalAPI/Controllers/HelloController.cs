using System;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{

    [ApiController]
    [Route("hello")]
    public class HelloController : ControllerBase
    {
        public HelloController()
        {
        }

        [HttpGet]
        [Route("student")]
        public Student getHello() {
            Student stu = new Student();
            stu.age = 22;
            stu.name = "vv";
            return stu;
                 
        }
    }

    public class Student {
        public String name { get; set; }
        public int age { get; set; }
    }
}
