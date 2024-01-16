using AutoMapper;
using colevn.study.Contact;
using DNH.Infrastructure.Utility.AutoMap;
using DNHCore.Model;
using System;

namespace colevn.study.Contact
{
    public  class DNHDataLogViewModel
    {
        public Int64 id { get; set; }
        public string sqlscript { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
    public class DNHDataLogViewModelMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<DNHDataLog, DNHDataLogViewModel>();
            var viewmap = configuration.CreateMap<DNHDataLogViewModel, DNHDataLog>();
        }
    }
}
