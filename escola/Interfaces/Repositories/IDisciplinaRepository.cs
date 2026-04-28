using escola.Models;

namespace escola.Interfaces.Repositories;

public interface IDisciplinaRepository
{
    void CadastrarDisciplina(Disciplina disciplina);
    Disciplina BuscarPorId(string id);
    List<Disciplina> ListarDisciplinas();

}
