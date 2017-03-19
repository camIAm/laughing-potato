using System;

namespace BadPractices
{
    public class NotRegisteredDiscountCalculator: IAccountDiscountCalculator
   {
       public double  ApplyDiscount(double amount)
       {
           return amount * (1 - amount * DiscountConstraints.notRegisteredDiscount);
       }

    }
   public class SimpleCustomerDiscountCalculator: IAccountDiscountCalculator
   {
       /*
        private readonly IUser _user; // _user keeps the state
                                     //  we cant use this in a multi threaded application
        public SetUser(IUser user)
        {
            _user = user;
        }
       */
       public double ApplyDiscount(double amount)
       {
           return amount * (1 - amount * DiscountConstraints.simpleDiscountPercent);
           
       }

   }
   public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
   {
       public double ApplyDiscount(double amount)
       {
           return amount * (1 - amount * DiscountConstraints.valuableDiscountPercent);
           
       }
   }
   public class  MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
   {
       public double ApplyDiscount(double amount)
       {
           return amount * (1 - DiscountConstraints.mostValuableDiscountPercent);
       }
   }
}