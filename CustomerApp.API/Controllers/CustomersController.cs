using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using CustomerApp.Entities.Dtos.CustomerDtos;
using CustomerApp.Shared.Entities.Concrete;
using CustomerApp.Shared.Utilities.Results.ComplexTypes;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApp.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> Add(CustomerAddDto customerAddDto)
        {
            var addResult = await _customerService.AddAsync(customerAddDto);
            switch (addResult.ResultStatus)//ResultStatus
            {
                case ResultStatus.Warning:
                    return BadRequest(new ApiResult
                    {
                        ResultStatus = addResult.ResultStatus,
                        Data = addResult.Data,
                        Detail = addResult.Message,
                        Message = addResult.Message, 
                        ValidationErrors = addResult.ValidationErrors,
                        StatusCode = HttpStatusCode.BadRequest,
                    });
                default: //ResultStatus.Success
                    return Ok(new ApiResult
                    {
                        ResultStatus = addResult.ResultStatus,
                        Data = addResult.Data,
                        Message = addResult.Message,
                        Detail = addResult.Message,
                        ValidationErrors = addResult.ValidationErrors,
                        StatusCode = HttpStatusCode.OK
                    });
            }
        }



        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            var updateResult = await _customerService.UpdateAsync(customerUpdateDto);
            switch (updateResult.ResultStatus)//ResultStatus
            {
                case ResultStatus.Warning:
                    return BadRequest(new ApiResult
                    {
                        ResultStatus = updateResult.ResultStatus,
                        Data = updateResult.Data,
                        Detail = updateResult.Message,
                        Message = updateResult.Message,
                        ValidationErrors = updateResult.ValidationErrors,
                        StatusCode = HttpStatusCode.BadRequest,
                    });
                default: //ResultStatus.Success
                    return Ok(new ApiResult
                    {
                        ResultStatus = updateResult.ResultStatus,
                        Data = updateResult.Data,
                        Message = updateResult.Message,
                        Detail = updateResult.Message,
                        ValidationErrors = updateResult.ValidationErrors,
                        StatusCode = HttpStatusCode.OK
                    });
            }
        }



        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _customerService.DeleteAsync(id);
            switch (deleteResult.ResultStatus)//ResultStatus
            {
                case ResultStatus.Warning:
                    return BadRequest(new ApiResult
                    {
                        ResultStatus = deleteResult.ResultStatus,
                        Data = null,
                        Detail = deleteResult.Message,
                        Message = deleteResult.Message,
                        
                        ValidationErrors = deleteResult.ValidationErrors,
                        StatusCode = HttpStatusCode.BadRequest,
                    });
                default: //ResultStatus.Success
                    return Ok(new ApiResult
                    {
                        ResultStatus = deleteResult.ResultStatus,
                        Data = null,
                        Message = deleteResult.Message,
                        Detail = deleteResult.Message,
                        ValidationErrors = deleteResult.ValidationErrors,
                        StatusCode = HttpStatusCode.OK
                    });
            }
        }



        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
      
        public async Task<IActionResult> GetAll()
        {
            var customerResult = await _customerService.GetAllAsync();
            switch (customerResult.ResultStatus)
            {
                case ResultStatus.Warning:
                    return BadRequest(new ApiResult
                    {
                        ResultStatus = customerResult.ResultStatus,
                        Data = customerResult.Data,
                        Detail = customerResult.Message,
                        Message = customerResult.Message,
                        ValidationErrors = customerResult.ValidationErrors,
                        StatusCode = HttpStatusCode.BadRequest,
                    });
                default: //ResultStatus.Success
                    return Ok(new ApiResult
                    {
                        ResultStatus = customerResult.ResultStatus,
                        Data = customerResult.Data,
                        Message = customerResult.Message,
                        Detail = customerResult.Message,
                        ValidationErrors = customerResult.ValidationErrors,
                        StatusCode = HttpStatusCode.OK
                    });
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdResult = await _customerService.GetCustomerById(id);
            switch (getByIdResult.ResultStatus)
            {
                case ResultStatus.Warning:
                    return BadRequest(new ApiResult
                    {
                        ResultStatus = getByIdResult.ResultStatus,
                        Data = getByIdResult.Data,
                        Detail = getByIdResult.Message,
                        Message = getByIdResult.Message,

                        ValidationErrors = getByIdResult.ValidationErrors,
                        StatusCode = HttpStatusCode.BadRequest,
                    });
                default: 
                    return Ok(new ApiResult
                    {
                        ResultStatus = getByIdResult.ResultStatus,
                        Data = getByIdResult.Data,
                        Message = getByIdResult.Message,
                        Detail = getByIdResult.Message,
                        ValidationErrors = getByIdResult.ValidationErrors,
                        StatusCode = HttpStatusCode.OK
                    });
            }
        }


    }
}
