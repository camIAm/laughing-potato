using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace BadPractices
{
    public class XmlMsExample
    {
        /* 
        public bool DoesFileNameExist{get;set;} = false;
        public string FileName
        {
            get{return FileName;}
            set{
                if(value!=null)
                    {
                    DoesFileNameExist = true;
                    FileName = value;
                    }
               }
        }
        */
        public string FileName{get;set;}
        public string FullPath{get;set;}
        public XmlMsExample(string fileName)
        {
            FileName = fileName;
            FullPath = CreateFilePath(FileName);
        }
        /* 
        public string CreateFilePath()  
        {
            if(!DoesFileNameExist)
            {
                throw new NotImplementedException("No filename given");
            }
            return CreateFilePath(FileName);
        }
        */
        public string CreateFilePath(string fileName)
        {
            string path1 = Directory.GetCurrentDirectory();
            string fullName = Path.Combine(path1,fileName);
            Console.WriteLine($"The full path {fullName}");
            return fullName;
        }
        Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>> discountsDictionary = new Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>>
            {
                {AccountStatus.NotRegistered,new Lazy<IAccountDiscountCalculator>(()=> new NotRegisteredDiscountCalculator())},
                {AccountStatus.SimpleCustomer, new Lazy<IAccountDiscountCalculator>(()=> new SimpleCustomerDiscountCalculator())},
                {AccountStatus.ValuableCustomer, new Lazy<IAccountDiscountCalculator>(()=> new ValuableCustomerDiscountCalculator())},
                {AccountStatus.MostValuableCustomer, new Lazy<IAccountDiscountCalculator>(()=> new MostValuableCustomerDiscountCalculator())},
            };
        public XDocument MsCreate()
        {
        XDocument srcTree = new XDocument(
            new XComment("These are the dictionary values"),
                new XElement("factoryConfiguration",
                    new XElement("Child1", "data1"),
                    new XElement("Child2", "data2"),
                    new XElement("Child3", "data3"),
                    new XElement("Child2", "data4"),
                    new XElement("Info5", "info5"),
                    new XElement("Info6", "info6"),
                    new XElement("Info7", "info7"),
                    new XElement("Info8", "info8")
                )
                    );
            return srcTree;
        //string fullName = CreateFilePath(FileName);
        }
        public void Save(XDocument srcTree)
        {
            using(Stream sm = new FileStream(FullPath, FileMode.Create))
            {
                srcTree.Save(sm, SaveOptions.None);
            }
        }
        public void MsRead()
        {
            XDocument xmlDocTemplate = XDocument.Load(FullPath);
            XDocument doc = new XDocument(    
                new XComment("This is a comment"),
                new XElement("Root",
                    from el in xmlDocTemplate.Element("Root").Elements()
                    where ((string)el).StartsWith("data")
                    select el
                        )
                    );
               Console.WriteLine(doc);
        
        }
    }
}