namespace escola.Models;

public class Aluno : Pessoa
{
    public Aluno(string nomeCompleto, DateTime dataNascimento, string cpf) : base(nomeCompleto, dataNascimento, cpf)
    {

    }
    public override string ToString() => $"Id: {Id} | Nome: {NomeCompleto} | Data Nascimento: {DataNascimento} | CPF: {CPF}";
}
