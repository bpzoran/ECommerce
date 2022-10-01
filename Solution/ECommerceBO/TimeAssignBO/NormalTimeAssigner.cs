using IECommerceBO.TimeAssignBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.TimeAssignBO
{
    public class NormalTimeAssigner : ITimeAssigner
    {
        public DateTime DateTime { get => DateTime.Now; }
    }
}
