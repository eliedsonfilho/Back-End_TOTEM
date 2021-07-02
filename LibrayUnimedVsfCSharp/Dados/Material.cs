using System;

namespace Dados
{
    public class Material
    {
        private string _codigoTnumm;
        private string _codigoTiss;
        private string _nomeComercial;
        private string _descricaoProduto;
        private string _situacao;
        private string _nomeFabricante;
        private string _nomeImportador;
        private string _origem;
        private string _especialidadeProduto;
        private string _classificacaoAnvisa;
        private string _apresentacaoComercial;
        private string _unidadeProduto;
        private string _cNPJFabricante;
        private string _registroAnvisa;
        private string _validadeRegAnvisa;
        private string _motivoInativaAtiva;
        private string _precoFabrica;
        private string _vlrMaxIntNac;
        private string _dataObrigatoriedadeProduto;
        private string _observacoes;

        public virtual string CodigoTiss
        {
            get { return _codigoTiss; }
            set { _codigoTiss = value; }
        }

        public virtual string CodigoTnumm
        {
            get { return _codigoTnumm; }
            set { _codigoTnumm = value; }
        }

        public virtual string NomeComercial
        {
            get { return _nomeComercial; }
            set { _nomeComercial = value; }
        }

        public virtual string DescricaoProduto
        {
            get { return _descricaoProduto; }
            set { _descricaoProduto = value; }
        }

        public virtual string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        public virtual string NomeFabricante
        {
            get { return _nomeFabricante; }
            set { _nomeFabricante = value; }
        }

        public virtual string NomeImportador
        {
            get { return _nomeImportador; }
            set { _nomeImportador = value; }
        }

        public virtual string Origem
        {
            get { return _origem; }
            set { _origem = value; }
        }

        public virtual string EspecialidadeProduto
        {
            get { return _especialidadeProduto; }
            set { _especialidadeProduto = value; }
        }

        public virtual string ClassificacaoAnvisa
        {
            get { return _classificacaoAnvisa; }
            set { _classificacaoAnvisa = value; }
        }

        public virtual string ApresentacaoComercial
        {
            get { return _apresentacaoComercial; }
            set { _apresentacaoComercial = value; }
        }

        public virtual string UnidadeProduto
        {
            get { return _unidadeProduto; }
            set { _unidadeProduto = value; }
        }

        public virtual string CNpjFabricante
        {
            get { return _cNPJFabricante; }
            set { _cNPJFabricante = value; }
        }

        public virtual string RegistroAnvisa
        {
            get { return _registroAnvisa; }
            set { _registroAnvisa = value; }
        }

        public virtual string ValidadeRegAnvisa
        {
            get { return _validadeRegAnvisa; }
            set { _validadeRegAnvisa = value; }
        }

        public virtual string MotivoInativaAtiva
        {
            get { return _motivoInativaAtiva; }
            set { _motivoInativaAtiva = value; }
        }

        public virtual string PrecoFabrica
        {
            get { return _precoFabrica; }
            set { _precoFabrica = value; }
        }

        public virtual string VlrMaxIntNac
        {
            get { return _vlrMaxIntNac; }
            set { _vlrMaxIntNac = value; }
        }

        public virtual string DataObrigatoriedadeProduto
        {
            get { return _dataObrigatoriedadeProduto; }
            set { _dataObrigatoriedadeProduto = value; }
        }

        public virtual string Observacoes
        {
            get { return _observacoes; }
            set { _observacoes = value; }
        }
    }
}