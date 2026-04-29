using escola.DTOs;
using escola.Interfaces.Repositories;
using escola.Interfaces.Services;
using escola.Models;

namespace escola.Service;

public class AlunoService(IAlunoRepository alunoRepository) : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository = alunoRepository;

    public string CriarAluno(AlunoDto dto)
    {
        var aluno = _alunoRepository.BuscarPeloCpf(dto.Cpf);

        if (aluno != null)
            return $"Aluno já cadastrado";

         aluno = new Aluno(dto.NomeCompleto, dto.DataNascimento, dto.Cpf);
        _alunoRepository.CadastrarAluno(aluno);
        return $"{aluno.NomeCompleto} criado com sucesso";
    }

    public List<Aluno> ListarAlunos()
    {
        return _alunoRepository.ListarAlunos();
    }
}
