using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class ManagerFile : IManagerFile
    {
        public async Task<byte[]> GetFile(IFormFile fromFile)
        {
            var fileBytes = new byte[266240];
            using (var stream = new MemoryStream())
            {
                await fromFile.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }
            return fileBytes;
        }
    }
}
