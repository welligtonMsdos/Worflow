using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Worflow.Models;

public class Arquivo
{
   public List<IFormFile> listFiles { get; set; }

}
