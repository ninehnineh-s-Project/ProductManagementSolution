using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Data;
using BusinessObject.Entity;
using DataAccess.DTOs.Product;
using Repositories;
using AutoMapper;
using DataAccess.DTOs.Product.Validator;

namespace RazorPage.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteModel(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var product = await _productRepository.Get(id);
            Product = _mapper.Map<ProductDto>(product);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Product = product;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var product = await _productRepository.Get(id);
            var validator = new DeleteProductDtoValidator();
            var validationResult = await validator.ValidateAsync(Product);

            if (validationResult.IsValid == false)
            {
                validationResult.AddToModelState(ModelState);
                return Page();
            }

            await _productRepository.Delete(product);

            return RedirectToPage("./Index");
        }
    }
}
