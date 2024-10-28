using prac5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac5
{
    internal class Helper
    {
        private static construction_organizationEntities1 _context;


        public static construction_organizationEntities1 GetContext()
        {
            if (_context == null)
            {
                _context = new construction_organizationEntities1();
            }
            return _context;
        }
    }
}
