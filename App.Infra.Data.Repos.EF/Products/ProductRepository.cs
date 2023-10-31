using App.Infra.Data.SqlServer.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Products
{
    public class ProductRepository
    {
        private readonly KharidifyDbContext _db;

        public ProductRepository(KharidifyDbContext db)
        {
            _db = db;          
        }


    }
}
