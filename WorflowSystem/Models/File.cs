using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        public List<IFormFile> ListFiles { get; set; }
    }
}
