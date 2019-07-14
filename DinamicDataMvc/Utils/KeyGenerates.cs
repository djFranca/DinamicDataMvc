using DinamicDataMvc.Interfaces;
using System;

namespace DinamicDataMvc.Utils
{
    public class KeyGenerates : IKeyGenerates
    {
        private readonly Random _Random;
        private readonly int _IdLength;
        private string Key { get; set; }

        public KeyGenerates(int IdLength)
        {
            _Random = new Random();
            _IdLength = IdLength;
        }

        /*
         * Método que permite obter a chave gerada;
         */
        public string GetKey()
        {
            return Key;
        }


        /*
         * Método que permite gerar uma chave composta por 256 bits = 64 (8x8) caracteres, dos quais são 96 bits = 24 (8x3) caracteres
         * Esta chave será utilizada para identificar as propriedades existentes num campo que pertençe a um processo;
         * A variavel Key armazena os 24 caracteres necessários.
         */
        public void SetKey()
        {
            string key = "";

            for (int i = 1; i <= _IdLength; i++)
            {
                int number = _Random.Next(0, int.MaxValue);
                key += number.ToString("X8");
            }

            Key = key.Substring(0, 24);
        }
    }
}
