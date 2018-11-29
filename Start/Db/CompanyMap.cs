using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Db
{
    class CompanyMap: EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            MapToStoredProcedures(config=> {
                config.Delete(procConfig =>
                {
                    procConfig.HasName("CompanyDelete");
                    procConfig.Parameter(company => company.CompanyId, "companyId");
                });
                config.Insert(procConfig =>
procConfig.HasName("CompanyInsert"));
                config.Update(procConfig =>
                procConfig.HasName("CompanyUpdate")); config.Insert(procConfig =>
 procConfig.HasName("CompanyInsert"));
                config.Update(procConfig =>
                procConfig.HasName("CompanyUpdate"));
            });
        }
    }
}
