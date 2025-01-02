namespace CaixaEletronico;

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