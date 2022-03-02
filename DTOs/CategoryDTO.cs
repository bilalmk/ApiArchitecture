using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIArchitecture.DTOs
{
    public class CategoryDTOs
    {
        public record CategoryDTO(UInt32 ID,string Name,string Description,int TypeID,int Status,DateTimeOffset CreatedDateTime,DateTimeOffset UpdatedDateTime);
    }
}
