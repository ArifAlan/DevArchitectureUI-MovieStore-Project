using Business.Constants;
using Business.Handlers.MovieImages.Command;
using Core.Utilities.Helpers.FileHelper.Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController : BaseApiController
    {
        IFileHelper _fileHelper;
        public MovieImagesController(IFileHelper fileHelper)
        {

            _fileHelper = fileHelper;
        }

       
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateMovieImageCommand createMovieImage, [FromForm] IFormFile file)
        {
           createMovieImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            return GetResponseOnlyResultMessage(await Mediator.Send(createMovieImage));
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovieImageCommand updateMovieImage)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateMovieImage));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMovieImageCommand deleteMovieImage)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteMovieImage));
        }
    }
}
