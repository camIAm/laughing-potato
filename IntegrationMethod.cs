using System;
using System.Collections.Generic;

namespace BadPractices
{
    public class IntegrationMethod
    {
        //IAccountDiscountCalculator _calculator;
        IAccountDiscountCalculatorFactory _factory;
        public IntegrationMethod(IAccountDiscountCalculatorFactory factory)
        {
           // _calculator = calculator;
            _factory = factory;
        }
        double price;
        public double GetCustomerDiscount(AccountStatus accountStatus, double amount)
        {
            price = _factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(amount);
            //price = status.ApplyDiscount(amount);
            return price;
        }
    }
}