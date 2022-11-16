using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuten.Controllers
{
    public class UsersController : ControllerBase
    {

        [HttpGet]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "anonimo";



        [HttpGet]
        [Route("api/funcionario")]
        [Authorize(Roles = "funcionario,gerente")]
        public string Employee() => "funcionario";


        [HttpGet]
        [Route("api/gerente")]
        [Authorize(Roles = "gerente")]
        public string Manager() => "gerente";


    }
}
