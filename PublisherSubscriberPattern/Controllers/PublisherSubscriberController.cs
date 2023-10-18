using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace PublisherSubscriberPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PublisherSubscriberController : ControllerBase
    {
        IPublisherSubscriberManager _publisherSubscriberManager;

        public PublisherSubscriberController(IPublisherSubscriberManager publisherSubscriberManager)
        {
            _publisherSubscriberManager = publisherSubscriberManager;
        }

        /// <summary>
        /// �������� �������� ��� �������� �����������
        /// </summary>
        /// <param name="key">���������� ����</param>
        /// <param name="value">��������</param>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void AddValue(string key, string value)
        {
            _publisherSubscriberManager.AddValue(key, value);
        }

        /// <summary>
        /// ����������� �� ��������� ��������
        /// </summary>
        /// <param name="key">���������� ����</param>
        /// <param name="millisecondsWait">����� �������� � ms</param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WaitForValueResponse))]
        public async Task<IActionResult> WaitForValueAsync(string key, int millisecondsWait)
        {
            var result = await _publisherSubscriberManager.WaitForValueAsync(key, millisecondsWait);

            return new JsonResult(result);
        }
    }
}