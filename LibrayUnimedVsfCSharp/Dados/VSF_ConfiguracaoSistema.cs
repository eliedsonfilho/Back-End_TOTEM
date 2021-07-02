using System;

namespace Dados
{
    public class VSF_ConfiguracaoSistema
    {
        private int _autoId;
        private VSF_Sistema _sistema;

        //Dados Graficos
        private int _heigthBotaoPrincipal;
        private int _weightBotaoPrincipal;
        private int _heigthBotaoRodape;
        private int _weightBotaoRodape;
        private int _heigthBotao;
        private int _weightBotao;
        private int _fontePrincipal;
        private int _fonteTextInput;
        private int _fonteLabel;
		
		//DadosFuncionais
        private int _tempoProtege;
        private int _linhasConsulta;
        private int _numeroMaximoTentativas;

        private DateTime? _ultimaAtualizacao;

        public VSF_ConfiguracaoSistema()
        {
        }

        public virtual int AutoId
        {
            get { return _autoId; }
            set { _autoId = value; }
        }

        public virtual VSF_Sistema Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        public virtual int HeigthBotaoPrincipal
        {
            get { return _heigthBotaoPrincipal; }
            set { _heigthBotaoPrincipal = value; }
        }

        public virtual int WeightBotaoPrincipal
        {
            get { return _weightBotaoPrincipal; }
            set { _weightBotaoPrincipal = value; }
        }

        public virtual int HeigthBotaoRodape
        {
            get { return _heigthBotaoRodape; }
            set { _heigthBotaoRodape = value; }
        }

        public virtual int WeightBotaoRodape
        {
            get { return _weightBotaoRodape; }
            set { _weightBotaoRodape = value; }
        }

        public virtual int HeigthBotao
        {
            get { return _heigthBotao; }
            set { _heigthBotao = value; }
        }

        public virtual int WeightBotao
        {
            get { return _weightBotao; }
            set { _weightBotao = value; }
        }

        public virtual int FontePrincipal
        {
            get { return _fontePrincipal; }
            set { _fontePrincipal = value; }
        }

        public virtual int FonteTextInput
        {
            get { return _fonteTextInput; }
            set { _fonteTextInput = value; }
        }

        public virtual int FonteLabel
        {
            get { return _fonteLabel; }
            set { _fonteLabel = value; }
        }

        public virtual int TempoProtege
        {
            get { return _tempoProtege; }
            set { _tempoProtege = value; }
        }

        public virtual int LinhasConsulta
        {
            get { return _linhasConsulta; }
            set { _linhasConsulta = value; }
        }

        public virtual int NumeroMaximoTentativas
        {
            get { return _numeroMaximoTentativas; }
            set { _numeroMaximoTentativas = value; }
        }

        public virtual DateTime? UltimaAtualizacao
        {
            get { return _ultimaAtualizacao; }
            set { _ultimaAtualizacao = value; }
        }
    }
}