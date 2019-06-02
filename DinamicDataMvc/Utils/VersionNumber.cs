using DinamicDataMvc.Interfaces;
using System;

namespace DinamicDataMvc.Utils
{
    public class VersionNumber : IVersionNumber
    {
        private int Number { get; set; }

        public void SetNumber(string version)
        {
            string[] fragments = version.Split("V");

            Number = Convert.ToInt32(fragments[1]);
        }

        public int GetVersionNumber()
        {
            return Number;
        }
    }
}
