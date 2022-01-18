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
    // + Enum: DestructibleObjectState
    // +----------------------------------------------------------------------------
    public enum DestructibleObjectState: int
    {
        DestructBegin = 32481,
        DestructEnd = 32482,
        Intact = 32483,
    }

    public static partial class DestructibleObjectStateExtensions
    {
        public static bool IsDestructBegin(this DestructibleObjectState entry)
        {
            return entry == DestructibleObjectState.DestructBegin;
        }

        public static bool IsDestructEnd(this DestructibleObjectState entry)
        {
            return entry == DestructibleObjectState.DestructEnd;
        }

        public static bool IsIntact(this DestructibleObjectState entry)
        {
            return entry == DestructibleObjectState.Intact;
        }
    }
}
