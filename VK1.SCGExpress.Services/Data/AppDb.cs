using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGExpress.Services.Data {
    public class AppDb : DbContext {
        public AppDb() {
            //
        }
        public AppDb(DbContextOptions<AppDb> options) : base(options) {
            //
        }
    }
}
