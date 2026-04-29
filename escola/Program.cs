using escola.Models;
using escola.Repository;
using escola.Service;
using escola.UI;

// var alunoRepository = new AlunoRepository();
// var matriculaRepository = new MatriculaRepository();
// var professorRepository = new ProfessorRepository();
// var disciplinaRepository = new DisciplinaRepository();
// var avaliacaoRepository = new AvaliacaoRepository(matriculaRepository);

// var alunoService = new AlunoService(alunoRepository);
// var matriculaService = new MatriculaService(matriculaRepository, alunoRepository, disciplinaRepository);
// var professorService = new ProfessorService(professorRepository);
// var disciplinaService = new DisciplinaService(disciplinaRepository, professorRepository);
// var avaliacaoService = new AvaliacaoService(avaliacaoRepository, matriculaRepository, disciplinaRepository);



var alunoRepository = new AlunoRepository();
var matriculaRepository = new MatriculaRepository();
var professorRepository = new ProfessorRepository();
var disciplinaRepository = new DisciplinaRepository();
var avaliacaoRepository = new AvaliacaoRepository(matriculaRepository);

var alunoService = new AlunoService(alunoRepository);
var matriculaService = new MatriculaService(matriculaRepository, alunoRepository, disciplinaRepository);
var professorService = new ProfessorService(professorRepository);
var disciplinaService = new DisciplinaService(disciplinaRepository, professorRepository);
var avaliacaoService = new AvaliacaoService(avaliacaoRepository, matriculaRepository, disciplinaRepository);

// ── DADOS MOCKADOS ───────────────────────────────────────────
var prof1 = new Professor("Carlos Souza", new DateTime(1980, 5, 10), "12345678901", "Matemática");
var prof2 = new Professor("Ana Lima", new DateTime(1975, 8, 22), "98765432100", "Português");
var prof3 = new Professor("Roberto Dias", new DateTime(1983, 3, 15), "11122233344", "Programação");
professorRepository.CadastrarProfessor(prof1);
professorRepository.CadastrarProfessor(prof2);
professorRepository.CadastrarProfessor(prof3);

var disc1 = new Disciplina("Matemática", 60, prof1);
var disc2 = new Disciplina("Português", 40, prof2);
var disc3 = new Disciplina("Programação", 80, prof3);
disciplinaRepository.CadastrarDisciplina(disc1);
disciplinaRepository.CadastrarDisciplina(disc2);
disciplinaRepository.CadastrarDisciplina(disc3);

var aluno1 = new Aluno("Rodrigo Oliveira", new DateTime(1998, 3, 8), "00000000021");
var aluno2 = new Aluno("Fernanda Costa", new DateTime(2000, 7, 14), "00000000032");
var aluno3 = new Aluno("Lucas Mendes", new DateTime(1999, 11, 30), "00000000043");
alunoRepository.CadastrarAluno(aluno1);
alunoRepository.CadastrarAluno(aluno2);
alunoRepository.CadastrarAluno(aluno3);

var mat1 = new Matricula(aluno1);
var mat2 = new Matricula(aluno2);
var mat3 = new Matricula(aluno3);
matriculaRepository.Matricular(mat1);
matriculaRepository.Matricular(mat2);
matriculaRepository.Matricular(mat3);

matriculaRepository.AdicionarDisciplina(mat1.Id, disc1);
matriculaRepository.AdicionarDisciplina(mat1.Id, disc3);
matriculaRepository.AdicionarDisciplina(mat2.Id, disc1);
matriculaRepository.AdicionarDisciplina(mat2.Id, disc2);
matriculaRepository.AdicionarDisciplina(mat3.Id, disc2);
matriculaRepository.AdicionarDisciplina(mat3.Id, disc3);

mat1.Avaliacoes.Add(new AvaliacaoTeorica("Prova 1", new DateTime(2025, 3, 10), 8.0, disc1));
mat1.Avaliacoes.Add(new AvaliacaoPratica("Trabalho 1", new DateTime(2025, 3, 20), 7.5, disc1));
mat1.Avaliacoes.Add(new AvaliacaoTeorica("Prova Final", new DateTime(2025, 4, 5), 9.0, disc3));
mat1.Avaliacoes.Add(new AvaliacaoPratica("Projeto", new DateTime(2025, 4, 15), 10.0, disc3));

mat2.Avaliacoes.Add(new AvaliacaoTeorica("Prova 1", new DateTime(2025, 3, 10), 5.0, disc1));
mat2.Avaliacoes.Add(new AvaliacaoPratica("Trabalho 1", new DateTime(2025, 3, 20), 6.0, disc1));
mat2.Avaliacoes.Add(new AvaliacaoTeorica("Prova 1", new DateTime(2025, 3, 12), 4.0, disc2));
mat2.Avaliacoes.Add(new AvaliacaoPratica("Redação", new DateTime(2025, 3, 25), 3.5, disc2));

mat3.Avaliacoes.Add(new AvaliacaoTeorica("Prova 1", new DateTime(2025, 3, 12), 7.0, disc2));
mat3.Avaliacoes.Add(new AvaliacaoPratica("Redação", new DateTime(2025, 3, 25), 8.5, disc2));
mat3.Avaliacoes.Add(new AvaliacaoTeorica("Prova Final", new DateTime(2025, 4, 5), 6.0, disc3));
mat3.Avaliacoes.Add(new AvaliacaoPratica("Projeto", new DateTime(2025, 4, 15), 5.5, disc3));


var ui = new MenuEscola(alunoService, matriculaService, professorService, disciplinaService, avaliacaoService);

ui.public List<BoletimDto> GerarBoletim(Guid idMatricula)
{
    var matricula = _matriculaRepository.BuscarPorId(idMatricula);

    if (matricula == null)
        return new List<BoletimDto>();

    var boletim = new List<BoletimDto>();

    foreach (var disciplina in matricula.Disciplinas)
    {
        var notas = disciplina.Avaliacoes.Select(a => a.Nota).ToList();

        double media = 0;

        if (notas.Count > 0)
            media = notas.Average();

        var situacao = media >= 7 ? "Aprovado" : "Reprovado";

        boletim.Add(new BoletimDto
        {
            DisciplinaNome = disciplina.Nome,
            Media = media,
            Situacao = situacao
        });
    }

    return public void GerarBoletim()
{
    Console.Clear();

    Console.WriteLine("=== GERAR BOLETIM ===\n");

    Console.WriteLine("Escolha uma Matrícula:\n");

    var matriculas = _matriculaService.ListarMatriculas();

    foreach (var matricula in matriculas)
        Console.WriteLine(matricula);

    Console.Write("\nDigite o Id da Matrícula: ");

    Guid idMatricula;

    while (!Guid.TryParse(Console.ReadLine(), out idMatricula))
    {
        Console.WriteLine("Id inválido, tente novamente:");
    }

    var resultados = _matriculaService.GerarBoletim(idMatricula);

    foreach (var resultado in resultados)
    {
        Console.WriteLine($"Disciplina: {resultado.DisciplinaNome}");
        Console.WriteLine($"Média: {resultado.Media}");
        Console.WriteLine($"Situação: {resultado.Situacao}");
        Console.WriteLine("----------------------------");
    }

    Console.public class BoletimDto
{
    public string DisciplinaNome { get; set; }
    public double Media { get; set; }
    public string Situacao { get; set; }
}




