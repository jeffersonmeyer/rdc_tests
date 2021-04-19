using Microsoft.AspNetCore.Mvc;
using RDC.Tests.PersonalFinances.DataAccess;
using RDC.Tests.PersonalFinances.Models;
using System;
using System.Collections.Generic;

namespace RDC.Tests.PersonalFinances.WebApi.Controllers
{
    [ApiController]
    public class LancamentosController : Controller
    {
        [HttpPost]
        [Route("api/lancamentos")]
        public IActionResult InserirLancamentos([FromBody] IEnumerable<Lancamento> lancamentos)
        {
            try
            {
                new LancamentosDataAccess().InserirLancamentos(lancamentos);
                return Ok(RetornoCustomizado("Dados inseridos com sucesso", null));
            }
            catch (Exception e)
            {

                return BadRequest(RetornoCustomizado("Ocorreu um erro ao tentar inserir os lançamentos", e));
            }
        }

        [HttpGet]
        [Route("api/lancamentos/{periodo}")]
        public IActionResult ObterLancamentos(DateTime periodo)
        {
            //if (string.IsNullOrEmpty(periodo))
            //{
            //    return BadRequest(ErroCustomizado("Período inválido",null));
            //}

            //var periodos = periodo.Split("-");


            try
            {
                var resultado = new LancamentosDataAccess().ObterTotalizadoresELancamentos(periodo.Year, periodo.Month);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(RetornoCustomizado("Ocorreu um erro ao obter os lançamentos e totalizadores", e));
            }
        }

        private object RetornoCustomizado(string mensagem, Exception e)
        {
            var erro = new
            {
                mensagem,
                erro = e?.Message
            };

            return erro;
        }
    }
}
