using System.Collections.Generic;

namespace ArtigoLogEFCore5
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public List<Paciente> Pacientes { get; set; }
    }

    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public bool Covid { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
