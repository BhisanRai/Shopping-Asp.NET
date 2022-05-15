using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    public class CommonController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CommonController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<IActionResult> Index(Matrial matrial, List<MaterialItem> item)
        {
            if (matrial.Name!=null && item.Count!=0)
            {
                dbContext.Add(matrial);
                await dbContext.SaveChangesAsync();
                

                for (var i = 0; i < item.Count; i++)
                {
                    item[i].MatrialID = matrial.MatrialID;
                }
                return RedirectToAction("CommonData");
            }
            return View();
        }

        public IActionResult CommonData()
        {
            Master mastobj = new Master
            {
                Matrial = dbContext.Matrial.ToList(),
                MaterialItem = dbContext.MaterialItem.ToList()
            };
            return View(mastobj);
        }

    }
}
