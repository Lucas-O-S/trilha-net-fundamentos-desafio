using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        //Preço inicial que será somado independente de quantas horas o veiculo fique
        private decimal precoInicial = 0;
        
        //Preço por hora estacionada
        private decimal precoPorHora = 0;
        
        //Lista de placas de veiculos
        private List<string> veiculos = new List<string>();

        //Construtor de veiculos estacionados
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        //Adiciona um veiculo a lista 
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.Write("Digite a placa do veículo para estacionar: ");
            try
            {
                string Placa = Console.ReadLine();

                //Formata a placa para o formato pedido
                Placa = Verificador.AjustarPlaca(Placa);

                //Verifica se o tamanho da placa está correto 7 digitos(ex: ABCDEFG)
                if (Verificador.VerificarTamanho(Placa))
                {
                    throw new Exception("Tamanho da String fora do padrão, verifique se há mais ou menos de 7 digitos a placa(Disconsiderando ' ' ou '-')");
                }

                //Verifica se há repetição de veiculos 
                if (Verificador.VerificarRepetição(veiculos, Placa))
                {
                    throw new Exception("Carro já foi cadastrado");
                }

                //Adiciona veiculo a lista
                veiculos.Add(Placa);


            }

            //Pega possiveis erros
            catch(Exception e) {
                Console.WriteLine($"Erro encontrado: {e}");
                
            }

        }

        //Remove veiculos da lista e calcula preço a ser pago
        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            try
            {
                placa = Console.ReadLine();

                //Formata a placa
                placa = Verificador.AjustarPlaca(placa);

                //Verifica tamanho da placa
                if (Verificador.VerificarTamanho(placa))
                {
                    throw new Exception("Tamanho da String fora do padrão, verifique se há mais ou menos de 7 digitos a placa(Disconsiderando ' ' ou '-')");
                }

                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    //Separei o calculo do preço em uma outra função
                    CalcularPreco(placa);
                }
                else
                {
                    throw new Exception ("Veiculo Não existe");
                }
            }

            catch(FormatException e)
            {
                Console.WriteLine($"Formato digitado esta errado: {e}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Erro encontrado: {e}");

            }

            
        }

        private void CalcularPreco(string placa)
        {

            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            // *IMPLEMENTE AQUI*

            //Horas estacionadas
            int horas = 0;

            //Preço total a se calculado
            decimal valorTotal = 0;

            //Variavel temporaria das horas
            string StringHoras = Console.ReadLine();

            //Converte para int dentro da variavel horas
            if (int.TryParse(StringHoras, out int Teste))
            {
                horas = Teste;
            }
            //Verifica o erro
            else
            {
                throw new Exception("As horas digitadas estão em formato errado");
            }

            //Verifica a possibilidade de erros com horas negativas
            if (horas < 0)
            {
                throw new Exception("Hora está negativa, tente outro valor");
            }

            //Calcula as horas totais
            valorTotal = horas * precoPorHora + precoInicial;

            // TODO: Remover a placa digitada da lista de veículos
            // *IMPLEMENTE AQUI*

            //Remove a placa
            veiculos.Remove(placa);


            //Resposta
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

        }

        //Lista as placas cadastradas
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*

                //Escreve todas as placas
                foreach (string Placa in veiculos)
                {
                    Console.WriteLine(Placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
