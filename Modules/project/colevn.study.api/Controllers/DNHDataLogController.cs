using colevn.study.business.Filter;
using colevn.study.business.Services;
using DNH.Infrastructure.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace colevn.study.api.Controllers
{
    public  class DNHDataLogController : ControllerBase
    {
        IDNHDataLogServices _DataLogServices;
        public DNHDataLogController(IDNHDataLogServices dNHDataLogServices) 
        {
            _DataLogServices=dNHDataLogServices;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Int64 id)
        {
            

            var data = await _DataLogServices.getById(id);
            PageResultV1 resultData = new PageResultV1(data);
            return Ok(resultData);
        }
    }
}
