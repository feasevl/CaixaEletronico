namespace CaixaEletronico;

class RelatorioDiario
{
    private Dictionary<string, List<Operacao>> _relatorio;

    public RelatorioDiario()
    {
        _relatorio = new Dictionary<string, List<Operacao>>();
    }

    public void RegistrarOperacao(string numeroConta, Operacao operacao)
    {
        if (!_relatorio.ContainsKey(numeroConta))
        {
            _relatorio[numeroConta] = new List<Operacao>();
        }

        _relatorio[numeroConta].Add(operacao);
    }

    public void GerarRelatorio()
    {
        Console.WriteLine("RELATÓRIO DIÁRIO DE OPERAÇÕES DOS CLIENTES DO CAIXA ELETRÔNICO\n");

        foreach (var conta in _relatorio)
        {
            Console.WriteLine($"Número da conta: {conta.Key}");
            foreach (var operacao in conta.Value)
            {
                Console.WriteLine($"{operacao.DataHora} - {operacao.Tipo}: R${operacao.Valor}");
            }
            Console.WriteLine();
        }
    }
}