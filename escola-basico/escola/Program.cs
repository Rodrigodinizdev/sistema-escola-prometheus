using escola.Enum;
using escola.Models;


List<Aluno> alunos = [];
List<Avaliacao> avaliacoes = [];
List<Disciplina> disciplinas = [];
List<Professor> professores = [];

// ── DADOS MOCKADOS ──────────────────────────────────────────
var prof1 = new Professor("Carlos Mendes", new DateTime(1980, 5, 10), "11111111111", "Matemática");
var prof2 = new Professor("Ana Souza", new DateTime(1975, 8, 22), "22222222222", "Programação");
var prof3 = new Professor("Roberto Lima", new DateTime(1985, 3, 15), "33333333333", "Gestão de Projetos");
professores.AddRange([prof1, prof2, prof3]);

var disc1 = new Disciplina("Matemática Aplicada", 80, prof1);
var disc2 = new Disciplina("Lógica de Programação", 60, prof2);
var disc3 = new Disciplina("Gestão de Projetos", 40, prof3);
disciplinas.AddRange([disc1, disc2, disc3]);

var aluno1 = new Aluno("Ana Clara Silva", new DateTime(2005, 1, 14), "44444444444");
var aluno2 = new Aluno("Bruno Henrique Costa", new DateTime(2004, 7, 30), "55555555555");
var aluno3 = new Aluno("Carla Fernanda Rocha", new DateTime(2006, 11, 5), "66666666666");
var aluno4 = new Aluno("Diego Martins", new DateTime(2005, 4, 20), "77777777777");
var aluno5 = new Aluno("Elisa Andrade", new DateTime(2004, 9, 9), "88888888888");
alunos.AddRange([aluno1, aluno2, aluno3, aluno4, aluno5]);

avaliacoes.AddRange([
    new AvaliacaoTeorica("Prova 1 - Mat",  aluno1, new DateTime(2025, 3, 10),  8.0, disc1),
    new AvaliacaoPratica("Trabalho - Mat", aluno1, new DateTime(2025, 3, 20),  9.0, disc1),
    new AvaliacaoTeorica("Prova 1 - Prog", aluno1, new DateTime(2025, 3, 12),  7.5, disc2),
    new AvaliacaoPratica("Projeto - Prog", aluno1, new DateTime(2025, 3, 25),  8.5, disc2),
    new AvaliacaoTeorica("Prova 1 - GP",   aluno1, new DateTime(2025, 3, 15),  9.0, disc3),
    new AvaliacaoPratica("Case - GP",      aluno1, new DateTime(2025, 3, 28),  8.0, disc3),

    new AvaliacaoTeorica("Prova 1 - Mat",  aluno2, new DateTime(2025, 3, 10),  5.0, disc1),
    new AvaliacaoPratica("Trabalho - Mat", aluno2, new DateTime(2025, 3, 20),  6.0, disc1),
    new AvaliacaoTeorica("Prova 1 - Prog", aluno2, new DateTime(2025, 3, 12),  8.0, disc2),
    new AvaliacaoPratica("Projeto - Prog", aluno2, new DateTime(2025, 3, 25),  7.0, disc2),

    new AvaliacaoTeorica("Prova 1 - Mat",  aluno3, new DateTime(2025, 3, 10),  3.0, disc1),
    new AvaliacaoPratica("Trabalho - Mat", aluno3, new DateTime(2025, 3, 20),  4.0, disc1),
    new AvaliacaoTeorica("Prova 1 - GP",   aluno3, new DateTime(2025, 3, 15),  6.0, disc3),
    new AvaliacaoPratica("Case - GP",      aluno3, new DateTime(2025, 3, 28),  5.0, disc3),

    new AvaliacaoTeorica("Prova 1 - Prog", aluno4, new DateTime(2025, 3, 12),  9.5, disc2),
    new AvaliacaoPratica("Projeto - Prog", aluno4, new DateTime(2025, 3, 25), 10.0, disc2),

    new AvaliacaoTeorica("Prova 1 - Mat",  aluno5, new DateTime(2025, 3, 10),  2.0, disc1),
    new AvaliacaoPratica("Trabalho - Mat", aluno5, new DateTime(2025, 3, 20),  3.0, disc1),
    new AvaliacaoTeorica("Prova 1 - Prog", aluno5, new DateTime(2025, 3, 12),  1.5, disc2),
    new AvaliacaoPratica("Projeto - Prog", aluno5, new DateTime(2025, 3, 25),  2.5, disc2),
    new AvaliacaoTeorica("Prova 1 - GP",   aluno5, new DateTime(2025, 3, 15),  4.0, disc3),
    new AvaliacaoPratica("Case - GP",      aluno5, new DateTime(2025, 3, 28),  3.5, disc3),
]);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== PROMETHEUS ===");
    Console.WriteLine("1 - Alunos");
    Console.WriteLine("2 - Professores");
    Console.WriteLine("3 - Disciplinas");
    Console.WriteLine("4 - Avaliações");
    Console.WriteLine("5 - Buscar Aluno por nome");
    Console.WriteLine("6 - Ranking por Disciplina");
    Console.WriteLine("7 - Boletim do Aluno");
    Console.WriteLine("8 - Filtrar por Situação");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            MenuAlunos();
            break;

        case "2":
            MenuProfessores();
            break;

        case "3":
            MenuDisciplinas();
            break;

        case "4":
            MenuAvaliacoes();
            break;

        case "5":
            BuscarAluno();
            break;

        case "6":
            RankingDisciplina();
            break;

        case "7":
            BoletimAluno();
            break;

        case "8":
            FiltrarSituacao();
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("opção inválida");
            break;
    }
    Console.WriteLine("Pressione qualquer tecla: ");
    Console.ReadKey();
}

void MenuAlunos()
{
    Console.Clear();
    Console.WriteLine("=== MENU ALUNOS ===");
    Console.WriteLine("1 - Cadastrar Aluno");
    Console.WriteLine("2 - Listar alunos");
    Console.WriteLine("0 - Voltar");

    Console.WriteLine("\nEscolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarAluno();
            break;

        case "2":
            ListarAluno();
            break;

        case "0":
            Console.WriteLine("Voltando...");
            return;

        default:
            Console.WriteLine("Opcao Inválida");
            break;
    }
}

void CadastrarAluno()
{
    string nomeAluno;
    string cpfAluno;
    DateTime dataNascimento;

    Console.WriteLine("Digite o nome do aluno: ");
    nomeAluno = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nomeAluno))
    {
        Console.WriteLine("Digite o nome do aluno: ");
        nomeAluno = Console.ReadLine();
    }

    Console.WriteLine("Digite a data de nascimento do aluno: ");
    while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
        Console.WriteLine("Data digitada é invalida, tente novamente: ");

    Console.WriteLine("Digite o cpf do aluno: ");
    cpfAluno = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(cpfAluno) || cpfAluno.Length != 11)
    {
        Console.WriteLine("Digite o cpf do aluno: ");
        cpfAluno = Console.ReadLine();
    }

    Aluno aluno = new Aluno(nomeAluno, dataNascimento, cpfAluno);
    alunos.Add(aluno);
    Console.WriteLine($"Aluno: {nomeAluno} matriculado com sucesso | Matrícula: {aluno.NumeroMatricula} | Data Matrícula: {aluno.DataMatricula}");
}

void ListarAluno()
{
    if (alunos.Count == 0)
        Console.WriteLine("Nenhum Aluno matriculado");

    alunos.ForEach(a => Console.WriteLine(a));
}

void MenuProfessores()
{
    Console.Clear();
    Console.WriteLine("=== MENU Professores ===");
    Console.WriteLine("1 - Cadastrar Professor");
    Console.WriteLine("2 - Listar Professores");
    Console.WriteLine("0 - Voltar");

    Console.WriteLine("\nEscolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarProfessor();
            break;

        case "2":
            ListarProfessores();
            break;

        case "0":
            Console.WriteLine("Voltando...");
            return;

        default:
            Console.WriteLine("Opcao Inválida");
            break;
    }
}

void CadastrarProfessor()
{
    string nome;
    string cpf;
    DateTime dataNascimento;
    string especializacao;

    Console.WriteLine("Digite o nome do professor: ");
    nome = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Digite o nome do professor: ");
        nome = Console.ReadLine();
    }

    Console.WriteLine("Digite a data de nascimento do professor: ");
    while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
        Console.WriteLine("Data digitada é invalida, tente novamente: ");

    Console.WriteLine("Digite o cpf do professor: ");
    cpf = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
    {
        Console.WriteLine("Digite o cpf do professor: ");
        cpf = Console.ReadLine();
    }

    Console.WriteLine("Digite a especialização do professor: ");
    especializacao = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(especializacao))
    {
        Console.WriteLine("Digite a especialização do professor: ");
        especializacao = Console.ReadLine();
    }

    Professor professor = new Professor(nome, dataNascimento, cpf, especializacao);
    professores.Add(professor);
    Console.WriteLine($"Professor: {nome} | Especialização: {especializacao} cadastrado com sucesso");
}

void ListarProfessores()
{
    if (professores.Count == 0)
        Console.WriteLine("Nenhum Professor no sistema");

    professores.ForEach(p => Console.WriteLine(p));
}

void MenuDisciplinas()
{
    Console.Clear();
    Console.WriteLine("=== MENU DISCIPLINA ===");
    Console.WriteLine("1 - Cadastrar Disciplina");
    Console.WriteLine("2 - Listar Disciplinas");
    Console.WriteLine("0 - Voltar");

    Console.WriteLine("\nEscolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarDisciplina();
            break;

        case "2":
            ListarDisciplinas();
            break;

        case "0":
            Console.WriteLine("Voltando...");
            return;

        default:
            Console.WriteLine("Opcao Inválida");
            break;
    }
}

void CadastrarDisciplina()
{
    string nomeDisciplina;
    int cargaHoraria;
    int indexProfessor;

    Console.WriteLine("Digite o nome da disciplina: ");
    nomeDisciplina = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nomeDisciplina))
    {
        Console.WriteLine("Digite o nome da disciplina: ");
        nomeDisciplina = Console.ReadLine();
    }

    Console.WriteLine("Digite a carga horária da disciplina: ");
    while (!int.TryParse(Console.ReadLine(), out cargaHoraria))
        Console.WriteLine("a carga horaria é invalida, tente novamente: ");

    Console.WriteLine("Selecione o professor da disciplina: ");

    for (int i = 0; i < professores.Count; i++)
        Console.WriteLine($"{i} - {professores[i].NomeCompleto} - {professores[i].Especializacao}");


    while (!int.TryParse(Console.ReadLine(), out indexProfessor) || indexProfessor < 0 || indexProfessor >= professores.Count)
        Console.WriteLine("Professor invalido, tente novamente: ");

    Professor professorSelecionado = professores[indexProfessor];

    Disciplina disciplina = new Disciplina(nomeDisciplina, cargaHoraria, professorSelecionado);
    disciplinas.Add(disciplina);
    Console.WriteLine($"Disciplina: {nomeDisciplina} | Professor Responsável: {professorSelecionado} cadastrada com sucesso");
}

void ListarDisciplinas()
{
    if (disciplinas.Count == 0)
        Console.WriteLine("ão existe disciplinas cadastradas");

    disciplinas.ForEach(d => Console.WriteLine(d));
}

void MenuAvaliacoes()
{
    Console.Clear();
    Console.WriteLine("=== MENU Avaliação ===");
    Console.WriteLine("1 - Cadastrar Avaliação");
    Console.WriteLine("2 - Listar Avaliações");
    Console.WriteLine("0 - Voltar");

    Console.WriteLine("\nEscolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarAvaliacao();
            break;

        case "2":
            ListarAvaliacoes();
            break;

        case "0":
            Console.WriteLine("Voltando...");
            return;

        default:
            Console.WriteLine("Opcao Inválida");
            break;
    }
}

void CadastrarAvaliacao()
{
    if (alunos.Count == 0)
        Console.WriteLine("Cadastre um aluno primeiro.");

    if (disciplinas.Count == 0)
        Console.WriteLine("Cadastre uma disciplina primeiro.");

    Console.Clear();
    Console.WriteLine("Selecione o aluno: ");
    alunos.ForEach(a => Console.WriteLine(a));
    Console.WriteLine("CPF do aluno: ");

    var aluno = alunos.FirstOrDefault(a => a.CPF == Console.ReadLine());

    if (aluno == null)
        Console.WriteLine("Aluno não encontrado");

    Console.Clear();
    Console.WriteLine("Selecione a Disciplina: ");
    disciplinas.ForEach(d => Console.WriteLine(d));
    Console.WriteLine("Nome da disciplina: ");

    var disciplina = disciplinas.FirstOrDefault(d => d.Nome.Equals(Console.ReadLine(), StringComparison.OrdinalIgnoreCase));

    if (disciplina == null)
        Console.WriteLine("Disciplina não encontrada");

    Console.Clear();
    Console.WriteLine("Selecione o tipo da avaliação: 1-Teórica 2-Prática");
    var tipoInput = Console.ReadLine();

    var tipo = tipoInput == "1" ? TipoAvaliacaoEnum.Teorica : TipoAvaliacaoEnum.Pratica;

    bool jaExiste = avaliacoes.Any(a => a.Aluno.Id == aluno.Id && a.Disciplina.Id == disciplina.Id && a.Tipo == tipo);

    if (jaExiste)
    {
        Console.WriteLine($"O aluno {aluno.NomeCompleto} já possui avaliação {tipo} nessa disciplina");
    }

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

    Avaliacao avaliacao = tipo == TipoAvaliacaoEnum.Teorica
        ? new AvaliacaoTeorica(titulo, aluno, dataRealizacao, nota, disciplina)
        : new AvaliacaoPratica(titulo, aluno, dataRealizacao, nota, disciplina);

    avaliacoes.Add(avaliacao);
    Console.WriteLine("Avaliação cadastrada!");
}

void ListarAvaliacoes()
{
    if (avaliacoes.Count == 0)
        Console.WriteLine("Não existe avaliaçãoes cadastradas");

    avaliacoes.ForEach(a => Console.WriteLine(a));
}

void BuscarAluno()
{
    Console.WriteLine("Digite parte do nome: ");
    var trecho = Console.ReadLine();

    var resultado = alunos.Where(a => a.NomeCompleto.Contains(trecho, StringComparison.OrdinalIgnoreCase)).ToList();

    if (resultado.Count == 0)
        Console.WriteLine("Nenhum aluno encontrado.");

    resultado.ForEach(r => Console.WriteLine(r));
}

void RankingDisciplina()
{
    Console.Write("Nome da disciplina: ");
    var nome = Console.ReadLine();

    var disciplina = disciplinas.FirstOrDefault(d => d.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (disciplina == null)
        Console.WriteLine("Disciplina não encontrada");

    var ranking = alunos.Select(a => new { Aluno = a, Notas = avaliacoes.Where(v => v.Disciplina.Id == disciplina.Id && v.Aluno.Id == a.Id).ToList() })
        .Where(x => x.Notas.Count > 0)
        .Select(x => new { x.Aluno, Media = Avaliacao.MediaAluno(x.Notas) })
        .OrderByDescending(x => x.Media)
        .ToList();

    Console.Clear();
    Console.WriteLine($"=== Rankig: {disciplina.Nome} ===");

    int index = 1;
    foreach (var item in ranking)
    {
        Console.WriteLine($" {index}° | Aluno: {item.Aluno.NomeCompleto} | Média: {item.Media:F1}");
        index++;
    }
}

void BoletimAluno()
{
    if (alunos.Count == 0)
        Console.WriteLine("Nenhum aluno cadastrado.");

    alunos.ForEach(a => Console.WriteLine(a));

    Console.Write("CPF do aluno: ");
    var cpf = Console.ReadLine();

    var aluno = alunos.FirstOrDefault(a => a.CPF == cpf);

    if (aluno == null)
        Console.WriteLine("Aluno não encontrado.");

    var porDisciplina = avaliacoes
        .Where(a => a.Aluno.Id == aluno.Id)
        .GroupBy(a => a.Disciplina.Nome)
        .OrderBy(g => g.Key)
        .ToList();

    if (porDisciplina.Count == 0)
    {
        Console.WriteLine($"{aluno.NomeCompleto} não possui avaliações");
        return;
    }

    Console.Clear();
    Console.WriteLine($"=== Boletim: {aluno.NomeCompleto} ===\n");

    foreach (var item in porDisciplina)
    {
        var notas = item.ToList();
        var teorica = notas.FirstOrDefault(a => a.Tipo == TipoAvaliacaoEnum.Teorica);
        var pratica = notas.FirstOrDefault(a => a.Tipo == TipoAvaliacaoEnum.Pratica);
        var media = Avaliacao.MediaAluno(notas);
        var situacao = Avaliacao.CalcularSituacao(media);

        Console.WriteLine($"Disciplina: {item.Key}");
        Console.WriteLine($"Teórica: {(teorica != null ? teorica.Nota.ToString("F1") : "")}");
        Console.WriteLine($"Prática: {(pratica != null ? pratica.Nota.ToString("F1") : "")}");
        Console.WriteLine($"Média: {media:F1}");
        Console.WriteLine($"Situação: {situacao}");
    }
}

void FiltrarSituacao()
{
    Console.Write("Nome da disciplina: ");
    var nome = Console.ReadLine()!;
    var disc = disciplinas.FirstOrDefault(d =>
        d.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (disc == null)
    {
        Console.WriteLine("Disciplina não encontrada.");
        return;
    }

    // Monta resultado por aluno nessa disciplina
    var resultados = alunos
        .Select(a => new
        {
            Aluno = a,
            Notas = avaliacoes
                .Where(av => av.Disciplina.Id == disc.Id && av.Aluno.Id == a.Id)
                .ToList()
        })
        .Where(x => x.Notas.Count > 0)
        .Select(x => new
        {
            x.Aluno,
            Media = Avaliacao.MediaAluno(x.Notas),
            Situacao = Avaliacao.CalcularSituacao(Avaliacao.MediaAluno(x.Notas))
        })
        .ToList();

    Console.Clear();
    Console.WriteLine($"── Filtro por Situação: {disc.Nome} ──\n");

    foreach (var situacao in new[] { SituacaoAluno.Aprovado, SituacaoAluno.Recuperacao, SituacaoAluno.Reprovado })
    {
        var grupo = resultados
            .Where(r => r.Situacao == situacao)
            .OrderBy(r => r.Aluno.NomeCompleto)
            .ToList();

        Console.WriteLine($"[ {situacao} ]");

        if (grupo.Count == 0)
            Console.WriteLine("  Nenhum aluno.");
        else
            grupo.ForEach(r => Console.WriteLine($"  {r.Aluno.NomeCompleto} — Média: {r.Media:F1}"));

        Console.WriteLine();
    }

    Console.ReadKey();
}
