// +-------------------------------------------------------------------------------------------------------------------
// + File: EnumDomain.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 21:43 on 2021/03/29
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

namespace Zanzo.Common.Enum
{
    // +----------------------------------------------------------------------------
    // + Enum: ZanzoObjectState
    // +----------------------------------------------------------------------------
    public enum ZanzoObjectState: int
    {
        Active = 1,
        Inactive,
        Destructing
    }

    public static partial class ZanzoObjectStateExt
    {
        public static bool IsActive(this ZanzoObjectState entry)
        {
            return entry == ZanzoObjectState.Active;
        }

        public static bool IsInactive(this ZanzoObjectState entry)
        {
            return entry == ZanzoObjectState.Inactive;
        }

        public static bool IsDestructing(this ZanzoObjectState entry)
        {
            return entry == ZanzoObjectState.Destructing;
        }
    }
}
