using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSG_DTO.Converter
{
    //T stands for the domainModel. TD stands for the domainModel as DTO.
    public abstract class AbstractDTOConverter<T, TD>
    {
        public IEnumerable<TD> Convert(IEnumerable<T> toConvert)
        {
            List<TD> convertedObjects = new List<TD>();
            foreach (var item in toConvert)
            {
                convertedObjects.Add(ConvertModel(item));
            }
            return convertedObjects;
        }

        public abstract TD ConvertModel(T item);

        public IEnumerable<T> ConvertToDomainModel(IEnumerable<TD> toConvert)
        {
            List<T> convertedObjects = new List<T>();
            foreach (var item in toConvert)
            {
                convertedObjects.Add(ConvertDTO(item));
            }
            return convertedObjects;
        }

        public abstract T ConvertDTO(TD item);
    }

    
}
