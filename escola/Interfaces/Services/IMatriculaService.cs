using escola.DTOs;
using escola.Models;

namespace escola.Interfaces.Services;

public interface IMatriculaService
{
    string CriarMatricula(MatriculaDto dto);
    List<Matricula> ListarMatriculas();
    string AdicionarDisciplina(Guid matriculaId, string disciplinaId);
    List<string> BuscarAlunoPorNome(string nome);
    List<string> RankingPorDisciplina(string nomeDisciplina);
    List<string> BoletimAluno(string matriculaId);
    List<string> FiltrarAlunosPorSituacao(string nomeDisciplina);

}
