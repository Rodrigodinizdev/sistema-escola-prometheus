using escola.Interfaces.Repositories;
using escola.Models;

namespace escola.Repository;

public class AvaliacaoRepository(IMatriculaRepository matriculaRepository) : IAvaliacaoRepository
{
    private readonly IMatriculaRepository _matriculaRepository = matriculaRepository;

    public void AdicionarAvaliacao(Guid matriculaId, Avaliacao avaliacao)
    {
        var matricula = _matriculaRepository.BuscarPeloId(matriculaId);
        if (matricula == null) return;

        matricula.Avaliacoes.Add(avaliacao);
    }

    public List<Avaliacao> ListarPorMatricula(Guid matriculaId)
    {
        var matricula = _matriculaRepository.BuscarPeloId(matriculaId);
        return matricula?.Avaliacoes ?? new List<Avaliacao>();
    }
}