using AutoMapper;
using Farmfresh.Models;

namespace Farmfresh.Mapper
{
    public class DataMapper : Profile
    {
        public DataMapper() {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, Repositories.Entities.Category>();
            CreateMap<Repositories.Entities.Category, Category>();
            CreateMap<Product, Repositories.Entities.Product>()
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => MapFormFile(s)));
            CreateMap<Repositories.Entities.Product, Product>()
                .ForMember(d => d.Photo, opt => opt.Ignore())
                .ForMember(d => d.PhotoUrl, opt => opt.MapFrom(s => MapToForm(s)));
        }

        private byte[] MapFormFile(Product product)
        {
            using (var stream = new MemoryStream())
            {
                product.Photo.CopyTo(stream);
                return stream.ToArray();
            }
        }

        private string MapToForm(Repositories.Entities.Product product)
        {
            if (product.Photo == null)
                return string.Empty;

            string base64String = Convert.ToBase64String(product.Photo);
            return $"data:image/png;base64,{base64String}";
        }
    }
}
