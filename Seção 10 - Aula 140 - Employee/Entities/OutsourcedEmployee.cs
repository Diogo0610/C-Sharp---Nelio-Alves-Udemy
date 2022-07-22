namespace EmployeeAndOutsourcedEmployee.Entities
{
    class OutsourcedEmployee: Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee()
        {
        }

        public OutsourcedEmployee(double additionalCharge)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            return base.Payment() + AdditionalCharge;
        }
    }
}
