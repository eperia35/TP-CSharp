using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpDojo.Entities
{
    public abstract class CommonModel
    {

        private long _Id;

        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }
}