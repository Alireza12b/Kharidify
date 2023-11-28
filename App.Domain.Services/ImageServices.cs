using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IImageRepository _imageRepository;

        public ImageServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Task<List<ImageOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return _imageRepository.GetAll(cancellationToken);
        }

        public Task<ImageOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            return _imageRepository.GetById(id, cancellationToken);
        }
    }
}
