using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel.Helpers
{
    public class EmptyEntity : Entity
    {
        public override object GetId()
        {
            return new Guid();
        }
    }
}
