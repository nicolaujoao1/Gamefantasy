using GameFantasy.Application.DTOs;
using GameFantasy.Application.Interfaces;
using GameFantasy.Application.Services;
using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFantasy.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var timesEntity = await _timeService.GetAsync();
            return Ok(timesEntity);
        }
        //[HttpGet]
        //public  IActionResult GetAll([FromQuery] TimeParameters timeParameters)
        //{
        //    var timesEntity = _timeService.GetAll(timeParameters).Item1;
        //    var timePaging = _timeService.GetAll(timeParameters).Item2;
        //    var metadata = new
        //    {
        //        timePaging.TotalCount,
        //        timePaging.PageSize,
        //        timePaging.CurrentPage,
        //        timePaging.TotalPages,
        //        timePaging.HasNext,
        //        timePaging.HasPrevious
        //    };

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        //    return Ok(timesEntity);
        //}
        [HttpGet("{id}", Name = "GetTime")]
        public async Task<IActionResult> Get(int id)
        {
            var time = await _timeService.GetByIdAsync(id);

            if (time == null)
            {
                return NotFound();
            }
            return Ok(time);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TimeDTO timeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _timeService.ExistTimeAsync(timeDTO))
                return BadRequest($"{nameof(Time)} já existente");

            var time = await _timeService.CreateAsync(timeDTO);
            
            return new CreatedAtRouteResult("GetTime",
                new { id = timeDTO.Id }, timeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TimeUpdateDTO timeDTO)
        {
            if (id != timeDTO.Id)
            {
                return BadRequest();
            }
            var time = await _timeService.UpdateAsync(timeDTO);
            return Ok(time);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var timeDto = await _timeService.GetByIdAsync(id);
            if (timeDto == null)
            {
                return NotFound();
            }
            await _timeService.RemoveAsync(id);
            return Ok(timeDto);
        }
    }
}
