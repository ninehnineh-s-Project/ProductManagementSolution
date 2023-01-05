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

namespace RazorPage.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DetailsModel(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var product = await _productRepository.Get(id);
            Product = _mapper.Map<ProductDto>(product);
            //Product = product;
            return Page();
        }
    }
}
