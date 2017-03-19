using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace BadPractices
{
    public class Foo
    {
        public AccountStatus AccountStatus;
    }
    public class EnumSerialization
    {
        public static void SerializeEnum()
        {
            using (var writer = XmlWriter.Create(Console.OpenStandardOutput()))
        {
            var foo = new Foo
            {
                AccountStatus = AccountStatus.NotRegistered
            };
            Xml serializer = new XmlSerializer(foo.GetType());
            serializer.Serialize(writer, foo);
        }
        }
    }
}