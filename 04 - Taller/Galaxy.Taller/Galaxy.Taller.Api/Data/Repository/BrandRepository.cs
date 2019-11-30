using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Data.Repository
{
    public class BrandRepository : IBrandRepository
    {
        public GalaxyTallerContext _galaxyTallerContext { get; set; }
        public BrandRepository(GalaxyTallerContext galaxyTallerContext)
        {
            _galaxyTallerContext = galaxyTallerContext;
        }

        private IQueryable<BrandDto> QueryGetBrand(int brandId=0)
        {
            var query = from b in _galaxyTallerContext.Marca
                        select new BrandDto
                        {
                            BrandId = b.MarcaId,
                            Description = b.Descripcion
                        };

            if (brandId != 0)
            {
                query = query.Where(w => w.BrandId == brandId);
            }

            return query;
        }
        public List<BrandDto> GetBrands()
        {
            List<BrandDto> result = QueryGetBrand().ToList();
            return result;
        }
        public BrandDto GetBrand(int brandId)
        {
            BrandDto result = QueryGetBrand(brandId).FirstOrDefault();
            return result;
        }
    }
}
