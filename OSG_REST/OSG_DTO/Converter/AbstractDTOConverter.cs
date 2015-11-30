using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSG_DTO.Converter
{
    //T stands for the domainModel as DTO. TD stands for the domainModel
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
    }
}
