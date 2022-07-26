namespace Taxes.Entities
{
    internal class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company()
        {
        }

        public Company(string name, double anualIncome, int numberOfEmployees) : base(name, anualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Tax()
        {
            double taxValue;

            if (NumberOfEmployees > 10)
            {
                taxValue = AnualIncome * 0.14;
                return taxValue;
            }
            else
            {
                taxValue = AnualIncome * 0.16;
                return taxValue;
            }
        }
    }
}
