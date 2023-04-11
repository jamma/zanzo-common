// +-------------------------------------------------------------------------------------------------------------------
// + File: Trig.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 12:37 on 2022/03/08
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

using Zanzo.Common;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: Trig
    // + Description:
    // +    We'll be converting everything to floats here, not using double.
    // +    Just makes things a lot easier in Unity, since it uses float for just about everything.
    // +---------------------------------------------------------------------------------------------------------------
    public static class Trig
    {
        // Static / Constants  ----------------------------------------------------------------------------------------
        public const float Pi = (float)Math.PI;
        public const float Tau = (float)(Math.PI * 2);
        public const float DegreesToRadians = Pi / 180F;
        public const float RadiansToDegrees = 180F / Pi;

        public static Vector2 CalculatePointOnLine2d(Vector2 origin, float radians, float distance)
        {
            var offset = CalculatePoint2d(radians, distance);
            return origin + offset;
        }

        public static Vector2 CalculatePoint2d(float radians, float distance)
        {
            return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * distance;
        }

        public static float PointToAngleRadians(Vector2 point)
        {
            return Mathf.Atan2(point.y, point.x);
        }

        public static float PointToAngleDegrees(Vector2 point)
        {
            return Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
        }
    }
}
