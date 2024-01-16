using colevn.study.Contact;
using DNH.Infrastructure.Database.SQL;
using DNHCore.Model;

namespace colevn.study.business.Services
{
    

    using Microsoft.EntityFrameworkCore;

    public interface IDNHDataLogServices : IEfManager<DNHDataLog>
    {
        Task<DNHDataLog> getById(Int64 id);
    }

    public class DNHDataLogServices : EFManager<DNHDataLog>, IDNHDataLogServices
    {
        public DNHDataLogServices()
        {
        }

        public override async Task<ValidationEntry> ValidationData(DNHDataLog entity)
        {
            ValidationEntry isValidate = await base.ValidationData(entity);
            return isValidate;
        }

        public async Task<DNHDataLog> getById(Int64 id)
        {
            return await Table.Where(x => x.id == id).FirstOrDefaultAsync();
        }
    }
}
