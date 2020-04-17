using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGExpress.Services.Data;

namespace VK1.SCGExpress.Services {
    public class AppQuery {
        private readonly AppQueryDb db;

        public AppQuery(AppQueryDb db) {
            this.db = db;
        }

        // Save change
        public async Task<int> ExecuteToSqlAsync(string sql) => await db.Database.ExecuteSqlRawAsync(sql);
    }
}
