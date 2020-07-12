using BuscaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaAPI.DAL {
    public class ConsultaDAO {

        private readonly Context _context;

        public ConsultaDAO(Context context) {

            _context = context;

        }


        public void Cadastrar(Endereco endereco) {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }
    }
}

