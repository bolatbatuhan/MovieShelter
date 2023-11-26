using Core.Persistence.EntityBaseModel;
using Models.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Publisher : Entity<int>
{
    public string Name { get; set; }

    List<Movie> Movies;



    public static implicit operator Publisher(PublisherAddRequest publisherAddRequest) =>
        new Publisher
        {
           Name = publisherAddRequest.Name,
        };

    public static implicit operator Publisher(PublisherUpdateRequest publisherUpdateRequest) =>
        new Publisher 
        { 
        Id = publisherUpdateRequest.Id,
        Name = publisherUpdateRequest.Name,
        };
    
}

