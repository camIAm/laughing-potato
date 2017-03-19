using System.Xml.Serialization;
using System.Xml;

namespace BadPractices
{
    public enum AccountStatus
    {
        [XmlEnum("NR")]
        NotRegistered,
        SimpleCustomer,
        ValuableCustomer,
        MostValuableCustomer,
    }
}