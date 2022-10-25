using System;
using System.Collections.Generic;
using System.Text;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("iniciando .....");

            var service = new ServiceJogador();
            Console.WriteLine("Criou instacia do service .....");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Criou instacia do objeto request .....");
            request.Email = "gabriel-ao@hotmail.com";
            request.Senha = "gabigol10";

            Console.WriteLine("request program " + request);

            var response = service.AutenticarJogador(request);

            Console.WriteLine("response ->" + response);
            Console.WriteLine("request ->" + request);

            Console.WriteLine("è valido " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });
            Console.ReadKey();

        }
    }
}
