namespace Taxes.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual()
        {
        }

        public Individual(string name, double anualIncome, double healthExpenditures) : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            double taxValue;

            if (AnualIncome < 20000)
            {
                taxValue = AnualIncome * 0.15;
            }
            else
            {
                taxValue = AnualIncome * 0.25;
            }

            if (HealthExpenditures > 0)
            {
                taxValue -= (HealthExpenditures * 0.5);
                return taxValue;
            }
            else
            {
                return taxValue;
            }
        }
    }
}
