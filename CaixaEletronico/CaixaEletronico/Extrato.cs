class Operacao
{
    public DateTime DataHora { get; }
    public string Tipo { get; }
    public decimal Valor { get; }

    public Operacao(DateTime dataHora, string tipo, decimal valor)
    {
        DataHora = dataHora;
        Tipo = tipo;
        Valor = valor;
    }
}