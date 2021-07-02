using System;

namespace Dados
{
    public class Medicamento
    {
        private string _validadeRegAnvisa;
        private string _unidadeFracao;
        private string _situacao;
        private string _registroAnvisa;
        private string _principioAtivo;
        private string _precoICMS19;
        private string _precoICMS18;
        private string _precoICMS17;
        private string _origem;
        private string _observacoes;
        private string _nomeFabricante;
        private string _nomeComercial;
        private string _motivoInativaAtiva;
        private string _grupoFarmacologico;
        private string _generico;
        private string _formaFarmaceutica;
        private string _dataObrigatoriedadeProduto;
        private string _codigoTnumm;
        private string _codigoTiss;
        private string _codigoBrasindice;
        private string _classeFarmacologica;
        private string _cNPJFabricante;

        public virtual string ValidadeRegAnvisa
        {
            get { return _validadeRegAnvisa; }
            set { _validadeRegAnvisa = value; }
        }

        public virtual string UnidadeFracao
        {
            get { return _unidadeFracao; }
            set { _unidadeFracao = value; }
        }

        public virtual string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        public virtual string RegistroAnvisa
        {
            get { return _registroAnvisa; }
            set { _registroAnvisa = value; }
        }

        public virtual string PrincipioAtivo
        {
            get { return _principioAtivo; }
            set { _principioAtivo = value; }
        }

        public virtual string PrecoIcms19
        {
            get { return _precoICMS19; }
            set { _precoICMS19 = value; }
        }

        public virtual string PrecoIcms18
        {
            get { return _precoICMS18; }
            set { _precoICMS18 = value; }
        }

        public virtual string PrecoIcms17
        {
            get { return _precoICMS17; }
            set { _precoICMS17 = value; }
        }

        public virtual string Origem
        {
            get { return _origem; }
            set { _origem = value; }
        }

        public virtual string Observacoes
        {
            get { return _observacoes; }
            set { _observacoes = value; }
        }

        public virtual string NomeFabricante
        {
            get { return _nomeFabricante; }
            set { _nomeFabricante = value; }
        }

        public virtual string NomeComercial
        {
            get { return _nomeComercial; }
            set { _nomeComercial = value; }
        }

        public virtual string MotivoInativaAtiva
        {
            get { return _motivoInativaAtiva; }
            set { _motivoInativaAtiva = value; }
        }

        public virtual string GrupoFarmacologico
        {
            get { return _grupoFarmacologico; }
            set { _grupoFarmacologico = value; }
        }

        public virtual string Generico
        {
            get { return _generico; }
            set { _generico = value; }
        }

        public virtual string FormaFarmaceutica
        {
            get { return _formaFarmaceutica; }
            set { _formaFarmaceutica = value; }
        }

        public virtual string DataObrigatoriedadeProduto
        {
            get { return _dataObrigatoriedadeProduto; }
            set { _dataObrigatoriedadeProduto = value; }
        }

        public virtual string CodigoTnumm
        {
            get { return _codigoTnumm; }
            set { _codigoTnumm = value; }
        }

        public virtual string CodigoTiss
        {
            get { return _codigoTiss; }
            set { _codigoTiss = value; }
        }

        public virtual string CodigoBrasindice
        {
            get { return _codigoBrasindice; }
            set { _codigoBrasindice = value; }
        }

        public virtual string ClasseFarmacologica
        {
            get { return _classeFarmacologica; }
            set { _classeFarmacologica = value; }
        }

        public virtual string CNpjFabricante
        {
            get { return _cNPJFabricante; }
            set { _cNPJFabricante = value; }
        }
    }
}