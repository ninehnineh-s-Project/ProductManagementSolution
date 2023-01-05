using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Data;
using BusinessObject.Entity;
using Repositories;
using DataAccess.DTOs.Product;
using AutoMapper;

namespace RazorPage.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public IndexModel(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IList<ProductDto> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var product = await _productRepository.GetAll();
            Product = _mapper.Map<IList<ProductDto>>(product);
        }
    }
}
