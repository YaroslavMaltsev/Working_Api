﻿using Microsoft.AspNetCore.Http;
using Working_Api.Services.Interface;

namespace Working_Api.Services.Implementation
{
    public class ManagerFile : IManagerFile
    {
        public async Task<byte[]> SaveFile(IFormFile fromFile)
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
