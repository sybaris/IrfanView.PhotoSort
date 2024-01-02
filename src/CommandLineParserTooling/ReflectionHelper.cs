using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sybaris.IrfanView.Extensions.PhotoSort.CommandLineParserTooling
{
    public static class ReflectionHelper
    {
        public static string PublicPropertiesToString(object obj)
        {
            string result = "";
            // Get the type of the object
            Type type = obj.GetType();

            // Get all the public properties of the object
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Display the name and value of each public property
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj, null);
                if (property.Name.ToLower() == "password")
                    result += "  - " + property.Name + " = **************" + Environment.NewLine;
                else
                    result += "  - " + property.Name + " = " + value + Environment.NewLine;
            }
            return result;
        }

    }
}
