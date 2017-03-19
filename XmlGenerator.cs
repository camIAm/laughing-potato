using System;
using System.ComponentModel;
using System.Xml.Linq;
using System.IO;

namespace BadPractices
{
    public class XmlAccountFactoryGenerator
    {
       // System.IO.Stream file = new Stream("foo.xml");
        public void Create()
        {
        new XDocument(
            new XElement("root", 
                new XElement("someNode", "someValue")    
                        )
                    )
        .Save(Console.Out);
        }
    }
}