using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BuscaAPI.DAL;
using BuscaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// Rafael Benedet Fernandes

namespace BuscaAPI.Controllers {
    public class ConsultaController : Controller {

        private readonly ConsultaDAO _consultaDAO;

        public ConsultaController(ConsultaDAO consultaDAO) {

            _consultaDAO = consultaDAO;
        }

        public IActionResult Index() {

            Endereco e = new Endereco();

            if (TempData["Endereco"] != null) {

                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                _consultaDAO.Cadastrar(endereco);
                return View(endereco);
            }
            return View();
        }



        [HttpPost]
        public IActionResult ConsultaPorCEP(String txtCEP) {


            string url =
                $@"https://viacep.com.br/ws/{txtCEP}/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);
            return RedirectToAction("Index");
        }
    }
}