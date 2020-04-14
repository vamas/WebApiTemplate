using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Test.Helpers
{
    public class TestModel : BusinessLogicEntity
    {
        public int id { get; set; }        
        public bool simulate_action_error { get; set; }
        public bool is_unrecoverable { get; set; }
    }
}
