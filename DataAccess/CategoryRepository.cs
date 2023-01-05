using AutoMapper;
using BusinessObject.Entity;
using DAOs;
using DataAccess.DTOs.Category;
using DataAccess.DTOs.Category.Validators;
using FluentValidation;
using Repositories;

namespace DataAccess
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        //public async Task<IEnumerable<Category>> GetCategories()
        //{
        //    return await CategoryDAO.Instance.GetCategories();
        //}
    }
}
