namespace ControleBovideoSquad.CrossCutting.Util
{
    public static class Validacao
    {
        #region validar CPF
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = Formatar.FormatarString(cpf);

            if (
                cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999"
                )
            {
                return false;
            }

            if (cpf.Length != 11)
            {
                return false;
            }
            tempCpf = cpf[..9];
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
        #endregion

        #region Validar Inscricao Estadual
        public static bool ValidarInscricaoEstadual(string Inscricao_estadual)
        {
            bool retorno = false;
            string strBase;
            string strBase2;
            string strOrigem;
            string strDigito1;
            int intPos;
            int intValor;
            int intSoma = 0;
            int intResto;
            strBase = "";
            strBase2 = "";
            strOrigem = "";

            Inscricao_estadual = Formatar.FormatarString(Inscricao_estadual);

            if (Inscricao_estadual.Trim().ToUpper() == "ISENTO")
            {
                return true;
            }

            for (intPos = 1; intPos <= Inscricao_estadual.Trim().Length; intPos++)
            {
                if ((("0123456789P".IndexOf(Inscricao_estadual.Substring((intPos - 1), 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                {
                    strOrigem += Inscricao_estadual.Substring((intPos - 1), 1);
                }
            }

            strBase = (strOrigem.Trim() + "000000000")[..9];

            int ie = int.Parse(strBase);
            if (ie >= 285000000)
            {
                intSoma = 0;

                for (intPos = 1; (intPos <= 8); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                    intValor *= (10 - intPos);
                    intSoma += intValor;
                }

                intResto = (intSoma % 11);
                strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                strBase2 = (string.Concat(strBase.AsSpan(0, 8), strDigito1));

                if ((strBase2 == strOrigem))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion
    }
}
