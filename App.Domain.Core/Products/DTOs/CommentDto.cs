using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class CommentInputDto
    {
        public string Message { get; set; } = null!;

        public bool isActive { get; set; }

        public bool IsRemoved { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
    }

    public class CommentOutputDto
    {
        public int Id { get; set; }

        public string Message { get; set; } = null!;

        public bool isActive { get; set; }

        public bool IsRemoved { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }
    }
}
