class ContaBancaria
{
    public string CPF { get; }
    public string NomeTitular { get; }
    public string NumeroConta { get; }
    public decimal Saldo { get; private set; }
    public List<Operacao> Extrato { get; }

    public ContaBancaria(string nomeTitular, string numeroConta, string numeroCpf)
    {
        CPF = numeroCpf;
        NomeTitular = nomeTitular;
        NumeroConta = numeroConta;
        Saldo = 0;
        Extrato = new List<Operacao>();
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Extrato.Add(new Operacao(DateTime.Now, "Depósito", valor));
            Console.WriteLine("Depósito realizado com sucesso :)");
        }
        else
        {
            Console.WriteLine("Valor de depósito inválido!");
        }
    }

    public bool Sacar(decimal valor)
    {
        decimal taxaSaque = valor * 0.045m;
        decimal valorTotalSaque = valor + taxaSaque;

        if (valorTotalSaque <= Saldo)
        {
            Saldo -= valorTotalSaque;
            Extrato.Add(new Operacao(DateTime.Now, "Saque", valorTotalSaque));
            Console.WriteLine("Saque realizado com sucesso :)");
            return true;
        }
        else
        {
            Console.WriteLine("Saldo insuficiente ou valor de saque inválido!");
            return false;
        }
    }
}