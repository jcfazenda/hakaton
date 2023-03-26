using System;

namespace api.Controllers.Generics
{
    public class CepConsulta
    {
        private string _Cep;
        private string _Rua;
        private string _Cidade;
        private string _Bairro;
        private string _Estado;

        public string Cep
        {
            get
            {
                return this._Cep;
            }
            set
            {
                int dCount = 0;

                if (value.Length != 8 && value.Length != 9)
                    throw new ArgumentException("O CEP informado é inválido!\nO CEP deve conter 8 dígitos (sem hífen) ou 9 (com hífen)");

                foreach (char c in value)
                    if (Char.IsDigit(c))
                        dCount++;

                if (dCount != 8)
                    throw new ArgumentException("O CEP informado é inválido!");

                this._Cep = value;
            }
        }

        public string Rua
        {
            get
            {
                return this._Rua;
            }
            set
            {
                if (value.Length > 500)
                    throw new ArgumentException("O nome da rua não pode exceder 500 caracteres!");

                this._Rua = value;
            }
        }

        public string Cidade
        {
            get
            {
                return this._Cidade;
            }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("O nome da cidade não pode exceder 30 caracteres!");
                this._Cidade = value;
            }
        }

        public string Bairro
        {
            get
            {
                return this._Bairro;
            }
            set
            {
                if (value.Length > 500)
                    throw new ArgumentException("O nome da cidade não pode exceder 500 caracteres!");
                this._Bairro = value;
            }
        }

        public string UF
        {
            get
            {
                return this._Estado;
            }
            set
            {
                bool ok = false;
                string[] estados =
                {
                    "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA","MG","MS","MT","PA","PB","PE","PI","PR",
                    "RJ","RN","RO","RR","RS","SC","SE","SP","TO"
                };

                foreach (string s in estados)
                {
                    if (s.ToUpper() == value)
                    {
                        ok = true;
                        this._Estado = value;
                    }
                }

                if (!ok)
                    throw new ArgumentException("O estado informado não é um estado válido do Brasil!");
            }
        }

        public bool universalCep { get; set; }
    }
}
