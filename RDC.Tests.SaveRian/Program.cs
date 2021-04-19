using System;

namespace RDC.Tests.SaveRian
{
    public class Program
    {
        static void Main()
        {
            ExecutarSoldados();
        }

        static void ExecutarSoldados()
        {
            var valido = false;
            var soldados = 0;
            Console.WriteLine("Bem vindo a execução de soldados, informe quantos soldados farão parte da cerimônia:");
            while (!valido)
            {
                var strSoldados = Console.ReadLine();
                valido = int.TryParse(strSoldados, out soldados);
                if (!valido)
                {
                    Console.WriteLine("Número inválido. Por favor digite um número inteiro");
                }
            }

            if (soldados == 1)
            {
                Console.WriteLine("Só tem você, fuja enquanto pode!");
                PerguntarSeExecutarMaisSoldados();
            }
            else
            {
                var lugarDeSorte = ObterPosicaoDeSorte(soldados);
                Console.WriteLine($"Se o Rian quiser sobreviver, sente-se na posição: {lugarDeSorte}");
                PerguntarSeExecutarMaisSoldados();
            }
        }

        static void PerguntarSeExecutarMaisSoldados()
        {
            Console.WriteLine("Gostaria de tentar novamente? S/N");
            var answer = Console.ReadLine();
            while (answer.ToUpper() != "S" && answer.ToUpper() != "N")
            {
                Console.WriteLine("Gostaria de tentar novamente? S/N");
                answer = Console.ReadLine();
            }
            switch (answer.ToUpper())
            {
                case "S":
                    ExecutarSoldados();
                    break;
                case "N":
                    break;
            }
        }

        public static int ObterPosicaoDeSorte(int soldados)
        {
            //Valor fixo, simboliza o primeiro a ser executado
            var primeiroAMorrer = 2;

            //Chamada recursiva que leva em consideração a primeira morte sendo do soldado 2
            //e ao mesmo tempo vai reduzindo o número de soldados no círculo
            //até sobrar só o Rian => firstKill-1
            if (soldados == 1)
            {
                return 1;
            }
            return (ObterPosicaoDeSorte(soldados - 1) + primeiroAMorrer - 1) % soldados + 1;
        }
    }
}
