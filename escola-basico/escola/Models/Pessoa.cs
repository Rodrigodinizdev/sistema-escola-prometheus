namespace escola.Models;

public abstract class Pessoa
{
    public Pessoa(string nomeCompleto, DateTime dataNascimento, string cpf)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }
    public Guid Id { get; }
    public string NomeCompleto { get; }
    public DateTime DataNascimento { get; }
    public string CPF { get; }

    public override string ToString() => $"Id: {Id} | Aluno: {NomeCompleto} | Data Nascimento: {DataNascimento} | CPF: {CPF}";
}
