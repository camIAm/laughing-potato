using System;

namespace BadPractices
{
    public static class DiscountConstraints
    {
        public static double notRegisteredDiscount = 0.0;
        public static double simpleDiscountPercent{get;set;} = 0.02;
        public static double valuableDiscountPercent = 0.04;

        public static double mostValuableDiscountPercent = 0.06;
    }
}