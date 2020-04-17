using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VK1.SCGExpress.Services.Data {
    public class AppQueryDb : DbContext {
        public AppQueryDb() {
            //
        }
        public AppQueryDb(DbContextOptions<AppQueryDb> options) : base(options) {
            //
        }
    }
}
