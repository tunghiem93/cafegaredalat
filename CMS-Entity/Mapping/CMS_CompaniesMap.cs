using CMS_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Mapping
{
    public class CMS_CompaniesMap : EntityTypeConfiguration<CMS_Companies>
    {
        public CMS_CompaniesMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnType("varchar").HasMaxLength(60);
            this.Property(x => x.Name).HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
            this.Property(x => x.Description).HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
            this.Property(x => x.Email).HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
            this.Property(x => x.Phone).HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
            this.Property(x => x.Address).HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
            this.Property(x => x.ImageURL).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(x => x.LinkBlog).HasMaxLength(250).HasColumnType("varchar").IsOptional();
            this.Property(x => x.LinkFB).HasMaxLength(250).HasColumnType("varchar").IsOptional();
            this.Property(x => x.LinkTwiter).HasMaxLength(250).HasColumnType("varchar").IsOptional();
            this.Property(x => x.LinkInstagram).HasMaxLength(250).HasColumnType("varchar").IsOptional();

            this.Property(x => x.UpdatedBy).HasMaxLength(60).HasColumnType("varchar").IsOptional();
            this.Property(x => x.CreatedBy).HasMaxLength(60).HasColumnType("varchar").IsOptional();
        }
    }
}
