﻿namespace Dados
{
    public class GrauDepPessoa
    {
        private int _codigo;
        private string _nome;

        public GrauDepPessoa()
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
    }
}