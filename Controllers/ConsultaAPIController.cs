using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuscaAPI.DAL;
using BuscaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaAPI.Controllers {
    [Route("api/Endereco")]
    [ApiController]
    public class ConsultaAPIController : ControllerBase {
        private readonly ConsultaDAO _consultaDAO;

        public ConsultaAPIController(ConsultaDAO consultaDAO) {

            _consultaDAO = consultaDAO;
        }


        // GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar() {
            return Ok(_consultaDAO.Listar());
        }

        // GET: /api/Endereco/ListarEndereco/81730-000
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult ListarPorCep([FromRoute] string cep) {
            Endereco e = _consultaDAO.BuscarPorCep(cep);
            if (e != null) {
                return Ok(e);
            }
            else {
                return NotFound(new { msg = "Cep não encontrado no banco" });
            }
        }

        // POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastrar(Endereco endereco) {
            _consultaDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        // PUT: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Editar(Endereco endereco) {
            if (_consultaDAO.Editar(endereco)) {
                // pode retornar msg ou o objeto Endereco
                return Ok(new { msg = "Endereço editado com sucesso" });
                // return Ok(endereco);
            }
            return NotFound(new { msg = "Id do endereço não encontrado!" });
        }

        // DELETE: /api/Endereco/DeletarEndereco/2
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult DeleteId([FromRoute] int id) {
            if (_consultaDAO.Excluir(id)) {
                return Ok(new { msg = "Endereço do id: " + id + " deletado com sucesso!" });
            }
            return NotFound(new { msg = "Id do endereço não encontrado!" });
        }

    }

}
