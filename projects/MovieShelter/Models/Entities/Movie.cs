using Core.Persistence.EntityBaseModel;
using Models.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Movie : Entity<Guid>
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseDate { get; set; }
    public int CategoryId { get; set; }
    public int PublisherId { get; set; }
    public Category Category { get; set; }
    public Publisher Publisher { get; set; }

    public static implicit operator Movie(MovieAddRequest movieAddRequest) =>
        new Movie { 
            Title = movieAddRequest.Title, 
            Director = movieAddRequest.Director, 
            ReleaseDate = movieAddRequest.ReleaseDate, 
            CategoryId = movieAddRequest.CategoryId,
            PublisherId = movieAddRequest.PubliherId
        };

    public static implicit operator Movie(MovieUpdateRequest movieUpdateRequest) =>
        new Movie
        {
            Id = movieUpdateRequest.Id,
            Title = movieUpdateRequest.Title,
            Director = movieUpdateRequest.Director,
            ReleaseDate = movieUpdateRequest.ReleaseDate,
            CategoryId = movieUpdateRequest.CategoryId,
            PublisherId = movieUpdateRequest.PublisherId
        };


}
