using Core.Persistence.EntityBaseModel;
using Models.Dtos.RequestDto;

namespace Models.Entities;

public class Category : Entity<int>
{
    
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }

    public static implicit operator Category(CategoryAddRequest categoryAddRequest) =>
        new Category 
        { 
            Name = categoryAddRequest.Name 

        };

    public static implicit operator Category(CategoryUpdateRequest categoryUpdateRequest)=>
        new Category { 
            Id = categoryUpdateRequest.Id,
            Name = categoryUpdateRequest.Name 
        };
}
