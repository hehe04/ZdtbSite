﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IRepository<Document>
    {
        public DocumentRepository(IDbContextFactory dbcontextFactory) : base(dbcontextFactory) { }
    }
}