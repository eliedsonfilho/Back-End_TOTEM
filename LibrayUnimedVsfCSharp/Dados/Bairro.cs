using System;

namespace Dados
{
    public class Bairro
    {
        private int _codigo;
        private string _nome;
        private string _nomeReduzido;
        private CidadePais _cidade;

        public Bairro()
        {
        }

        public virtual int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string NomeReduzido
        {
            get { return _nomeReduzido; }
            set { _nomeReduzido = value; }
        }

        public virtual CidadePais Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
    }
}