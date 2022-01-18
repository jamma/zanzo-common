// +-------------------------------------------------------------------------------------------------------------------
// + File: Util.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 18:11 on 2021/03/31
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: Util
    // + Description:
    // +    Placeholder for a bunch of utility methods
    // +---------------------------------------------------------------------------------------------------------------
    public static class Util
    {
        public static readonly System.Random Rand = new System.Random();
        public static readonly float RadiansToDegrees = (float)(180F / Math.PI);
        public static readonly float DegreesToRadians = (float)(Math.PI / 180F);

        public static T GetRandomEnumValue<T>() where T : System.Enum
        {
            var enumValues = System.Enum.GetValues(typeof(T));
            var randomIndex = Rand.Next(enumValues.Length);
            return (T)enumValues.GetValue(randomIndex);
        }

        public static T GetRandomItem<T>(IReadOnlyList<T> list)
        {
            var index = Rand.Next(list.Count);
            // Debug.Log("Util::GetRandomItem() - bounds: " + list.Count + " random value: " + index);
            return list[index];
        }
    }
}
