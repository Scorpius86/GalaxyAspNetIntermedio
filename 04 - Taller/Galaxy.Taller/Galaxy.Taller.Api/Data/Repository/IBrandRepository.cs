using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.Data.Repository
{
    public interface IBrandRepository
    {
        BrandDto GetBrand(int brandId);
        List<BrandDto> GetBrands();
    }
}