using colevn.study.Contact;
using DNH.Infrastructure.Database.SQL;
using DNHCore.Model;

namespace colevn.study.business.Services
{
    

    using Microsoft.EntityFrameworkCore;

    public interface IDNHDataLogServices : IEfManager<DNHDataLog>
    {
        Task<DNHDataLog> getById(Int64 id);
        Task<List<DNHDataLog>> GetAllData(int daysExpired);
        Task<DNHDataLog> SaveDataLog(DNHDataLog entry);
    }

    //public class DNHDataLogOnpermissServices : EFManager<DNHDataLog>, IDNHDataLogServices
    //{
    //    public Task<DNHDataLog> getById(long id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

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
        public async Task<DNHDataLog> SaveDataLog(DNHDataLog entry)
        {
            if (entry == null) return null;
            
            entry.sqlscript = entry.sqlscript + " [Đã adjust]";
            entry.CreatedDate = DateTime.UtcNow;
            AddEntity(entry);
            return entry;
        }
            public async Task<DNHDataLog> getById(Int64 id)
        {
            var entry = await Table.Where(x => x.id == id).FirstOrDefaultAsync();
          
            return entry;
        }

        public async Task<List<DNHDataLog>> GetAllData(int daysExpired)
        {
            return await Table.Where(x => x.CreatedDate <=DateTime.Now.AddDays(-daysExpired)).ToListAsync();
        }
    }
}
