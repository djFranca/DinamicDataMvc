using DinamicDataMvc.Interfaces;
using System;
using System.Linq;

namespace DinamicDataMvc.Utils
{
    public class KeyGenerates : IKeyGenerates
    {
        private readonly Random _Random;
        private readonly int _IdLength;
        private string Key { get; set; }
        private readonly char[] chars = null;

        public KeyGenerates(int IdLength)
        {
            _Random = new Random();
            _IdLength = IdLength;
            string _base = "abcdefghijklmnopqrstuvwxyz";
            string _alphabet = _base.ToLower() + _base.ToUpper() + "0123456789";
            chars = _alphabet.ToCharArray();
        }

        public string GetKey()
        {
            return Key;
        }

        public void SetKey()
        {
            string key = "";

            for (int i = 1; i <= _IdLength; i++)
            {
                int index = _Random.Next(1, chars.Length);
                key += chars.ElementAt(index);
            }

            Key = key;
        }
    }
}
