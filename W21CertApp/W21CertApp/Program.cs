using W21CertApp;

Console.WriteLine("Welcome to the Products Net Weight Testing App.");

bool AppClose = false;
int id = 1;

do
{
    Console.WriteLine();
    Console.WriteLine("Please select what do you want to do:\n" +
        "1 - Add product results to the program memory and show statistics\n" +
        "2 - Add product results to the .txt file and show statistics\n" +
        "X - Exit the program\n");
    var input = Console.ReadLine();
    
    switch (input.ToUpper())
    {
        case "1":
            try
            {
                AddResultsToMemory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "2":
            try
            {
                AddResultsToFile();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "X":
            AppClose = true;
            break;
        default:
            Console.WriteLine("Invalid operation. Please try again.\n");
            continue;
    }
} while (!AppClose);

Console.WriteLine("Goodbye. Press any key to exit.");
Console.ReadKey();

void AddResultsToMemory()
{
    Console.WriteLine("Insert the product name:");
    var name = Console.ReadLine();
    Console.WriteLine("Insert the product type:");
    var type = Console.ReadLine();
    float declaredNetWeight = 0;
    while (true)
    {
        Console.WriteLine("Insert the product declared net weight in grams:");
        string declaredNetWeightString = Console.ReadLine();
        
        if (float.TryParse(declaredNetWeightString, out float result))
        {
            declaredNetWeight += result;
            break;
        }
        else
        {
            Console.WriteLine("This value cannot be net weight");
        }
    }
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
    {
        var productInMemory = new Product(name, type, declaredNetWeight);
        productInMemory.DifferenceOfNetWeightTooMuch += ProductDifferenceOfNetWeightTooMuch;
        EnterResults(productInMemory);
        productInMemory.ShowStatistics();
    }
    else
    {
        throw new Exception("Incomplete data. Please try again.");
    }
}

void AddResultsToFile()
{
    Console.WriteLine("Insert the product name:");
    var name = Console.ReadLine();
    Console.WriteLine("Insert the product type:");
    var type = Console.ReadLine();
    float declaredNetWeight = 0;
    while (true)
    {
        Console.WriteLine("Insert the product declared net weight in grams:");
        string declaredNetWeightString = Console.ReadLine();
  
        if (float.TryParse(declaredNetWeightString, out float result))
        {
            declaredNetWeight += result;
            break;
        }
        else
        {
            Console.WriteLine("This value cannot be net weight");
        }
    }
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
    {
        var productInFile = new ProductInFile(name, type, declaredNetWeight);
        productInFile.DifferenceOfNetWeightTooMuch += ProductDifferenceOfNetWeightTooMuch;
        productInFile.fullFileName = $"{id}_{productInFile.fullFileName}";
        id++;
        EnterResults(productInFile);
        productInFile.ShowStatistics();
    }
    else
    {
        throw new Exception("Incomplete data. Please try again.");
    }
}

static void EnterResults(IProduct product)
{
    while (true)
    {
        Console.WriteLine($"Enter result for product: {product.Name}");
        var input = Console.ReadLine();

        if (input.ToLower() == "q")
        {
            break;
        }
        try
        {
            product.AddNetWeight(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        { 
            Console.WriteLine("To show statistics enter 'q'.");
        }
    }
}

void ProductDifferenceOfNetWeightTooMuch(object sender, EventArgs e)
{
    Console.WriteLine("Difference between Average and Declared Net Weight is too big. It shouldn't greater than 5g. Please repeat the test.");
}