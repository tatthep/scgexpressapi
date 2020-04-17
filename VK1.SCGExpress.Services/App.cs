using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGExpress.Services.Data;

namespace VK1.SCGExpress.Services {
    public class App {
        internal readonly AppDb db;

        public App(AppDb db) {
            this.db = db;
        }


        // Save change
        public int SaveChanges() => db.SaveChanges();
        public Task<int> SaveChangesAsync() => db.SaveChangesAsync();
        public async Task<int> ExecuteToSqlAsync(string sql) => await db.Database.ExecuteSqlRawAsync(sql);

    }
}
