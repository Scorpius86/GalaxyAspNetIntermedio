using Galaxy.Taller.Api.Data.Repository;
using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public class BrandApplicationService : IBrandApplicationService
    {
        public IBrandRepository  _brandRepository { get; set; }
        public BrandApplicationService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public List<BrandDto> GetBrands()
        {
            return _brandRepository.GetBrands();
        }
        public BrandDto GetBrand(int brandId)
        {
            return _brandRepository.GetBrand(brandId);
        }
    }
}
