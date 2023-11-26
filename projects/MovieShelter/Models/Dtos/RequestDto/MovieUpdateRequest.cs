using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDto
{
    public record MovieUpdateRequest(Guid Id, string Title, string Director, int ReleaseDate, int CategoryId,int PublisherId)
    {

    }
}
