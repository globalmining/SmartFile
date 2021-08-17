using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementApp
{
    public class isLogin
    {
        public bool IsUserLogin(bool Result)
        {
            var _Result = Result;
            if (_Result == true)
            {
                return true;
            }
            return false;
        }
    }
}
