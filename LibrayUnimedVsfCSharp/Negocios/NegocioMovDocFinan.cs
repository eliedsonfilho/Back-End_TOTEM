using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioMovDocFinan
    {
        private RepositorioMovDocFinan _repositorioMovDocFinan;
        private MovDocFinan _movDocFinan;

        public NegocioMovDocFinan()
        {
            _repositorioMovDocFinan = new RepositorioMovDocFinan();
        }

        public MovDocFinan InserirPorDocFinan(int AutoIdDocFinan)
        {
            _movDocFinan = new MovDocFinan();

            _movDocFinan.DocFinanceiro = AutoIdDocFinan;
            _movDocFinan.DataMov = DateTime.Now;
            _movDocFinan.TelosRgDt = DateTime.Now;
            _movDocFinan.TelosUpDt = DateTime.Now;
            _movDocFinan.TelosRgUs = "TOTEM";
            _movDocFinan.TelosUpUs = "TOTEM";
            _movDocFinan.Tipo = 30; //Motivo Emissão
            _movDocFinan.Complemento = "Impressão realizada no TOTEM";
            
            return _repositorioMovDocFinan.Inserir(_movDocFinan);


        }
    }
}
