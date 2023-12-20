using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{

    //Classe estatica para verificar detalhes
    public static class Verificador
    {
        //Verifica tamanho da placa, deve ter 7 digitos(Ex: AAAAAAA)
        public static bool VerificarTamanho(string Placa)
        {

            if (Placa.Length > 7 || Placa.Length < 7)
            {
                return true;
            }

            return false;
        }

        //Verifica se a placa já foi cadastrada
        public static bool VerificarRepetição(List<String> Veiculos, String Placa)
        {

            foreach (String Carro in Veiculos)
            {
                if (Carro == Placa)
                {
                    return true;
                }
            }

            return false;
        }

        //Ajusta o formato da placa eliminando espaços e traços
        public static string AjustarPlaca(string Placa)
        {
            Placa = Placa.ToUpper();

            Placa = Placa.Replace(" ", "");


            Placa = Placa.Replace("-", "");

            return Placa;

        }
    }
}
