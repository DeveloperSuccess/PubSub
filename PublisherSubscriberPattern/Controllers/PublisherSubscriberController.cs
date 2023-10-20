using Microsoft.AspNetCore.Mvc;
using PublisherSubscriberPattern.Models;
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
        public void AddValue([FromQuery] AddValueModel request)
        {
            _publisherSubscriberManager.AddValue(request.Key, request.Value);
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
        public async Task<IActionResult> WaitForValueAsync([FromQuery] WaitForValueAsyncModel request, CancellationToken cancellationToken)
        {
            var result = await _publisherSubscriberManager.WaitForValueAsync(request.Key, request.MillisecondsWait, cancellationToken);

            return new JsonResult(result);
        }
    }
}