using ApiAuten.Repositorios;
using ApiAuten.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuten.Controllers
{
    public class TokenController: ControllerBase
    {

        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromBody] Models.Users model)
        {
            //recuperar Usuario
            var user = UsersRepository.Get(model.Nome, model.Password);
            //verificar se ele existe
            if (user == null)
                return NotFound(new { message = "usuario ou senha invalidos!" });
            //gerar o token
            var token = TokenService.GenerateToken(user);
            //ocultar senha
            user.Password =0;

            return new
            {
                user = user,
                token = token
            };



        }



    }

}




