using colevn.study.business.Filter;
using colevn.study.business.Services;
using colevn.study.Contact;
using DNH.Infrastructure.Database;
using DNH.Infrastructure.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace colevn.study.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DNHDataLogController : ControllerBase
    {
        IDNHDataLogServices _DataLogServices;
        public DNHDataLogController(IDNHDataLogServices dNHDataLogServices)
        {
            _DataLogServices = dNHDataLogServices;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Int64 id)
        {


            var data = await _DataLogServices.getById(id);
            PageResultV1 resultData = new PageResultV1(data);
            return Ok(resultData);
        }
        [HttpPost()]
        public virtual async Task<IActionResult> Post([FromBody] DNHDataLog model)
        {
            PageResultV1 resultData = new PageResultV1("Ok");
            return Ok(resultData);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] DNHDataLog model)
        {
            PageResultV1 resultData = new PageResultV1("Ok");
            return Ok(resultData);
        }
        
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> delete(Int64 id)
        {
            PageResultV1 resultData = new PageResultV1("Ok");
            return Ok(resultData);
        }
        [HttpGet("paging")]
        public virtual async Task<IActionResult> Paging(string filter = "")
        {
            PageResultV1 resultData = new PageResultV1();
            try
            {
                GetFilterRequest request = new GetFilterRequest(Guid.Empty);
                if (!string.IsNullOrEmpty(filter) && filter != "{}")
                {
                    request = JsonConvert.DeserializeObject<GetFilterRequest>(filter);
                }
                FilterRequest input = new FilterRequest(request);
                var result = await _DataLogServices.GetTable().GetpagingAysnc(input);
                resultData = PageResultV1.ParseData(result.Items);
                resultData.data.meta.totalItem = result.TotalCount;
                resultData.data.meta.paginationOptionsDto.page = request.pagination.page;
                resultData.data.meta.paginationOptionsDto.limit = request.pagination.limit;
                resultData.code = 200;
            }
            catch (Exception ex)
            {
                resultData.code = 400;
                resultData.status = $"Error{ex.Message}";
            }
            return Ok(resultData);

        }
    }
}
