using System;
using System.Linq;
class Pessoa
{
    
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Genero { get; set; } 
    public string Profissao { get; set; }
}

class Suite
{
    
    public int Capacidade { get; set; } 
    public decimal ValorDiaria { get; set; }

    public int Numero { get; set; } 
}

class Reserva
{
    public Pessoa Hospede { get; set; } 
    public Suite SuiteReservada { get; set; } 
    public DateTime DataInicio { get; set; } 
    public DateTime DataFim { get; set; } 

    public decimal CalcularValorTotal()
    {
        TimeSpan duracao = DataFim - DataInicio;
        int diasReserva = duracao.Days + 1; 
        decimal valorTotal = diasReserva * SuiteReservada.ValorDiaria;

        if (diasReserva > 10)
        {
            valorTotal *= 0.9m; 
        }

        return valorTotal;
    }
}

class Program
{
    static Pessoa[] pessoas = new Pessoa[100]; 
    static Suite[] suites = new Suite[50]; 
    static Reserva[] reservas = new Reserva[100]; 
    static int numPessoas = 0; 
    static int numSuites = 0;
    static int numReservas = 0; 

    static void Main(string[] args)
    {
        ExibirMenu(); 
    }

    static void ExibirMenu()
    {
        while (true) 
        {
            
            Console.WriteLine("________________________ MENU ________________________");
            Console.WriteLine("1 Cadastro"); 
            Console.WriteLine("2 Consultar"); 
            Console.WriteLine("3 Listar"); 
            Console.WriteLine("4 Opção SAIR"); 
            Console.WriteLine("______________________________________________________");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine(); 

            switch (opcao)
            {
                case "1":
                    ExibirMenuCadastro();
                    break;
                case "2":
                    ConsultarHospede(); 
                    break;
                case "3":
                    ListarReservas(); 
                    break;
                case "4":
                    return; 
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void ExibirMenuCadastro()
    {
        while (true) 
        {
            
            Console.WriteLine("_______________________ CADASTRO _________________________");
            Console.WriteLine("1 Hospede"); 
            Console.WriteLine("2 Suite");
            Console.WriteLine("3 Reserva"); 
            Console.WriteLine("4 Voltar ao menu inicial"); 
            Console.WriteLine("___________________________________________________________");
            Console.Write("Escolha uma opção de cadastro (ou digite 'S' para sair): ");

            string opcao = Console.ReadLine(); 

            switch (opcao)
            {
                case "1":
                    CadastrarPessoa(); 
                    break;
                case "2":
                    CadastrarSuite(); 
                    break;
                case "3":
                    RealizarReserva(); 
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarPessoa()
    {
        
        Pessoa pessoa = new Pessoa();
        Console.WriteLine("==== Cadastro de Pessoa ====");
        Console.Write("Nome: ");
        pessoa.Nome = Console.ReadLine(); 
        Console.Write("Idade: ");
        pessoa.Idade = int.Parse(Console.ReadLine()); 
        Console.Write("Gênero: ");
        pessoa.Genero = Console.ReadLine(); 
        Console.Write("Profissão: ");
        pessoa.Profissao = Console.ReadLine(); 

        pessoas[numPessoas] = pessoa; // hóspede adicionado ao array de hóspedes
        numPessoas++; // contador de pessoas
        Console.WriteLine("Pessoa cadastrada com sucesso!\n");
    }

    
    static void CadastrarSuite()
    {
        Suite suite = new Suite();
        Console.WriteLine("==== Cadastro de Suíte ====");
        Console.WriteLine("Numero da Suite: ");
        suite.Numero = int.Parse(Console.ReadLine()); 
        Console.Write("Capacidade: ");
        suite.Capacidade = int.Parse(Console.ReadLine());
        Console.Write("Valor da Diária: ");
        suite.ValorDiaria = decimal.Parse(Console.ReadLine()); 

        suites[numSuites] = suite; //suíte adicionada ao array de suítes
        numSuites++; //contador de suites
        Console.WriteLine("Suíte cadastrada com sucesso!\n");
    }

    
    static void RealizarReserva()
    {
        Reserva reserva = new Reserva(); 
        Console.WriteLine("==== Realizar Reserva ====");
        Console.WriteLine("Selecione o hóspede:");
        for (int i = 0; i < numPessoas; i++)
        {
            Console.WriteLine($"{i + 1}. {pessoas[i].Nome}");
        }
        Console.Write("Escolha o número correspondente: ");
        int indicePessoa = int.Parse(Console.ReadLine()) - 1;
        reserva.Hospede = pessoas[indicePessoa]; 

        Console.WriteLine("Selecione a suíte:");
        for (int i = 0; i < numSuites; i++)
        {
            Console.WriteLine($"{i + 1}. Suíte para {suites[i].Capacidade} pessoas");
        }
        Console.Write("Escolha o número correspondente: ");
        int indiceSuite = int.Parse(Console.ReadLine()) - 1;
        reserva.SuiteReservada = suites[indiceSuite]; 

        Console.Write("Data de Início da Reserva (dd/MM/yyyy): ");
        reserva.DataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); 
        Console.Write("Data de Fim da Reserva (dd/MM/yyyy): ");
        reserva.DataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); 

        reservas[numReservas] = reserva; //reserva adicionada ao array de reservas
        numReservas++; //contador de reservas
        Console.WriteLine("Reserva realizada com sucesso!\n");

        decimal valorTotal = reserva.CalcularValorTotal(); 
        Console.WriteLine($"Valor total da reserva: R${valorTotal}\n");
    }

  
    static void ConsultarHospede()
    {
        Console.WriteLine("==== Consultar Hóspede ====");
        Console.Write("Nome do hóspede: ");
        string nome = Console.ReadLine(); 

        
        Pessoa hospede = null;  
        for (int i = 0; i < numPessoas; i++) // Buscando hospede no array
        {
            if (pessoas[i].Nome == nome)
            {
                hospede = pessoas[i];
                break;
            }
        }

        if (hospede != null) 
        {
            
            Console.WriteLine($"Nome: {hospede.Nome}");
            Console.WriteLine($"Idade: {hospede.Idade}");
            Console.WriteLine($"Gênero: {hospede.Genero}");
            Console.WriteLine($"Profissão: {hospede.Profissao}");

           
            Console.WriteLine("\nReservas do Hóspede:");
            for (int i = 0; i < numReservas; i++)
            {
                if (reservas[i].Hospede.Nome == nome)
                {
                    
                    Console.WriteLine($"- Suíte: {reservas[i].SuiteReservada.Capacidade} pessoas");
                    Console.WriteLine($"  Data de Início: {reservas[i].DataInicio.ToShortDateString()}");
                    Console.WriteLine($"  Data de Fim: {reservas[i].DataFim.ToShortDateString()}");
                }
            }
        }
        else
        {
            Console.WriteLine("Hóspede não encontrado.");
        }
    }

    static void ListarReservas()
    {
        Console.WriteLine("==== Lista de Reservas ====");
        for (int i = 0; i < numReservas; i++)
        {
            Console.WriteLine($"Hóspede: {reservas[i].Hospede.Nome}");
            Console.WriteLine($"Suíte: {reservas[i].SuiteReservada.Capacidade} pessoas");
            Console.WriteLine($"Data de Início: {reservas[i].DataInicio.ToShortDateString()}");
            Console.WriteLine($"Data de Fim: {reservas[i].DataFim.ToShortDateString()}");
            decimal valorTotal = reservas[i].CalcularValorTotal();
            Console.WriteLine($"Valor Total: R${valorTotal}");
            Console.WriteLine();
        }
    }
}
