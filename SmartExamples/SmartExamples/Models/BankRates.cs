namespace SmartExamples.Models
{
    public class LowBankRate : IRate
    {
        public double GetInterestRate()
        {
            return 1.1;
        }
    }

    public class MiddleBankRate : IRate
    {
        public double GetInterestRate()
        {
            return 1.2;
        }
    }

    public class BigBankRate : IRate
    {
        public double GetInterestRate()
        {
            return 1.3;
        }
    }
}