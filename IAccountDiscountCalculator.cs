using System;

namespace BadPractices
{
    public interface IAccountDiscountCalculator
    {
        double ApplyDiscount(double amount);
    }
}