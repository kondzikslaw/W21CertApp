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
//float DeclaredWeightStringCheck(string weight)
//{
//    if (float.TryParse(weight, out float result))
//    {
//        return result;
//    }
//}

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

//var product1 = new ProductInFile("Sausage", "Meat", 500);
//var product2 = new ProductInFile("Chicken Bites", "Meat", 400);
//product1.DifferenceOfNetWeightTooMuch += ProductDifferenceOfNetWeightTooMuch;


//product1.AddNetWeight(5);
//product1.AddNetWeight(0.7f);
//product1.AddNetWeight(6.13f);
//product1.AddNetWeight("13,2");

//product2.AddNetWeight(415.33f);
//product2.AddNetWeight(399.7f);
//product2.AddNetWeight(387.13f);
//product2.AddNetWeight("401,2");

//product1.ShowStatistics();
//product2.ShowStatistics();

//void ProductDifferenceOfNetWeightTooMuch(object sender, EventArgs e)
//{
//    Console.WriteLine("Difference between Average and Declared Net Weight is too big. Please repeat the test.");
//}