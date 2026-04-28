using escola.DTOs;
using escola.Interfaces.Repositories;
using escola.Interfaces.Services;
using escola.Models;
using escola.Repository;

namespace escola.Service;

public class MatriculaService(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository, IDisciplinaRepository disciplinaRepository) : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository = matriculaRepository;
    private readonly IAlunoRepository _alunoRepository = alunoRepository;
    private readonly IDisciplinaRepository _disciplinaRepository = disciplinaRepository;

    public string CriarMatricula(MatriculaDto dto)
    {
        var aluno = _alunoRepository.BuscarPeloId(dto.IdAluno);

        if (aluno == null)
            return $"Aluno não encotrado";

        var matriculaExistente = _matriculaRepository.BuscarPorAlunoId(dto.IdAluno);

        if (matriculaExistente != null)
            return $"Aluno já possui matrícula";

        var matricula = new Matricula(aluno);
        _matriculaRepository.Matricular(matricula);
        return $"Matricula: {matricula.NumeroMatricula} do aluno {aluno.NomeCompleto} feita com sucesso";
    }

    public List<Matricula> ListarMatriculas()
    {
        return _matriculaRepository.ListarMatriculas();
    }

    public string AdicionarDisciplina(Guid matriculaId, string disciplinaId)
    {
        var matricula = _matriculaRepository.BuscarPeloId(matriculaId);
        if (matricula == null)
            return "Matrícula não encontrada";

        var disciplina = _disciplinaRepository.BuscarPorId(disciplinaId);
        if (disciplina == null)
            return "Disciplina não encontrada";

        if (matricula.Disciplinas.Contains(disciplina))
            return "Aluno já está matriculado nessa disciplina";

        _matriculaRepository.AdicionarDisciplina(matriculaId, disciplina);
        return $"Disciplina {disciplina.Nome} adicionada com sucesso";
    }

    public List<string> BuscarAlunoPorNome(string nome)
    {
        var matriculas = _matriculaRepository.BuscarPorNomeAluno(nome);
        if (!matriculas.Any()) return new List<string> { "Nenhum aluno encontrado" };
        return matriculas.Select(m => m.ToString()).ToList();
    }

    public List<string> RankingPorDisciplina(string nomeDisciplina)
    {
        var matriculas = _matriculaRepository.BuscarPorDisciplina(nomeDisciplina);
        var disciplina = matriculas
            .SelectMany(m => m.Disciplinas)
            .FirstOrDefault(d => d.Nome.Equals(nomeDisciplina, StringComparison.OrdinalIgnoreCase));

        if (disciplina == null) return new List<string> { "Disciplina não encontrada" };

        return matriculas
            .Where(m => m.Avaliacoes.Any(a => a.Disciplina == disciplina))
            .OrderByDescending(m => m.CalcularMedia(disciplina))
            .Select((m, i) => $"{i + 1}º {m.Aluno.NomeCompleto} | Média: {m.CalcularMedia(disciplina):F2}")
            .ToList();
    }

    public List<string> BoletimAluno(string numeroMatricula)
    {
        var matricula = _matriculaRepository.BuscarPorNumeroMatricula(numeroMatricula);
        if (matricula == null) return new List<string> { "Matrícula não encontrada" };

        return matricula.Disciplinas
            .Where(d => matricula.Avaliacoes.Any(a => a.Disciplina == d))
            .OrderBy(d => d.Nome)
            .Select(d =>
            {
                var media = matricula.CalcularMedia(d);
                var situacao = matricula.ObterSituacao(d);
                var avaliacoes = matricula.Avaliacoes.Where(a => a.Disciplina == d);
                return $"Disciplina: {d.Nome} | Média: {media:F2} | Situação: {situacao}\n" +
                       string.Join("\n", avaliacoes.Select(a => $"  {a}"));
            })
            .ToList();
    }

    public List<string> FiltrarAlunosPorSituacao(string nomeDisciplina)
    {
        var matriculas = _matriculaRepository.BuscarPorDisciplina(nomeDisciplina);
        var disciplina = matriculas
            .SelectMany(m => m.Disciplinas)
            .FirstOrDefault(d => d.Nome.Equals(nomeDisciplina, StringComparison.OrdinalIgnoreCase));

        if (disciplina == null) return new List<string> { "Disciplina não encontrada" };

        var comAvaliacao = matriculas.Where(m => m.Avaliacoes.Any(a => a.Disciplina == disciplina));

        var aprovados = comAvaliacao.Where(m => m.ObterSituacao(disciplina) == "Aprovado").OrderBy(m => m.Aluno.NomeCompleto);
        var recuperacao = comAvaliacao.Where(m => m.ObterSituacao(disciplina) == "Recuperação").OrderBy(m => m.Aluno.NomeCompleto);
        var reprovados = comAvaliacao.Where(m => m.ObterSituacao(disciplina) == "Reprovado").OrderBy(m => m.Aluno.NomeCompleto);

        var resultado = new List<string>();
        resultado.Add("✅ Aprovados:");
        resultado.AddRange(aprovados.Select(m => $"  {m.Aluno.NomeCompleto}"));
        resultado.Add("\n⚠️ Recuperação:");
        resultado.AddRange(recuperacao.Select(m => $"  {m.Aluno.NomeCompleto}"));
        resultado.Add("\n❌ Reprovados:");
        resultado.AddRange(reprovados.Select(m => $"  {m.Aluno.NomeCompleto}"));

        return resultado;
    }
}
