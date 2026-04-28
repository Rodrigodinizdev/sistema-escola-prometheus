namespace escola.Models;

    public abstract class Avaliacao
    {
        public Avaliacao(string titulo, DateTime dataRealizacao, double nota, Disciplina disciplina)
        {
            Id = GeradorId();
            Titulo = titulo;
            DataRealizacao = dataRealizacao;
            Nota = nota;
            Disciplina = disciplina;
        }

        public string Id { get; }
        public string Titulo { get; }
        public DateTime DataRealizacao { get; }
        public double Nota { get; }
        public Disciplina Disciplina { get; }

        public abstract double Peso { get; }
        public double NotaPonderada => Nota * Peso;

        public string GeradorId() => $"{new Random().Next(0000, 9999)}";
    }
    