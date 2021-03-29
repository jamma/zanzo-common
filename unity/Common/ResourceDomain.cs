// +-------------------------------------------------------------------------------------------------------------------
// + File: ResourceDomain.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 22:25 on 2021/03/23
// +
// + Description:
// +    ResourceDomain is responsible for managing categories of objects (placed in pools), acting as a cache for
// +    obects in the game. The expected use case for this is to allocate a bunch of game objects at the beginning
// +    of the game, and request them as needed.
// +
// +    This class is not intended to be used standalone, its design purpose is to encapsulate object pooling
// +    from Manager wrapper classes.
// +
// +    Performance Notes:
// +        Retaining and releasing large amounts of game objects in quick succession during gameplay can lead to
// +        performance issues, as a linear search is performed in Retain() to find the first eligible item.
// +        If a situation arises where this is not performant enough, ResourceDomain should be turned
// +        into an interface with separate strategies implemented to handle specific use cases. For the types of games
// +        I currently create the simplicity of this code is the primary focus, since any attempt to make this more
// +        performant will most likely not have any noticeable gains for my current needs.
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using UnityEngine;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Interface: Retainable
    // + Description:
    // +    All items managed by a ResourceDomain must satisfy this interface.
    // +---------------------------------------------------------------------------------------------------------------
    public interface Retainable
    {
        bool IsRetained { get; }
        void Retain();
        void Release();
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: ResourceDomain
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ResourceDomain<K, V> where K : System.Enum where V : Retainable
    {
        // Private Members  -------------------------------------------------------------------------------------------
        private Dictionary<K, List<V>> _domain = new Dictionary<K, List<V>>();

        // Class Methdos  ----------------------------------------------------------------------------------------------
        public void CreatePool(K key)
        {
            AddPool(key, new List<V>());
        }

        public void AddPool(K key, List<V> pool)
        {
            if (ContainsPool(key))
            {
                Debug.LogWarning("ResourceDomain::AddPool(): Cannot add pool, one is already present for key: " + key);
                return;
            }

            _domain[key] = pool;
        }

        public bool ContainsPool(K key)
        {
            return _domain.ContainsKey(key);
        }

        public void AddResource(K key, V res)
        {
            // if (!ContainsPool(key))
            // {
            //     Debug.LogWarning("ResourceDomain::AddResource(): Cannot add resource, pool not present for key: " + key);
            //     return;
            // }

            var pool = _domain[key];

            if (pool.Contains(res))
            {
                Debug.LogWarning("ResourceDomain::AddResource() - resource already present in pool: " + res);
            }

            pool.Add(res);
        }

        public IReadOnlyList<V> GetPool(K key)
        {
            List<V> pool;
            _domain.TryGetValue(key, out pool);
            return pool;
        }

        public V Retain(K key)
        {
            // Do not put a defensive check around this, at this point the pool should exist.
            // If it does not the ResourceDomain class is being used incorrectly,
            // and the bug is further up somewhere else in the code.
            var pool = _domain[key];

            for (int index = 0; index < pool.Count; ++index)
            {
                var res = pool[index];
                if (!res.IsRetained)
                {
                    res.Retain();
                    return res;
                }
            }

            return default(V);
        }

        public void Release(V res)
        {
            if (!res.IsRetained)
            {
                Debug.LogWarning("Attempt to release unretained resource: " + res);
            }

            res.Release();
        }
    }
}
