using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dados;

namespace Repositorios
{
    public class RepositorioVSF_ConfiguracaoFinanceira : Repositorio, IRepositorio<VSF_ConfiguracaoFinanceira, int>
    {
        public VSF_ConfiguracaoFinanceira ObterPorId(int autoIdBoleto, bool lazy)
        {
            throw new NotImplementedException();
        }

        public VSF_ConfiguracaoFinanceira Obter(bool lazy)
        {
            IDbCommand command;
            //IDataReader dataReaderTmp;
            VSF_ConfiguracaoFinanceira objetoPesquisado = new VSF_ConfiguracaoFinanceira();

            //Executando a pesquisa
            try
            {   //Consulta PercentualJuros - Cardio
                command = new SqlCommand(@"SELECT a.*, b.*, c.*, d.*, e.* FROM

                                    --(a) PercentualJuros 
                                    (SELECT CalcJurosTipoNeg.PercFixoJuros PercentualJuros FROM CalcJurosTipoNeg
                                    WHERE CalcJurosTipoNeg.AutoId = (SELECT MAX(CalcJurosTipoNeg.AutoId) FROM CalcJurosTipoNeg)) a,

                                    --(b) PercentualMulta 
                                    (SELECT Percentual PercentualMulta FROM CalcMultasTipoNeg
                                    WHERE CalcMultasTipoNeg.AutoId = (SELECT MAX(CalcMultasTipoNeg.AutoId) FROM CalcMultasTipoNeg)) b,

                                    --(c) LimiteDiasVencido 
                                    (SELECT LimiteDiasVencido FROM VSF_ConfiguracaoFinanceira) c,

                                    --(d) InstrucaoBoleto 
                                    (SELECT ObservacaoFinanceira.Observacao InstrucoesBoleto
                                    FROM ObservacaoFinanceira INNER JOIN
                                    ClasseContratoFinanceiro ON ObservacaoFinanceira.ClasseContratoFinanceiro = ClasseContratoFinanceiro.AutoId
                                    WHERE (ClasseContratoFinanceiro.Codigo = 9998) AND (ObservacaoFinanceira.Imprime = 1) 
                                    AND ((ObservacaoFinanceira.InicioVigencia <= getdate()) AND (ObservacaoFinanceira.FimVigencia is null))) d,

                                    --(e) QtdOpcoesVencimento 
                                    (SELECT QtdOpcoesVencimento FROM VSF_ConfiguracaoFinanceira) e");

                objetoPesquisado = GerenciadorConexaoBanco.GetInstancia(EnumTipoBanco.SqlServer).ExecutarConsultaObject(command, objetoPesquisado, lazy);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return objetoPesquisado;

        } 

        public IList<VSF_ConfiguracaoFinanceira> ObterTodos(bool lazy)
        {
            throw new NotImplementedException();
        }

        public IList<VSF_ConfiguracaoFinanceira> ObterTodos(VSF_ConfiguracaoFinanceira objectPesquisado, bool lazy)
        {
            throw new NotImplementedException();
        }

    }
}
