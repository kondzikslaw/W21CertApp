using static W21CertApp.ProductBase;

namespace W21CertApp
{
    public interface IProduct
    {
        string Name { get;}

        string Type { get;}

        float DeclaredNetWeight { get;}

        event DifferenceOfNetWeightTooMuchDelegate DifferenceOfNetWeightTooMuch;

        void AddNetWeight(float netWeight);

        void AddNetWeight(string netWeight);

        void ShowResults();

        Statistics GetStatistics();

        void ShowStatistics();
    }
}
