using System;
using System.Collections.Generic;

namespace BadPractices
{
  public class DictionarableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
  {
    public DictionarableAccountDiscountCalculatorFactory(Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>> discountDict)
    {
        _discountDict = discountDict;
    }
     Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>> _discountDict;

    public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
    {
      
      Lazy<IAccountDiscountCalculator> calculator;
      
      if(!_discountDict.TryGetValue(accountStatus, out calculator))
      {
          throw new NotImplementedException("here is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
      }

      return calculator.Value;
      /* 
      switch (accountStatus)
      {
        case AccountStatus.NotRegistered:
          calculator = new NotRegisteredDiscountCalculator();
          break;
        case AccountStatus.SimpleCustomer:
          calculator = new SimpleCustomerDiscountCalculator();
          break;
        case AccountStatus.ValuableCustomer:
          calculator = new ValuableCustomerDiscountCalculator();
          break;
        case AccountStatus.MostValuableCustomer:
          calculator = new MostValuableCustomerDiscountCalculator();
          break;
        default:
          throw new NotImplementedException();
      }
  
      return calculator; 
      */
    }
  }
}
