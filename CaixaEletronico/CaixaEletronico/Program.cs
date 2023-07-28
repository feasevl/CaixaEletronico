namespace CaixaEletronico
{
    class Program
    {
        static List<ContaBancaria> _contas = new List<ContaBancaria>();
        private static RelatorioDiario _relatorioDiario = new RelatorioDiario();
        
        static void Main(string[] args)
        {
            bool executar = true;

            while (executar)
            {
                Console.WriteLine("BEM-VINDO AO SEU CAIXA ELETRÔNICO :)");
                Console.WriteLine("1 - Criar conta");
                Console.WriteLine("2 - Depositar dinheiro");
                Console.WriteLine("3 - Sacar dinheiro");
                Console.WriteLine("4 - Verificar saldo");
                Console.WriteLine("5 - Extrato");
                Console.WriteLine("6 - Pagar contas");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma das opções: ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            CriarConta();
                            break;
                        case 2:
                            Depositar();
                            break;
                        case 3:
                            Sacar();
                            break;
                        case 4:
                            VerificarSaldo();
                            break;
                        case 5:
                            Extrato();
                            break;
                        case 0:
                            executar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente :( ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Tente novamente :( ");
                }

                Console.WriteLine();
            }
        }

        static void CriarConta()
        {
            Console.Write("Digite o nome completo do titular da conta: ");
            string nomeTitular = Console.ReadLine();

            Console.Write("Digite o número do CPF: ");
            string numeroCpf = Console.ReadLine();

            Console.Write("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTitular) || string.IsNullOrWhiteSpace(numeroCpf) ||
                string.IsNullOrWhiteSpace(numeroConta))
            {
                Console.WriteLine("Nome completo, CPF e número de conta são obrigatórios, por favor, tente novamente!");
                return;
            }

            if (numeroConta == "1111" || numeroConta == "0000" || numeroConta == "9999")
            {
                Console.WriteLine("Número de conta inválido! Por favor, tente novamente.");
                return; 
            }

            if (_contas.Exists(conta => conta.NumeroConta == numeroConta))
            {
                Console.WriteLine("Essa conta já existe! Por favor, tente novamente com outro número de conta.");
                return; 
            }

            ContaBancaria novaConta = new ContaBancaria(nomeTitular, numeroConta, numeroCpf);
            _contas.Add(novaConta);

            Console.WriteLine("Conta criada com sucesso! :)");
        }

        static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            ContaBancaria conta = BuscarConta(numeroConta);
            if (conta != null)
            {
                Console.Write("Digite o valor a ser depositado: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                {
                    conta.Depositar(valorDeposito);
                    Console.WriteLine("Depósito realizado com sucesso :)");
                }
                else
                {
                    Console.WriteLine("Valor de depósito inválido!");
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada :(");
            }
        }

        static void Sacar()
            {
                Console.Write("Digite o número da conta: ");
                string numeroConta = Console.ReadLine();

                ContaBancaria conta = BuscarConta(numeroConta);
                if (conta != null)
                {
                    Console.Write("Digite o valor a ser sacado: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                    {
                        if (conta.Sacar(valorSaque))
                        {
                            Console.WriteLine("Saque realizado com sucesso :)");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente ou valor de saque inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor de saque inválido!");
                    }
                }
                else
                {
                    Console.WriteLine("Conta não encontrada :(");
                }
            }
        
        static void VerificarSaldo()
        {
            Console.Write("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            ContaBancaria conta = BuscarConta(numeroConta);
            if (conta != null)
            {
                Console.WriteLine($"Saldo da conta {conta.NumeroConta}: R${conta.Saldo}");
            }
            else
            {
                Console.WriteLine("Conta não encontrada :(");
            }
        }

        static void Extrato()
        {
            Console.Write("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            ContaBancaria conta = BuscarConta(numeroConta);
            if (conta != null)
            {
                Console.WriteLine($"Extrato da conta {conta.NumeroConta}:");
                foreach (var operacao in conta.Extrato)
                {
                    Console.WriteLine($"{operacao.DataHora} - {operacao.Tipo}: R${operacao.Valor}");
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada :(");
            }
        }

        static ContaBancaria BuscarConta(string numeroConta)
        {
            return _contas.Find(conta => conta.NumeroConta == numeroConta);
        }
    }
}