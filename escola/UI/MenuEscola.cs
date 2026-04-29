using System.Diagnostics;
using escola.DTOs;
using escola.Interfaces.Services;
using escola.Models;

namespace escola.UI;

public class MenuEscola(IAlunoService alunoService, IMatriculaService matriculaService, IProfessorService professorService, IDisciplinaService disciplinaService, IAvaliacaoService avaliacaoService)
{
    private readonly IAlunoService _alunoService = alunoService;
    private readonly IMatriculaService _matriculaService = matriculaService;
    private readonly IProfessorService _professorService = professorService;
    private readonly IDisciplinaService _disciplinaService = disciplinaService;
    private readonly IAvaliacaoService _avaliacaoService = avaliacaoService;

    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|======== SISTEMA ESCOLAR PROMETHEUS ====|");
            Console.WriteLine("|1  - Cadastrar Aluno                    |");
            Console.WriteLine("|2  - Cadastrar Professor                |");
            Console.WriteLine("|3  - Cadastrar Disciplina               |");
            Console.WriteLine("|4  - Realizar Matrícula                 |");
            Console.WriteLine("|5  - Adicionar Disciplina na Matrícula  |");
            Console.WriteLine("|6  - Adicionar Avaliação                |");
            Console.WriteLine("|7  - Listar Alunos                      |");
            Console.WriteLine("|8  - Listar Professores                 |");
            Console.WriteLine("|9  - Listar Disciplinas                 |");
            Console.WriteLine("|10 - Listar Matrículas                  |");
            Console.WriteLine("|11 - Buscar Aluno por Nome              |");
            Console.WriteLine("|12 - Ranking por Disciplina             |");
            Console.WriteLine("|13 - Boletim do Aluno                   |");
            Console.WriteLine("|14 - Filtrar Alunos por Situação        |");
            Console.WriteLine("|0  - Sair                               |");
            Console.WriteLine(" ________________________________________");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarAluno(); break;
                case "2": CadastrarProfessor(); break;
                case "3": CadastrarDisciplina(); break;
                case "4": RealizarMatricula(); break;
                case "5": AdicionarDisciplinaMatricula(); break;
                case "6": AdicionarAvaliacao(); break;
                case "7": ListarAlunos(); break;
                case "8": ListarProfessores(); break;
                case "9": ListarDisciplinas(); break;
                case "10": ListarMatriculas(); break;
                case "11": BuscarAlunoPorNome(); break;
                case "12": RankingPorDisciplina(); break;
                case "13": BoletimAluno(); break;
                case "14": FiltrarAlunosPorSituacao(); break;
                case "0":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla...");
            Console.ReadKey();
        }
    }
    public void CadastrarAluno()
    {
        Console.Clear();

        Console.WriteLine("=== CADASTRAR ALUNO ===\n");

        Console.Write("Digite o nome completo do Aluno: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.Write("\nDigite a data de nascimento do Aluno (dd/MM/yyyy): ");
        DateTime dataNascimento;
        while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            Console.WriteLine("Data inválida");

        Console.Write("\nDigite o CPF do Aluno: ");
        string cpf = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
        {
            Console.WriteLine("CPF não pode ser vazio e deve ter 11 dígitos");
            cpf = Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine(_alunoService.CriarAluno(new AlunoDto(nome, dataNascimento, cpf)));
    }

    public void RealizarMatricula()
    {
        Console.Clear();

        Console.WriteLine("=== Realizar Matricula ===\n");
        Console.WriteLine("Escolha um aluno pra matricular: \n");

        var alunos = _alunoService.ListarAlunos();

        foreach (var aluno in alunos)
            Console.WriteLine(aluno);

        Console.Write("\nDigite o Id do aluno: ");
        Guid id;
        while (!Guid.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inválido. Digite novamente: ");

        Console.WriteLine(_matriculaService.CriarMatricula(new MatriculaDto(id)));
    }

    public void CadastrarProfessor()
    {
        Console.Clear();

        Console.WriteLine("=== CADASTRAR PROFESSOR ===\n");

        Console.Write("Digite o nome completo do professor: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.Write("\nDigite a data de nascimento do professor (dd/MM/yyyy): ");
        DateTime dataNascimento;
        while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            Console.WriteLine("Data inválida");

        Console.Write("\nDigite o CPF do professor: ");
        string cpf = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
        {
            Console.WriteLine("CPF não pode ser vazio e deve ter 11 dígitos");
            cpf = Console.ReadLine();
        }

        Console.Write("\nDigite a especialização do professor: ");
        string especializacao = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(especializacao))
        {
            Console.WriteLine("especializacao não pode ser vazio");
            especializacao = Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine(_professorService.CriarProfessor(new ProfessorDto(nome, dataNascimento, cpf, especializacao)));
    }

    public void CadastrarDisciplina()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRAR DISCIPLINA ===\n");

        Console.Write("Digite o nome da disciplina: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.Write("\nDigite a carga horária da disciplina: ");
        int cargaHoraria;
        while (!int.TryParse(Console.ReadLine(), out cargaHoraria) || cargaHoraria <= 0)
            Console.Write("Carga horária inválida. Digite novamente: ");

        Console.WriteLine("\nEscolha um professor para a disciplina:\n");
        var professores = _professorService.ListarProfessores();
        foreach (var professor in professores)
            Console.WriteLine(professor);

        Console.Write("\nDigite o Id do professor: ");
        Guid idProfessor;
        while (!Guid.TryParse(Console.ReadLine(), out idProfessor))
            Console.Write("Id não pode ser vazio. Digite novamente: ");


        Console.WriteLine();
        Console.WriteLine(_disciplinaService.CriarDisciplina(new DisciplinaDto(nome, cargaHoraria, idProfessor)));
    }

    public void ListarAlunos()
    {
        Console.Clear();

        Console.WriteLine("=== ALUNOS ===\n");

        var alunos = _alunoService.ListarAlunos();

        foreach (var aluno in alunos)
            Console.WriteLine(aluno);
    }

    public void ListarMatriculas()
    {
        Console.Clear();

        Console.WriteLine("=== MATRÍCULAS ===\n");

        var matriculas = _matriculaService.ListarMatriculas();

        foreach (var matricula in matriculas)
            Console.WriteLine(matricula);
    }

    public void ListarProfessores()
    {
        Console.Clear();

        Console.WriteLine("=== PROFESSORES ===\n");

        var professores = _professorService.ListarProfessores();

        foreach (var professor in professores)
            Console.WriteLine(professor);
    }

    public void AdicionarDisciplinaMatricula()
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR DISCIPLINA À MATRÍCULA ===\n");

        Console.WriteLine("Escolha uma matrícula:\n");
        var matriculas = _matriculaService.ListarMatriculas();
        foreach (var matricula in matriculas)
            Console.WriteLine(matricula);

        Console.Write("\nDigite o Id da matrícula: ");
        Guid matriculaId;
        while (!Guid.TryParse(Console.ReadLine()?.Trim(), out matriculaId))
            Console.Write("Id inválido. Digite novamente: ");

        Console.WriteLine("\nEscolha uma disciplina:\n");
        var disciplinas = _disciplinaService.ListarDisciplinas();
        foreach (var disciplina in disciplinas)
            Console.WriteLine(disciplina);

        Console.Write("\nDigite o Id da disciplina: ");
        string disciplinaId = Console.ReadLine()?.Trim();
        while (string.IsNullOrWhiteSpace(disciplinaId))
        {
            Console.Write("Id não pode ser vazio. Digite novamente: ");
            disciplinaId = Console.ReadLine()?.Trim();
        }

        Console.WriteLine();
        Console.WriteLine(_matriculaService.AdicionarDisciplina(matriculaId, disciplinaId));
    }

    public void AdicionarAvaliacao()
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR AVALIAÇÃO ===\n");

        Console.WriteLine("Escolha uma matrícula:\n");
        var matriculas = _matriculaService.ListarMatriculas();
        foreach (var m in matriculas) Console.WriteLine(m);

        Console.Write("\nDigite o Id da matrícula: ");
        Guid matriculaId;
        while (!Guid.TryParse(Console.ReadLine()?.Trim(), out matriculaId))
            Console.Write("Id inválido. Digite novamente: ");

        Console.WriteLine("\nEscolha uma disciplina:\n");
        var disciplinas = _disciplinaService.ListarDisciplinas();
        foreach (var d in disciplinas) Console.WriteLine(d);

        Console.Write("\nDigite o Id da disciplina: ");
        string disciplinaId = Console.ReadLine()?.Trim();
        while (string.IsNullOrWhiteSpace(disciplinaId))
        {
            Console.Write("Id não pode ser vazio. Digite novamente: ");
            disciplinaId = Console.ReadLine()?.Trim();
        }

        Console.Write("\nTipo (1 - Teórica / 2 - Prática): ");
        string tipo = Console.ReadLine()?.Trim();
        while (tipo != "1" && tipo != "2")
        {
            Console.Write("Opção inválida. Digite 1 para Teórica ou 2 para Prática: ");
            tipo = Console.ReadLine()?.Trim();
        }
        tipo = tipo == "1" ? "teorica" : "pratica";

        Console.Write("\nDigite o título da avaliação: ");
        string titulo = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("Título não pode ser vazio");
            titulo = Console.ReadLine();
        }

        Console.Write("\nDigite a data de realização (dd/MM/yyyy): ");
        DateTime dataRealizacao;
        while (!DateTime.TryParse(Console.ReadLine(), out dataRealizacao))
            Console.Write("Data inválida. Digite novamente: ");

        Console.Write("\nDigite a nota (0.0 a 10.0): ");
        double nota;
        while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            Console.Write("Nota inválida. Digite novamente: ");

        Console.WriteLine();
        Console.WriteLine(_avaliacaoService.AdicionarAvaliacao(new AvaliacaoDto(titulo, dataRealizacao, nota, matriculaId, disciplinaId, tipo)));
    }

    public void BuscarAlunoPorNome()
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR ALUNO POR NOME ===\n");

        Console.Write("Digite o nome ou trecho: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.WriteLine();
        var resultado = _matriculaService.BuscarAlunoPorNome(nome);
        foreach (var r in resultado) Console.WriteLine(r);
    }

    public void RankingPorDisciplina()
    {
        Console.Clear();
        Console.WriteLine("=== RANKING POR DISCIPLINA ===\n");

        Console.Write("Digite o nome da disciplina: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.WriteLine();
        var resultado = _matriculaService.RankingPorDisciplina(nome);
        foreach (var r in resultado) Console.WriteLine(r);
    }

    public void BoletimAluno()
    {
        Console.Clear();
        Console.WriteLine("=== BOLETIM DO ALUNO ===\n");

        Console.WriteLine("Escolha uma matrícula:\n");
        var matriculas = _matriculaService.ListarMatriculas();
        foreach (var m in matriculas) Console.WriteLine(m);

        Console.Write("\nDigite o número da matrícula: ");
        string numeroMatricula = Console.ReadLine()?.Trim();
        while (string.IsNullOrWhiteSpace(numeroMatricula))
        {
            Console.Write("Número inválido. Digite novamente: ");
            numeroMatricula = Console.ReadLine()?.Trim();
        }

        Console.WriteLine();
        var resultado = _matriculaService.BoletimAluno(numeroMatricula);
        foreach (var r in resultado) Console.WriteLine(r);
    }

    public void FiltrarAlunosPorSituacao()
    {
        Console.Clear();
        Console.WriteLine("=== FILTRAR ALUNOS POR SITUAÇÃO ===\n");

        Console.Write("Digite o nome da disciplina: ");
        string nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nome = Console.ReadLine();
        }

        Console.WriteLine();
        var resultado = _matriculaService.FiltrarAlunosPorSituacao(nome);
        foreach (var r in resultado) Console.WriteLine(r);
    }

    public void ListarDisciplinas()
    {
        var disciplinas = _disciplinaService.ListarDisciplinas();

        foreach (var disciplina in disciplinas)
            Console.WriteLine(disciplina);
    }
}
