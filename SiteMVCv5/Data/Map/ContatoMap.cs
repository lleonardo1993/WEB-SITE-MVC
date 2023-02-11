using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteMVCv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVCv5.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
