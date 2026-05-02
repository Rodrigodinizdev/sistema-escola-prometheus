using escola.Enum;

namespace escola.Models;

    public abstract class Avaliacao
    {
        public Avaliacao(string titulo, DateTime dataRealizacao, double nota, Disciplina disciplina, TipoAvaliacaoEnum tipo)
        {
            Id = GeradorId();
            Titulo = titulo;
            DataRealizacao = dataRealizacao;
            Nota = nota;
            Disciplina = disciplina;
            Tipo = tipo;
        }

        public string Id { get; }
        public string Titulo { get; }
        public DateTime DataRealizacao { get; }
        public double Nota { get; }
        public Disciplina Disciplina { get; }
        public TipoAvaliacaoEnum Tipo { get; private set; }

        public abstract double Peso { get; }
        public double NotaPonderada => Nota * Peso;

        public string GeradorId() => $"{new Random().Next(0000, 9999)}";
    }
    