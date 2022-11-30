using ApiSite.Modulos;
using ApiSite.Repositorio.Interface;
using ApiSite.Service;
using ApiSite.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Controllers
{
    public class TokenController: ControllerBase
    {

        private readonly ISqlRepositorio _RepositioDeUsuario;
        private readonly ITokenService _TokenService;

        public TokenController(ISqlRepositorio repositorio, ITokenService tokenService)
        {
            _RepositioDeUsuario = repositorio;

            _TokenService = tokenService;
        }


        //[HttpPost]
        //[Route("/login")]
        //[AllowAnonymous]
        //public ActionResult<string> Autenticar([FromBody] UsuarioVerificacaoDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var usuario = _RepositioDeUsuario.SqlComandoVerificarUsuario(model);


        //        if (usuario == null)
        //        {
        //            NotFound(new { message = "usuario ou senha invalidos!" });
        //        }
        //        //concertar aqui 
        //        var token = _TokenService.GenerateToken(usuario);
        //        model.senha = 0;

        //        return new
        //        {
        //            usuario = usuario,
        //            token = token
        //        }.ToString();
        //    }

        //    return BadRequest(new { message = "usuario ou senha invalidos!" });
        //}



    }
}
