using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstracts;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using Service.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryRules _categoryrules;

    public CategoryService(ICategoryRepository categoryRepository, CategoryRules categoryrules)
    {
        _categoryRepository = categoryRepository;
        _categoryrules = categoryrules;
    }

    public Response<CategoryResponseDto> Add(CategoryAddRequest categoryAddRequest)
    {
        try
        {
            Category category = categoryAddRequest;

            _categoryrules.CategoryNameMustBeUnique(category.Name);

            _categoryRepository.Add(category);

            CategoryResponseDto response = category;

            return new Response<CategoryResponseDto>
            {
                Data = response,
                Message = "Kategori Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (BusinessException ex)
        {
            return new Response<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }

    public Response<CategoryResponseDto> Delete(int id)
    {
        try
        {
            _categoryrules.CategoryIsPresent(id);
            Category category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);

            CategoryResponseDto categoryResponseDto = category;

            return new Response<CategoryResponseDto>
            {
                Data = categoryResponseDto,
                Message = "Kategori silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }

    public Response<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();

        List<CategoryResponseDto> response = categories.Select(x => (CategoryResponseDto)x).ToList();

        return new Response<List<CategoryResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> GetById(int id)
    {
        try
        {
            _categoryrules.CategoryIsPresent(id);
            Category? category = _categoryRepository.GetById(id);

            CategoryResponseDto response = category;

            return new Response<CategoryResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest

            };
        }
        

    }

    public Response<CategoryResponseDto> Update(CategoryUpdateRequest categoryUpdateRequest)
    {
        try
        {
            Category category = categoryUpdateRequest;
            _categoryrules.CategoryNameMustBeUnique(category.Name);

            _categoryRepository.Update(category);

            CategoryResponseDto categoryResponseDto = category;

            return new Response<CategoryResponseDto>()
            {
                Data = categoryResponseDto,
                Message = "Kategori guncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
        
    }
}
