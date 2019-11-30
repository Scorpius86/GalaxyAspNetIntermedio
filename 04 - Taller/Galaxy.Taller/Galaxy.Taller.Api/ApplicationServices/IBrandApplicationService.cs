using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public interface IBrandApplicationService
    {
        BrandDto GetBrand(int brandId);
        List<BrandDto> GetBrands();
    }
}