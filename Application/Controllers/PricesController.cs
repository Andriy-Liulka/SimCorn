using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using AutoMapper;
using Application.Config.dto;
using DomainModel;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly ILogger<PricesController> _logger;
        private readonly AccountServices _service;
        private readonly IMapper _mapper;

        public PricesController(ILogger<PricesController> logger, IMapper mapper)
        {
            _logger = logger;
            _service = new AccountServices(new ApplicationContext());
            _mapper = mapper;
        }

        [HttpGet(nameof(Average))]
        public IActionResult Average([FromQuery] GetAccountDto dtoModel)
        {
            var localAccount = _mapper.Map<Account>(dtoModel);

            decimal totalPrice=_service.GetAveragePrice(localAccount);
            if (totalPrice==-1)
            {
                return BadRequest("Error with input data");
            }
            return Ok($"Total price is {totalPrice}");

        }
        
    }
}
