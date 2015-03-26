using System;

namespace Socket.Commom
{
    [Serializable]
    public class Pessoa
    {
        public Pessoa()
        {
            var rdn = new Random();

            Idade = rdn.Next(49) + 1;
        }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public override string ToString()
        {
            return string.Format("Eu sou o {0} e tenho {1} anos", Nome, Idade);
        }
    }
}