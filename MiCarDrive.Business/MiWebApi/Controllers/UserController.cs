using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using MiWebApi.Aspects;
using MiWebApi.Helpers;
using Shared.Filters;
using Shared.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUsersService _userService;
        private readonly string _azureConnectionString;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("user/name/{name}")]
        public async Task<UserInfo> GetUserByNameAsync(string name)
        {
            var filter = new UserFilter { UserName = name };
            return (await _userService.GetUsersAsync(filter)).FirstOrDefault();
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("user/id")]
        public async Task<UserInfo> GetUserById()
        {
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            var filter = new UserFilter { UserId = new Guid(userId) };
            return (await _userService.GetUsersAsync(filter)).FirstOrDefault();
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("user")]
        public async Task<bool> UpdateUser([FromBody] UserInfo user)
        {
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return false;
            return await _userService.UpdateUserAsync(user);
        }

        private async Task<string> UploadImageToAzureBlob(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var container = new BlobContainerClient(_azureConnectionString, "micardriveimages");
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    {
                        await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                    }

                    var blob = container.GetBlobClient(file.FileName);
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }

                    return blob.Uri.ToString();
                }

            }
            catch
            {
            }

            return null;
        }
    }
}
