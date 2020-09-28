using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.budget.Controllers
{
    public class AppController: ControllerBase
    {
        public string Body {
            get
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
