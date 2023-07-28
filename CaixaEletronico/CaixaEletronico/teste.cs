namespace CaixaEletronico;

using System;
using System.Collections.Generic;

// Interface para representar uma moeda (Real, Dólar, etc.)
public interface IMoeda
{
    string Simbolo { get; }
    decimal Valor { get; }
}

// Implementação básica da moeda
public class Moeda : IMoeda
{
    public string Simbolo { get; private set; }
    public decimal Valor { get; private set; }

    public Moeda(string simbolo, decimal valor)
    {
        Simbolo = simbolo;
        Valor = valor;
    }
}

// Interface para operações de conta corrente
public interface IContaCorrente
{
    string NomeCompleto { get; set; }
    string CPF { get; set; }
    string Senha { get; set; }
    decimal Saldo { get; }
    void Depositar(IMoeda moeda, decimal quantidade);
    void Sacar(IMoeda moeda, decimal quantidade);
}

// Implementação básica da conta corrente
public class ContaCorrente : IContaCorrente
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; private set; }

    public void Depositar(IMoeda moeda, decimal quantidade)
    {
        // Implementar lógica para o depósito de moedas
    }

    public void Sacar(IMoeda moeda, decimal quantidade)
    {
        // Implementar lógica para o saque de moedas
    }
}

// Interface para as operações do caixa eletrônico
public interface ICaixaEletronico
{
    void RegistrarCotacao(string moedaOrigem, string moedaDestino, decimal cotacao);
    void CarregarNotasMoedas(string tipoMoeda, int quantidade);
    decimal CalcularTaxa(decimal valor, string operacao);
    decimal CalcularTroco(decimal valor, IMoeda moeda);
    decimal CalcularCambio(decimal valor, string moedaOrigem, string moedaDestino);
    void RealizarOperacao(IContaCorrente contaCorrente, string tipoOperacao, IMoeda moeda, decimal quantidade);
    Dictionary<string, int> RelatorioOperacoesPorTipo();
    decimal RelatorioTaxaBanco();
    Dictionary<string, decimal> RelatorioSaldoContasCorrentes();
    Dictionary<string, int> RelatorioNotasMoedasCaixa();
}

// Implementação básica do caixa eletrônico
public class CaixaEletronico : ICaixaEletronico
{
    // Implementar todas as funcionalidades da interface ICaixaEletronico
    // de acordo com as especificações do projeto
}

class Program
{
    static void Main()
    {
        // Crie instâncias das classes do caixa eletrônico e teste as funcionalidades
    }
}