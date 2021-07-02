using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Repositorios;

namespace Negocios
{
    public class NegocioFeriado
    {
        private RepositorioFeriado _repositorioFeriado;

        public NegocioFeriado()
        {
            _repositorioFeriado = new RepositorioFeriado();
        }

        public Feriado ObterFeriadoPorData(DateTime data)
        {
            return _repositorioFeriado.ObterPorData(data, true);
        }

        public bool VerificaFeriado(DateTime data)
        {
            return ObterFeriadoPorData(data.Date) != null;
        }

        public bool DiaUtil(DateTime dataReferencia)
        {
            // Se a data de referencia cair no sábado ou domingo, retorna falso
            if (dataReferencia.DayOfWeek.Equals(DayOfWeek.Saturday) || dataReferencia.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                return false;
            }

            // Se a data de referencia cair no dia que for feriado, retorna falso, se for dia util, retorna verdadeiro
            NegocioFeriado negocioFeriado = new NegocioFeriado();
            return !negocioFeriado.VerificaFeriado(dataReferencia);
        }

        public DateTime ProximoDiaUtil(DateTime dataReferencia)
        {
            dataReferencia = dataReferencia.AddDays(1);
            // Enquanto a data de referencia não for um dia util, incrementa um dia nesta data de referencia
            while (!DiaUtil(dataReferencia))
            {
                dataReferencia = dataReferencia.AddDays(1);
            }

            return dataReferencia;
        }
    }
}