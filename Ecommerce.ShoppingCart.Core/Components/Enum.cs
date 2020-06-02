using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Components
{
    public class Enum
    {
        public enum Status
        {
            [Description("Yeni")]
            New = 0,
            [Description("Aktif")]
            Active = 1,
            [Description("Pasif")]
            Passive = 2,
            [Description("Silinmiş")]
            Deleted = 3
        }

        public enum StatusType
        {
            All = -1,
            OnlyNew = 0,
            OnlyActive = 1,
            OnlyPassive = 2,
            OnlyDeleted = 3,
            ActiveAndNew = -2
        }

        public enum DiscountType
        {
            Rate = 1,
            Amount =2
        }
    }
}
