using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Utils.Commands.ImgToDataUri
{
    public class ImgToDataUriCommand : IRequest<string>
    {
        public string ImageFilename { get; set; }
    }
    public class ImgToDataUriCommandHandler : IRequestHandler<ImgToDataUriCommand, string>
    {
        public readonly string _imageFolderPath;

        public ImgToDataUriCommandHandler(IConfiguration configuration)
        {
            _imageFolderPath = configuration["ImagesFolder"];
        }

        public async Task<string> Handle(ImgToDataUriCommand request, CancellationToken cancellationToken)
        {
            string imgPath = Path.Combine(_imageFolderPath, request.ImageFilename);
            string imgDataUri = "";
            if (File.Exists(imgPath))
            {
                imgDataUri = "data:image/"
                            + Path.GetExtension(request.ImageFilename).Replace(".", "")
                            + ";base64,"
                            + Convert.ToBase64String(System.IO.File.ReadAllBytes(imgPath));
            }
            return await Task.FromResult(imgDataUri);
        }
    }
}
