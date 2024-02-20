using System;
using System.Collections.Generic;

// Classe Pessoa para representar os hóspedes
class Pessoa
{
    // Propriedades da pessoa
    public string Nome { get; set; } // Nome da pessoa
    public int Idade { get; set; } // Idade da pessoa
    public string Genero { get; set; } // Gênero da pessoa
    public string Profissao { get; set; } // Profissão da pessoa
}

// Classe Suíte para representar os tipos de quartos disponíveis
class Suite
{
    // Propriedades da suíte
    public int Capacidade { get; set; } // Capacidade da suíte (quantas pessoas podem ficar)
    public decimal ValorDiaria { get; set; } // Valor da diária da suíte

    public int Numero { get; set; } // Numero do quarto
}

// Classe Reserva para representar as reservas feitas pelos hóspedes
class Reserva
{
    // Propriedades da reserva
    public Pessoa Hospede { get; set; } // Hóspede que fez a reserva
    public Suite SuiteReservada { get; set; } // Suíte reservada
    public DateTime DataInicio { get; set; } // Data de início da reserva
    public DateTime DataFim { get; set; } // Data de fim da reserva

    // Método para calcular o valor total da reserva
    public decimal CalcularValorTotal()
    {
        TimeSpan duracao = DataFim - DataInicio;
        int diasReserva = duracao.Days + 1; // incluindo o último dia

        decimal valorTotal = diasReserva * SuiteReservada.ValorDiaria;

        if (diasReserva > 10)
        {
            valorTotal *= 0.9m; // Aplicando desconto de 10% se a reserva for maior que 10 dias
        }

        return valorTotal;
    }
}

class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>(); // Lista para armazenar os hóspedes
    static List<Suite> suites = new List<Suite>(); // Lista para armazenar os tipos de quartos disponíveis
    static List<Reserva> reservas = new List<Reserva>(); // Lista para armazenar as reservas feitas pelos hóspedes

    static void Main(string[] args)
    {
        ExibirMenu(); // Chamando a função para exibir o menu no início do programa
    }

    static void ExibirMenu()
    {
        while (true) // Loop infinito para manter o menu visível até que o usuário escolha sair
        {
            // Exibindo o menu principal
            Console.WriteLine("======================== MENU ========================");
            Console.WriteLine("1 Cadastro"); // Opção para acessar o submenu de cadastro
            Console.WriteLine("2 Consultar"); // Opção para consultar informações
            Console.WriteLine("3 Listar"); // Opção para listar informações
            Console.WriteLine("4 Opção SAIR"); // Opção para sair do programa
            Console.WriteLine("======================================================");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine(); // Lendo a opção escolhida pelo usuário

            switch (opcao)
            {
                case "1":
                    ExibirMenuCadastro(); // Se escolher "1", exibir submenu de cadastro
                    break;
                case "2":
                    ConsultarHospede(); // Se escolher "2", consultar hóspede
                    break;
                case "3":
                    ListarReservas(); // Se escolher "3", listar reservas
                    break;
                case "4":
                    return; // Se escolher "4", sair do programa
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void ExibirMenuCadastro()
    {
        while (true) // Loop para manter o submenu de cadastro visível até que o usuário saia
        {
            // Exibindo o submenu de cadastro
            Console.WriteLine("======================== CADASTRO ========================");
            Console.WriteLine("1 Hospede"); // Opção para cadastrar hóspede
            Console.WriteLine("2 Suite"); // Opção para cadastrar suíte
            Console.WriteLine("3 Reserva"); // Opção para realizar reserva
            Console.WriteLine("4 Voltar ao menu inicial"); // Opção para sair do submenu
            Console.WriteLine("===========================================================");
            Console.Write("Escolha uma opção de cadastro (ou digite 'S' para sair): ");

            string opcao = Console.ReadLine(); // Lendo a opção escolhida pelo usuário

            switch (opcao)
            {
                case "1":
                    CadastrarPessoa(); // Se escolher "1", cadastrar hóspede
                    break;
                case "2":
                    CadastrarSuite(); // Se escolher "2", cadastrar suíte
                    break;
                case "3":
                    RealizarReserva(); // Se escolher "3", realizar reserva
                    break;
                case "4":
                    return; // Se escolher "4", sair do programa
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarPessoa()
    {
        // Função para cadastrar um novo hóspede
        Pessoa pessoa = new Pessoa(); // Criando um novo objeto Pessoa
        Console.WriteLine("==== Cadastro de Pessoa ====");
        Console.Write("Nome: ");
        pessoa.Nome = Console.ReadLine(); // Lendo o nome do hóspede
        Console.Write("Idade: ");
        pessoa.Idade = int.Parse(Console.ReadLine()); // Lendo a idade do hóspede
        Console.Write("Gênero: ");
        pessoa.Genero = Console.ReadLine(); // Lendo o gênero do hóspede
        Console.Write("Profissão: ");
        pessoa.Profissao = Console.ReadLine(); // Lendo a profissão do hóspede

        pessoas.Add(pessoa); // Adicionando o hóspede à lista de hóspedes
        Console.WriteLine("Pessoa cadastrada com sucesso!\n");
    }

    // Função para cadastrar uma nova suíte
    static void CadastrarSuite()
    {
        Suite suite = new Suite(); // Criando um novo objeto Suite
        Console.WriteLine("==== Cadastro de Suíte ====");
        Console.WriteLine("Numero da Suite: ");
        suite.Numero = int.Parse(Console.ReadLine()); //Lendo o número do quarto
        Console.Write("Capacidade: ");
        suite.Capacidade = int.Parse(Console.ReadLine()); // Lendo a capacidade da suíte
        Console.Write("Valor da Diária: ");
        suite.ValorDiaria = decimal.Parse(Console.ReadLine()); // Lendo o valor da diária da suíte

        suites.Add(suite); // Adicionando a suíte à lista de suítes
        Console.WriteLine("Suíte cadastrada com sucesso!\n");
    }

    // Função para realizar uma nova reserva
    static void RealizarReserva()
    {
        Reserva reserva = new Reserva(); // Criando um novo objeto Reserva
        Console.WriteLine("==== Realizar Reserva ====");
        Console.WriteLine("Selecione o hóspede:");
        for (int i = 0; i < pessoas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pessoas[i].Nome}");
        }
        Console.Write("Escolha o número correspondente: ");
        int indicePessoa = int.Parse(Console.ReadLine()) - 1;
        reserva.Hospede = pessoas[indicePessoa]; // Selecionando o hóspede para a reserva

        Console.WriteLine("Selecione a suíte:");
        for (int i = 0; i < suites.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Suíte para {suites[i].Capacidade} pessoas");
        }
        Console.Write("Escolha o número correspondente: ");
        int indiceSuite = int.Parse(Console.ReadLine()) - 1;
        reserva.SuiteReservada = suites[indiceSuite]; // Selecionando a suíte para a reserva

        Console.Write("Data de Início da Reserva (dd/MM/yyyy): ");
        reserva.DataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); // Lendo a data de início da reserva
        Console.Write("Data de Fim da Reserva (dd/MM/yyyy): ");
        reserva.DataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); // Lendo a data de fim da reserva

        reservas.Add(reserva); // Adicionando a reserva à lista de reservas
        Console.WriteLine("Reserva realizada com sucesso!\n");

        decimal valorTotal = reserva.CalcularValorTotal(); // Calculando o valor total da reserva
        Console.WriteLine($"Valor total da reserva: R${valorTotal}\n");
        ExibirMenu();
    }

    // Função para consultar um hóspede
    static void ConsultarHospede()
    {
        Console.WriteLine("==== Consultar Hóspede ====");
        Console.Write("Nome do hóspede: ");
        string nome = Console.ReadLine(); // Lendo o nome do hóspede

        // Buscando o hóspede na lista de hóspedes
        Pessoa hospede = pessoas.Find(p => p.Nome == nome);

        if (hospede != null) // Verificando se o hóspede foi encontrado
        {
            // Exibindo informações do hóspede
            Console.WriteLine($"Nome: {hospede.Nome}");
            Console.WriteLine($"Idade: {hospede.Idade}");
            Console.WriteLine($"Gênero: {hospede.Genero}");
            Console.WriteLine($"Profissão: {hospede.Profissao}");

            // Buscando reservas associadas ao hóspede
            var reservasDoHospede = reservas.Where(r => r.Hospede.Nome == nome).ToList();
            if (reservasDoHospede.Count > 0) // Verificando se o hóspede tem reservas
            {
                Console.WriteLine("\nReservas do Hóspede:");
                foreach (var reserva in reservasDoHospede)
                {
                    // Exibindo informações das reservas do hóspede
                    Console.WriteLine($"- Suíte: {reserva.SuiteReservada.Capacidade} pessoas");
                    Console.WriteLine($"  Data de Início: {reserva.DataInicio.ToShortDateString()}");
                    Console.WriteLine($"  Data de Fim: {reserva.DataFim.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("\nO hóspede não possui reservas.");
            }
        }
        else
        {
            Console.WriteLine("Hóspede não encontrado.");
        }
    }

    // Função para listar as reservas
    static void ListarReservas()
    {
        Console.WriteLine("==== Lista de Reservas ====");
        foreach (var reserva in reservas)
        {
            // Exibindo informações das reservas
            Console.WriteLine($"Hóspede: {reserva.Hospede.Nome}");
            Console.WriteLine($"Suíte: {reserva.SuiteReservada.Capacidade} pessoas");
            Console.WriteLine($"Data de Início: {reserva.DataInicio.ToShortDateString()}");
            Console.WriteLine($"Data de Fim: {reserva.DataFim.ToShortDateString()}");
            decimal valorTotal = reserva.CalcularValorTotal();
            Console.WriteLine($"Valor Total: R${valorTotal}");
            Console.WriteLine();
        }
    }
}
