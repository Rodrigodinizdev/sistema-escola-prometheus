using escola.Models;

namespace escola.Interfaces.Repositories;

public interface IAvaliacaoRepository
{
    void AdicionarAvaliacao(Guid matriculaId, Avaliacao avaliacao);
    List<Avaliacao> ListarPorMatricula(Guid matriculaId);
}
