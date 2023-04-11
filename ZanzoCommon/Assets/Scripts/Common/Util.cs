// +-------------------------------------------------------------------------------------------------------------------
// + File: Util.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 18:11 on 2021/03/31
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;

using Unity;
using UnityEngine;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: Util
    // + Description:
    // +    Placeholder for a bunch of utility methods
    // +---------------------------------------------------------------------------------------------------------------
    public static partial class Util
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

        public static T GetRandomItem<T>(T[] array)
        {
            var index = Rand.Next(array.Length);
            // Debug.Log("Util::GetRandomItem() - bounds: " + list.Count + " random value: " + index);
            return array[index];
        }

        public static int GetRandomInRange(int min, int max)
        {
            // var diff = max - min;
            return Rand.Next(max - min) + min;
        }

        public static float GetRandomInRange(float min, float max)
        {
            // var diff = max - min;
            return (float)(Rand.NextDouble() * (max - min)) + min;
        }

        public static List<T> Shuffle<T>(this IReadOnlyList<T> list)
        {
            return list.OrderBy(a => Rand.Next()).ToList();
        }

        public static C InstantiatePrefab<C>(GameObject prefab, Transform parent) where C : MonoBehaviour
        {
            var obj = UnityEngine.Object.Instantiate(prefab);
            obj.transform.parent = parent ?? obj.transform.parent;
            // if (parent != null)
            // {
            //     obj.transform.parent = parent.transform;
            // }

            var cmp = obj.GetComponent<C>();
            return cmp;
        }

        // Calls ZanzoObject::Initialize() immediately after instantiation 
        public static Z InstantiateZanzoPrefab<Z>(GameObject prefab, Transform parent = null) where Z : ZanzoObject
        {
            // var zzo = InstantiatePrefab<Z>(prefab, parent ?? gameObject);
            var zzo = InstantiatePrefab<Z>(prefab, parent);
            // NOTE: Do NOT initialize here, we do not have enough information at this point.
            //       Some ZZ objects may need initialization arguments to properly set themselves up.
            // zzo.Initialize();
            return zzo;
        }

        public static float OrthographicSizeHalfHeight { get => Camera.main.orthographicSize; }
        public static float OrthographicSizeHalfWidth { get => OrthographicSizeHeight * (Screen.width / (float)Screen.height); }
        public static float OrthographicSizeHeight { get => OrthographicSizeHalfHeight * 2; }
        public static float OrthographicSizeWidth { get => OrthographicSizeHalfWidth * 2; }
    }
}
