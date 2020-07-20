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
        public Boolean Editar(Endereco endereco) {
            Endereco e = BuscarPorId(endereco.Idcep);
            if (e != null) {
                e.Bairro = endereco.Bairro;
                e.CEP = endereco.CEP;
                e.Complemento = endereco.Complemento;
                e.Localidade = endereco.Localidade;
                e.Logradouro = endereco.Logradouro;
                e.UF = endereco.UF;
                _context.Update(e);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Endereco> Listar() {

            return _context.Enderecos.ToList();
        }

        public Boolean Excluir(int id) {
            Endereco e = BuscarPorId(id);
            if (e != null) {
                _context.Remove(e);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Endereco BuscarPorId(int id) {
            return _context.Enderecos.Find(id);
        }

        public Endereco BuscarPorCep(string cep) {
            Endereco e = _context.Enderecos.FirstOrDefault
                (x => x.CEP.Equals(cep));
            return e;
        }

    }
}
