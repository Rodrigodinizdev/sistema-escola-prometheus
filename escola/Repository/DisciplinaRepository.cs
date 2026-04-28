using escola.Interfaces.Repositories;
using escola.Models;

namespace escola.Repository;

public class DisciplinaRepository : IDisciplinaRepository
{
    private readonly List<Disciplina> _disciplinas = [];

    public Disciplina BuscarPorId(string id) => _disciplinas.FirstOrDefault(d => d.Id == id);
   
    public void CadastrarDisciplina(Disciplina disciplina) => _disciplinas.Add(disciplina);
    
    public List<Disciplina> ListarDisciplinas() => _disciplinas.ToList();
  
}
