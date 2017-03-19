using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Framework.DependencyInjection;
using System.Xml.Linq;

namespace BadPractices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var discountsDictionary = new Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>>
            {
                {AccountStatus.NotRegistered,new Lazy<IAccountDiscountCalculator>(()=> new NotRegisteredDiscountCalculator())},
                {AccountStatus.SimpleCustomer, new Lazy<IAccountDiscountCalculator>(()=> new SimpleCustomerDiscountCalculator())},
                {AccountStatus.ValuableCustomer, new Lazy<IAccountDiscountCalculator>(()=> new ValuableCustomerDiscountCalculator())},
                {AccountStatus.MostValuableCustomer, new Lazy<IAccountDiscountCalculator>(()=> new MostValuableCustomerDiscountCalculator())},
            };
            
            double originalPrice = 100.50;
            IAccountDiscountCalculatorFactory df = new DictionarableAccountDiscountCalculatorFactory(discountsDictionary);
            IntegrationMethod im = new IntegrationMethod(df);
            double reducedPrice = im.GetCustomerDiscount(AccountStatus.MostValuableCustomer, originalPrice);
            Console.WriteLine($"This is the reduce the original price of : {originalPrice}\nTo a price of : ${reducedPrice}");
            XmlAccountFactoryGenerator xmlGen = new XmlAccountFactoryGenerator();
            xmlGen.Create();
            Console.WriteLine();
            XmlMsExample xmlExample = new XmlMsExample("second.xml");
            //xmlExample.FileName = "first.xml";
            XDocument xDoc = xmlExample.MsCreate();
            xmlExample.Save(xDoc);
            xmlExample.MsRead();
            Console.WriteLine();
        }
    }

            /* 
            var builder = new ContainerBuilder();
             builder.RegisterType<DictionarableAccountDiscountCalculatorFactory>().As<IAccountDiscountCalculatorFactory>()
            .WithParameter("discountsDictionary", discountsDictionary)
            .SingleInstance();
            */

}
