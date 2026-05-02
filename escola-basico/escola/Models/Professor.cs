namespace escola.Models;

public class Professor : Pessoa
{
    public Professor(string nomeCompleto, DateTime dataNascimento, string cpf, string especializacao) : base(nomeCompleto, dataNascimento, cpf)
    {
        NumeroRegistro = GerarRegistro();
        Especializacao = especializacao;
    }

    public string NumeroRegistro { get; private set; }
    public string Especializacao { get; }
    private static int _contador = 1;

    public string GerarRegistro() => $"{DateTime.Now.Year}{_contador++}";

    public override string ToString() => $"Registro: {NumeroRegistro} | Professor: {NomeCompleto} | Especialização: {Especializacao}";

}
