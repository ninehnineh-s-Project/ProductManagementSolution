using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Data;
using BusinessObject.Entity;
using Repositories;
using DataAccess.DTOs.Product;
using AutoMapper;
using DataAccess.DTOs.Product.Validator;
using FluentValidation.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RazorPage.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductDto> _validator;

        public CreateModel(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IValidator<CreateProductDto> validator)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> OnGet()
        {
            var selectListItems = await _categoryRepository.GetAll();
            ViewData["CategoryId"] = new SelectList(selectListItems, "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public CreateProductDto Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var validator = new CreateProductDtoValidator(_categoryRepository);
                var validationResult = await validator.ValidateAsync(Product);

                if (validationResult.IsValid == false)
                {
                    validationResult.AddToModelState(ModelState);
                    await OnGet();
                    return Page();
                    
                }
                else
                {
                    var product = _mapper.Map<Product>(Product);
                    await _productRepository.Add(product);
                }
            }
            
            return RedirectToPage("./Index");
        }
    }

}
