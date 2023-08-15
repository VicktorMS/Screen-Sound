// Screen Sound
string welcomeText = "Boas Vindas ao Screen Sound";

//List<string> listaDasBandas = new List<string>(); // Lista vazia 

//Criando um dicionário vazio, onde cada chave tem como valor uma Lista
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();

bandas.Add("Link Park", new List<int> { 10, 6, 5 }); 
bandas.Add("Paramore", new List<int> { 7, 5 }); 
bandas.Add("Iron Maiden", new List<int> { 4 });

void ExibirLogo()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝

░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine("****************************");
    Console.WriteLine(welcomeText);
    Console.WriteLine("****************************\n");
}
void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para exibir todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); // .Parse() Pega um texto e tenta converter para int

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            ResgistrarBanda();
            break;
        case 2:
            ExibirListaDeBandas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaBanda();
            break;
        case 0:
            Console.WriteLine("Adeus!");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void ResgistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Resgistro de Bandas");
    Console.Write("Digite o nome da banda que você deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!; //Exclamação indica que não queremos trabalhar com valores nulos
    bandas.Add(nomeDaBanda, new List<int>());

    Console.WriteLine("A banda {0} foi registrada com sucesso", nomeDaBanda);
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}   

void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo bandas");
    Console.WriteLine("Digite 1 voltar para o menu");
    Console.WriteLine("Exibindo Bandas:\n");

    foreach(string banda in bandas.Keys)
    {
        //int index = bandas.Keys.IndexOf(banda) + 1;
        Console.WriteLine("Banda: {0}", banda);
    }

    Console.ReadKey();
    Console.Clear();
    ExibirMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    string decoracao = "";
    foreach (char letra in titulo)
    {
        decoracao += '*';
    }
    Console.WriteLine($"{decoracao}\n{titulo}\n{decoracao}");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que você dá {nomeDaBanda}?  ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A note {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar para o menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a média das notas de uma banda");
    Console.Write("Digite o nome da banda que deseja saber a média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine("Notas das Bandas: ");
        byte count = 0;
        foreach(int nota in bandas[nomeDaBanda])
        {   
            count++;
            Console.WriteLine($"{count}º nota: {nota}");
        }
        int mediaDeNotas = bandas[nomeDaBanda].Sum() / bandas[nomeDaBanda].Count();
        Console.WriteLine("\nA média das notas é: {0}", mediaDeNotas);
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar para o menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }



}

ExibirMenu();
