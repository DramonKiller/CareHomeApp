using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Dramonkiller.CareHomeApp.WebClient.Extensions
{
    public class AttributeExtensions
    {
        public static string GetDisplayName<T>(string propertyName)
        {
            PropertyInfo propertyInfo =  typeof(T).GetProperties().FirstOrDefault(p => p.Name == propertyName);
            
            if (propertyInfo != null)
            {
                DisplayAttribute attribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
                
                if (attribute != null)
                {
                    return attribute.GetName();
                } 
            }

            return propertyName; 
        }
    }
}