using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class NotificationController : ControllerBase
    {
        private INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NotificationInput _notification)
        {
            try
            {
                return Ok(await _service.Save(_notification));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Erro interno!", Status = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody] NotificationInput _notification)
        {
            try
            {
                return Ok(await _service.Put(_notification));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Erro interno!", Status = false });
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Erro interno!", Status = false });
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByFilter([FromQuery] NotificationFilter _filter)
        {
            try
            {
                return Ok(await _service.GetByFilter(_filter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await _service.GetList());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }
        
    }
}
