using System;
using System.Threading;

namespace Util
{
    public class GeradorCodigo
    {
        public GeradorCodigo()
        {
        }

        public static string GerarCodigo(int qtdDigitos)
        {
            string retorno=null;
            if(qtdDigitos > 0)
            {
                for (int i = 0; i <= qtdDigitos - 1; i++)
                {
                    DateTime dataMomento = DateTime.Now;
                    retorno += GerarDigito(dataMomento.Ticks.ToString());
                    Thread.Sleep(1);
                }
            }
            return retorno ;
        }

        public static string GerarCodigo(int qtdDigitos, string cadeia)
        {
            string retorno = null;
            if((qtdDigitos > 0) && (cadeia.Length > 0))
            {
                for (int i = 0; i <= qtdDigitos - 1; i++)
                {
                    retorno += GerarDigito(cadeia);
                }
            }
            return retorno;
        }

        public static string GerarDigito(string codigo)
        {
            int Peso = 2;
            int Soma = 0;
            int pNumero = 0;

            for (int i = codigo.Length - 1; i >= 0; i--)
            {
                Soma += Peso * Convert.ToInt32(codigo[i].ToString());

                if(Peso == 9)
                {
                    Peso = 2;
                }
                else
                {
                    Peso++;
                }
            }

            pNumero = 11 - (Soma % 11);

            if (pNumero > 9)
                pNumero = 0;

            return pNumero.ToString();
        }

        private static string GerarNumeroAutenticacao()
        {
            int length = 6;
            System.Security.Cryptography.RandomNumberGenerator rng =
                System.Security.Cryptography.RandomNumberGenerator.Create();
            char[] chars = new char[length];
            //based on your requirment you can take only alphabets or number     
            string validChars = "ABCEDFGHIJKLMNOPQRSTUVWXYZ1234567890";
            for (int i = 0; i < length; i++)
            {
                byte[] bytes = new byte[1];
                rng.GetBytes(bytes);
                Random rnd = new Random(bytes[0]);
                chars[i] = validChars[rnd.Next(0, 35)];
            }
            return (new string(chars));
        }
    
    }
}