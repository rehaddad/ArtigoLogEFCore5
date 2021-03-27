using static System.Console;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ArtigoLogEFCore5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LOG EF CORE 5!");

            AdicionaDados();

            //ListarDados();
        }

        private static void AdicionaDados()
        {
            using (var ctx = new BancoContexto())
            {
                ctx.Medicos.Add(new Medico
                {
                    Nome = "Patricia",
                    Especialidade = "Neonatologista",
                    Pacientes = new List<Paciente> {
                        new Paciente { Nome = "Andre", Covid = false } }
                });
                ctx.SaveChanges();
                WriteLine("---- dados adicionados com sucesso");
            }
        }

        private static void ListarDados()
        {
            using (var ctx = new BancoContexto())
            {
                //WriteLine("------ Medicos:");
                ctx.Medicos.ToList().ForEach(m =>
                    WriteLine($" - {m.Nome}: {m.Especialidade}"));

                //WriteLine("------ Pacientes");
                ctx.Pacientes.ToList().ForEach(p =>
                    WriteLine($"{p.Nome} - Covid: {p.Covid}"));

                ctx.Pacientes
                    .Where(p => p.Covid == true)
                    .OrderBy(p => p.Nome)
                    .ToList()
                    .ForEach(p =>
                    WriteLine($"{p.Nome} - Covid: {p.Covid}"));


                ReadLine();
            }
        }
    }
}
