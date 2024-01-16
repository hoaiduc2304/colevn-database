using DNH.Infrastructure.Database;
using DNH.Infrastructure.Database.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System;


namespace colevn.study.Contact
{
    public class DNHDataLog
    {
        public Int64 id { get; set; }
        public string sqlscript { get; set; }
        public DateTime CreatedDate{ get; set; }
        public string CreatedUser { get; set; }
    }
    public class DNHDataLogMap : EntityTypeConfiguration<DNHDataLog>
    {
        public override void Configure(EntityTypeBuilder<DNHDataLog> builder)
        {
            builder.ToTable("DNHDataLog");
            builder.HasKey(x => new
            {
                x.id
            }

            );
            base.Configure(builder);
        }
    }
}
