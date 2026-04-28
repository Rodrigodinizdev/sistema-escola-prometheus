// Service/AvaliacaoService.cs
using escola.DTOs;
using escola.Interfaces.Repositories;
using escola.Interfaces.Services;
using escola.Models;

namespace escola.Service;

public class AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IMatriculaRepository matriculaRepository, IDisciplinaRepository disciplinaRepository) : IAvaliacaoService
{
    private readonly IAvaliacaoRepository _avaliacaoRepository = avaliacaoRepository;
    private readonly IMatriculaRepository _matriculaRepository = matriculaRepository;
    private readonly IDisciplinaRepository _disciplinaRepository = disciplinaRepository;

    public string AdicionarAvaliacao(AvaliacaoDto dto)
    {
        if (dto.Nota < 0 || dto.Nota > 10)
            return "Nota deve estar entre 0 e 10";

        var matricula = _matriculaRepository.BuscarPeloId(dto.MatriculaId);
        if (matricula == null) return "Matrícula não encontrada";

        var disciplina = _disciplinaRepository.BuscarPorId(dto.DisciplinaId);
        if (disciplina == null) return "Disciplina não encontrada";

        if (!matricula.Disciplinas.Contains(disciplina))
            return "Aluno não está matriculado nessa disciplina";

        var jaTemTeorica = matricula.Avaliacoes.Any(a => a is AvaliacaoTeorica && a.Disciplina == disciplina);
        var jaTemPratica = matricula.Avaliacoes.Any(a => a is AvaliacaoPratica && a.Disciplina == disciplina);

        if (dto.Tipo == "teorica" && jaTemTeorica) return "Aluno já possui avaliação teórica nessa disciplina";
        if (dto.Tipo == "pratica" && jaTemPratica) return "Aluno já possui avaliação prática nessa disciplina";

        Avaliacao avaliacao = dto.Tipo == "teorica"
            ? new AvaliacaoTeorica(dto.Titulo, dto.DataRealizacao, dto.Nota, disciplina)
            : new AvaliacaoPratica(dto.Titulo, dto.DataRealizacao, dto.Nota, disciplina);

        _avaliacaoRepository.AdicionarAvaliacao(dto.MatriculaId, avaliacao);
        return $"Avaliação '{dto.Titulo}' adicionada com sucesso";
    }
}