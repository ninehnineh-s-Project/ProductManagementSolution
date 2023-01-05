using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Entity;
using Repositories;
using AutoMapper;
using DataAccess.DTOs.Product.Validator;
using DataAccess.DTOs.Product;

namespace RazorPage.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EditModel(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public UpdateProductDto Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product =  await _productRepository.Get(id);
            Product = _mapper.Map<UpdateProductDto>(product);
            var selectListItems = await _categoryRepository.GetAll();
            ViewData["CategoryId"] = new SelectList(selectListItems, "Id", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var validator = new UpdateProductDtoValidator(_categoryRepository);
                var validationResult = await validator.ValidateAsync(Product);

                if (validationResult.IsValid == false)
                {
                    validationResult.AddToModelState(ModelState);
                    await OnGetAsync(id);
                    return Page();
                }
                else
                {
                    var product = _mapper.Map<Product>(Product);
                    await _productRepository.Update(product);
                }
            }


            return RedirectToPage("./Index");
        }
    }
}
