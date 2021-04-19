using System;

namespace RDC.Tests.SaveRian
{
    public class Program
    {
        static void Main()
        {
            Execute();
        }

        static void Execute()
        {
            var valid = false;
            var soldiers = 0;
            Console.WriteLine("Bem vindo a execução de soldados, informe quantos soldados farão parte da cerimônia:");
            while (!valid)
            {
                var strSoldiers = Console.ReadLine();
                valid = int.TryParse(strSoldiers, out soldiers);
                if (!valid)
                {
                    Console.WriteLine("Número inválido. Por favor digite um número inteiro");
                }
            }

            if (soldiers == 1)
            {
                Console.WriteLine("Só tem você, fuja enquanto pode!");
                AskToExecuteAgain();
            }
            else
            {
                var luckySpot = KillSoldiers(soldiers);
                Console.WriteLine($"Se o Rian quiser sobreviver, sente-se na posição: {luckySpot}");
                AskToExecuteAgain();
            }
        }

        static void AskToExecuteAgain()
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
                    Execute();
                    break;
                case "N":
                    break;
            }
        }

        public static int KillSoldiers(int soldiers)
        {
            //Valor fixo, simboliza o primeiro a ser executado
            var firstKill = 2;

            //Chamada recursiva que leva em consideração a primeira morte sendo do soldado 2
            //e ao mesmo tempo vai reduzindo o número de soldados no círculo
            //até sobrar só o Rian => firstKill-1
            if (soldiers == 1)
            {
                return 1;
            }
            return (KillSoldiers(soldiers - 1) + firstKill - 1) % soldiers + 1;
        }
    }
}
