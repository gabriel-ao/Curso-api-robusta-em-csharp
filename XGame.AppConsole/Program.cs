using Microsoft.Extensions.Configuration;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    public class Program
    {
        private static IConfiguration _config;
        public Program (IConfiguration config)
        {
            _config = config;
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    string constr = this._config.GetConnectionString("XGameConnectionStrings");
        //}

        static void Main(string[] args)
        {


            Console.WriteLine("iniciando .....");

            var service = new ServiceJogador();
            Console.WriteLine("Criou instacia do service .....");

            //AutenticarJogadorRequest AutenticarRequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criou instacia do objeto request .....");
            //AutenticarRequest.Email = "gabriel-ao@hotmail.com";
            //AutenticarRequest.Senha = "gabigol10";


            //var AdicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "gabriel-ao@hotmail.com",
            //    PrimeiroNome = "Gabriel",
            //    UltimoNome = "de Oliveira",
            //    Senha = "gabigol10"
            //};

            //var response1 = service.AutenticarJogador(AutenticarRequest);

            //var response2 = service.AdicionarJogador(AdicionarRequest);

            var result = service.ListarJogador();

            Console.WriteLine("è valido " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });
            Console.ReadKey();

        }
    }
}
