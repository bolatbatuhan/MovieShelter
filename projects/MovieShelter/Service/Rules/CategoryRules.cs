
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstracts;

namespace Service.Rules;
public class CategoryRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void CategoryNameMustBeUnique(string categoryName)
    {
        var category = _categoryRepository.GetByFilter(x=>x.Name==categoryName);
        if(category is not null)
        {
            throw new BusinessException("Kategori adi benzersiz olmalidir.");
        }
    }
    public void CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if(category is null)
        {
            throw new BusinessException($"Id {id} olana kategori bulunamadi.");
        }
    }
}
