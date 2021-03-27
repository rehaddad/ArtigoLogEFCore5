using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ArtigoLogEFCore5
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() { }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // referencia o DB no SQL Server
            optionsBuilder.UseSqlServer(
                @"Data Source=EARTH;Initial Catalog=ArtigoEFCoreLog;Integrated Security=True");

            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //optionsBuilder.LogTo(message => Debug.WriteLine(message));

            // registra todas as chamadas
            //optionsBuilder
            //.LogTo(Console.WriteLine, new[] { CoreEventId.ContextDisposed, CoreEventId.ContextInitialized });

            // registra somente chamadas de banco de dados
            //optionsBuilder
            //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name });

            // registra somente chamadas de consultas
            optionsBuilder
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().HasData(
            new Medico { MedicoId = 1, Nome = "Marcelo", Especialidade = "Infectologista" },
            new Medico { MedicoId = 2, Nome = "Thiago", Especialidade = "Ortopedista" },
            new Medico { MedicoId = 3, Nome = "Regina", Especialidade = "Ginecologista" }
            );

            modelBuilder.Entity<Paciente>().HasData(
            new Paciente { PacienteId = 1, Nome = "Renato", Covid = true, MedicoId = 1 },
            new Paciente { PacienteId = 2, Nome = "Livia", Covid = true, MedicoId = 1 },
            new Paciente { PacienteId = 3, Nome = "Ivete", Covid = false, MedicoId = 2 },
            new Paciente { PacienteId = 4, Nome = "Rosi", Covid = true, MedicoId = 2 },
            new Paciente { PacienteId = 5, Nome = "Reginaldo", Covid = true, MedicoId = 3 }
            );
        }
    }
}