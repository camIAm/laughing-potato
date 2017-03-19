using System;
using System.Collections.Generic;

namespace BadPractices
{
    public interface IAccountDiscountCalculatorFactory
    {
       IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
    }
}