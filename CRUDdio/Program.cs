//dotnet 6.0
using CRUDdio;

SerieRepositorio repositorio = new SerieRepositorio();


string opcaoUsuario = ObterOpcaoUsuario();
while(opcaoUsuario.ToUpper() != "X")
{
    switch (opcaoUsuario)
    {
        case "1":
            ListarSeries(repositorio);
            break;
        case "2":
            InserirSerie(repositorio);
            break;
        case "3":
            AtualizarSerie(repositorio);
            break;
        case "4":
            ExcluirSerie(repositorio);
            break ;
        case "5":
            VisualizarSerie(repositorio);
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    opcaoUsuario = ObterOpcaoUsuario();
}
Console.WriteLine("O serviço foi encerrado.");
Console.ReadLine();


static void ListarSeries(SerieRepositorio repositorio)
{
    Console.WriteLine("Listar séries");
    var lista = repositorio.Lista();

    if(lista.Count == 0)
    {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
    }

    foreach(var serie in lista)
    {
        Console.WriteLine($"#ID {serie.Id}: - {serie.Titulo}");
    }
}

static void InserirSerie(SerieRepositorio repositorio)
{
    Console.WriteLine("Inserir nova série");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
    }

    Console.Write("Digite o genêro entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o título da Série: ");
    string entradaTitulo = Console.ReadLine();
    Console.WriteLine("Digite o Ano de Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a descrição da Série: ");
    string entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                                titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno);

    repositorio.Insere(novaSerie);
}

static void AtualizarSerie(SerieRepositorio repositorio)
{
    Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
    }

    Console.WriteLine("Digite o genêro entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o Título da série: ");
    string entradaTitulo = Console.ReadLine();
    Console.WriteLine("Digite o Ano de início da série: ");
    int entradaAno = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a Descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie atualizaSerie = new Serie(indiceSerie, (Genero)entradaGenero, entradaTitulo,
                                    entradaDescricao, entradaAno);

    repositorio.Atualiza(indiceSerie, atualizaSerie);
}

static void ExcluirSerie(SerieRepositorio repositorio)
{
    Console.WriteLine("Digite o id da série a ser excluida: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    if (indiceSerie >=0 )
    {
        Console.WriteLine("Deseja mesmo excluir a série?" + Environment.NewLine + "S para confimar ou qualquer tecla para sair... ?");
        string confirmDelete = Console.ReadLine();
        if (confirmDelete.ToUpper() == "S")
        {
            repositorio.Exclui(indiceSerie);
        }
        else
        {
            return;
        }
    }
}

static void VisualizarSerie(SerieRepositorio repositorio)
{
    Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(indiceSerie);
    Console.WriteLine(serie);
}

static string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("Console Séries");
    Console.WriteLine("Informe a opção desejada: ");
    Console.WriteLine();
    Console.WriteLine("1 - Listar séries");
    Console.WriteLine("2 - Inserir nova série");
    Console.WriteLine("3 - Atualizar série");
    Console.WriteLine("4 - Excluir série");
    Console.WriteLine("5 - Visualizar série");
    Console.WriteLine("C - Limpar tela");
    Console.WriteLine("X - Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}

