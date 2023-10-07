using ProductService.DTOs;
using ProductService.Exceptions;
using ProductService.Models;
using ProductService.Repositories;
using ProductService.ThirdPartyClients.FakeStore;

namespace ProductService.Services
{
    public class ProductService:IProductService
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private PriceRepository _priceRepository;

        public ProductService(ProductRepository productRepository,CategoryRepository categoryRepository,PriceRepository priceRepository)
        {
            _productRepository = productRepository;
            _categoryRepository=categoryRepository;
            _priceRepository=priceRepository;
        }

        public async Task<GenericProductDto> getProductById(string id)
        {
            var product=_productRepository.GetById(Guid.Parse(id));
            if (product == null)
            {
                throw new NotFoundException("Product with id: " + id + " doesn't exist.");
            }

            product.category = _categoryRepository.GetById(product.CategoryId);
            product.price = _priceRepository.GetById(product.priceId);
            return MapToGenericProductDto(product);
        }


        private GenericProductDto MapToGenericProductDto(Product? product)
        {
            return new GenericProductDto()
            {
                id = product.Id.ToString(),
                title = product.title,
                price = product.price?.price,
                description = product.description,
                image = product.image,
                category = product.category?.name
            };
        }

        public async Task<GenericProductDto> createProduct(GenericProductDto product)
        {

            Category category = _categoryRepository.getByName(product.category);
            if (category == null)
            {
                category = new Category
                {
                    name = product.category
                };
                _categoryRepository.Add(category);
            }

            Price price = _priceRepository.getByPrice(product.price);
            if (price == null)
            {
                price = new Price
                {
                    price = (double)product.price,
                    currency = "USD"
                };
                _priceRepository.Add(price);
            }

            Product prod = new Product()
            {
                title = product.title,
                description = product.description,
                image = product.image,
                price = price,
                category = category
            };
            var createdProduct = _productRepository.Add(prod);
            _productRepository.Save();
            return MapToGenericProductDto(createdProduct);
        }

        public async Task<List<GenericProductDto>> getAllProducts()
        {
            List<Product> products= _productRepository.GetAll().ToList();
            List<GenericProductDto> genericProducts= new List<GenericProductDto>();
            products.ForEach(product =>
            {
                product.category = _categoryRepository.GetById(product.CategoryId);
                product.price = _priceRepository.GetById(product.priceId);
                GenericProductDto genericproduct = MapToGenericProductDto(product);
                genericProducts.Add(genericproduct);
            });
            return genericProducts;
        }

        public async Task<GenericProductDto> deleteProduct(string id)
        {
            var product = _productRepository.GetById(Guid.Parse(id));
            if (product == null)
            {
                throw new NotFoundException("Product with id: " + id + " doesn't exist.");
            }

            var deletedProduct= _productRepository.Delete(product);
            _productRepository.Save();
            return MapToGenericProductDto(deletedProduct);
        }

        public async Task<GenericProductDto> updateProduct(string id, GenericProductDto product)
        {
            Product existingProduct=_productRepository.GetById(Guid.Parse(id));
            if (existingProduct == null)
            {
                throw new NotFoundException("Product with id: " + id + " doesn't exist.");
            }
            existingProduct.title=product.title;
            existingProduct.description=product.description;
            existingProduct.image=product.image;


            Category category = _categoryRepository.getByName(product.category);
            if (category == null)
            {
                category = new Category
                {
                    name = product.category
                };
                _categoryRepository.Add(category);
            }

            Price price = _priceRepository.getByPrice(product.price);
            if (price == null)
            {
                price = new Price
                {
                    price = (double)product.price,
                    currency = "USD"
                };
                _priceRepository.Add(price);
            }

            existingProduct.category = category;
            existingProduct.price = price;

            var updatedProduct = _productRepository.Update(existingProduct);
            _productRepository.Save();
            return MapToGenericProductDto(updatedProduct);
        }

        public List<string> getAllCategories()
        {
            return _categoryRepository.GetAll().Select(x=>x.name).Distinct().ToList();
        }

        
        public List<GenericProductDto> getProductByCategoryName(string categoryName)
        {
            Category category = _categoryRepository.getByName(categoryName);
            List<Product> products = _productRepository.GetAll().Where(p=>p.CategoryId==category.Id).ToList();
            List<GenericProductDto> genericProducts = new List<GenericProductDto>();
            products.ForEach(product =>
            {
                product.category = category;
                product.price = _priceRepository.GetById(product.priceId);
                GenericProductDto genericproduct = MapToGenericProductDto(product);
                genericProducts.Add(genericproduct);
            });
            return genericProducts;
        }
    }
}
