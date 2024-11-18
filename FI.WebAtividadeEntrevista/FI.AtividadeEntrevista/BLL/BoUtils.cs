using FI.AtividadeEntrevista.DAL;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoUtils
    {
        public bool ValidarCpf(string CPF)
        {
            // Remove caracteres não numéricos
            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (CPF.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (caso comum de CPF inválido)
            if (CPF.Distinct().Count() == 1)
                return false;

            // Cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (CPF[i] - '0') * (10 - i);
            }

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (CPF[i] - '0') * (11 - i);
            }

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            // Verifica se os dígitos calculados conferem com os dígitos do CPF
            return CPF[9] - '0' == digito1 && CPF[10] - '0' == digito2;
        }
    }
}
