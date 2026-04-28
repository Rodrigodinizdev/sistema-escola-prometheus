namespace escola.Models
{
    public class Matricula
    {
        public Matricula(Aluno aluno)
        {
            Id = Guid.NewGuid();
            NumeroMatricula = GeradorMatricula();
            Aluno = aluno;
            DataMatricula = DateTime.Now;
            Disciplinas = new List<Disciplina>();
        }
        public Guid Id { get; }
        public string NumeroMatricula { get; private set; }
        public Aluno Aluno { get; }
        public DateTime DataMatricula { get; }
        public List<Disciplina> Disciplinas { get; }

        public string GeradorMatricula() => $"{DateTime.Now.Year}{new Random().Next(0000, 9999)}";

        public List<Avaliacao> Avaliacoes { get; } = new List<Avaliacao>();

        public double? CalcularMedia(Disciplina disciplina)
        {
            var teorica = Avaliacoes.FirstOrDefault(a => a is AvaliacaoTeorica && a.Disciplina == disciplina);
            var pratica = Avaliacoes.FirstOrDefault(a => a is AvaliacaoPratica && a.Disciplina == disciplina);

            if (teorica == null && pratica == null) return null;

            return (teorica?.NotaPonderada ?? 0) + (pratica?.NotaPonderada ?? 0);
        }

        public string ObterSituacao(Disciplina disciplina)
        {
            var media = CalcularMedia(disciplina);
            if (media == null) return "Sem avaliações";
            if (media >= 7.0) return "Aprovado";
            if (media >= 5.0) return "Recuperação";
            return "Reprovado";
        }

        public override string ToString() => $"Matrícula: {NumeroMatricula} | Aluno: {Aluno.NomeCompleto} | Data Matrícula: {DataMatricula}";
    }
}
