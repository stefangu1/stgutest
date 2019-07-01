using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Name.BusinessAgreementArea;
            a.GetStringValue();
            Console.WriteLine(ExtenstionClass.GetStringValue(a));
            Console.WriteLine(ExtenstionClass.GetStringValue(Name.BusinessAgreementArea));
            Console.WriteLine(a.GetStringValue());
        }
    }
    public enum Name
    {
        [EnumStringAttribute("Basin")] Basin,
        [EnumStringAttribute("Block")] Block,
        [EnumStringAttribute("Business Agreement Area")] BusinessAgreementArea,
        [EnumStringAttribute("Country")] Country,
        [EnumStringAttribute("Continent")] Continent
    }
    public class EnumStringAttribute : Attribute
    {
        public EnumStringAttribute(string stringValue)
        {
            this.stringValue = stringValue;
        }
        private string stringValue;
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    public static class ExtenstionClass
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            // Get the stringvalue attributes  
            EnumStringAttribute[] attribs = fieldInfo.GetCustomAttributes(
                 typeof(EnumStringAttribute), false) as EnumStringAttribute[];
            // Return the first if there was a match.  
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }

        /// This  is used to get the Cutom Attribute.  
        /// </summary>  
        //private static void GetEnumCustomAttributeString()
        //{
        //    //This return the custom attribute string value.  
        //    Console.WriteLine(MicrosoftOfficeString.Excel.GetStringValue());
        //    Console.WriteLine(Environment.NewLine);
        //    string[] officenames = Enum.GetNames(typeof(MicrosoftOffice));
        //    foreach (string officename in officenames)
        //    {
        //        MicrosoftOfficeString ms = (MicrosoftOfficeString)Enum.Parse(typeof(MicrosoftOfficeString), officename);
        //        //This return the custom attribute string value.  
        //        Console.WriteLine(ms.GetStringValue());
        //    }
        //    Console.ReadKey();
        //}
    }
