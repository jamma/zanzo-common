// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayObjectPool.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 08:01 on 2022/08/19
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
    // + Class: GameplayObjectPool
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class GameplayObjectPool<T> where T : GameplayObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        private List<T> _pool = new List<T>();

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------
        public IReadOnlyList<T> Pool { get => _pool; }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public SpriteManager(GameObject prefab, int size, Action<Sprite, int> initFunc) : base(prefab, size)
        // public GameplayObjectPool(GameObject prefab, int size)
        public GameplayObjectPool(GameObject prefab, int size, Action<T, int> initFunc=null)
        {
            _pool = new List<T>(size);

            for (int cnt = 0; cnt < size; ++cnt)
            {
                var cmp = Util.InstantiateZanzoPrefab<T>(prefab);
                _pool.Add(cmp);
                if (initFunc != null) initFunc(cmp, cnt);
            }

            // Debug.Log($"GameplayObjectManager({typeof(T).FullName}): total objects in pool: {_pool.Count}");
        }

        public virtual void Initialize() {}
        public virtual void Reinitialize() {}
        private void DefaultInit(T arg, int index) {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public T Retain()
        {
            // Do not put a defensive check around this, at this point the pool should exist.
            // If it does not the ResourceDomain class is being used incorrectly,
            // and the bug is further up somewhere else in the code.
            // var pool = _pool[key];

            for (int index = 0; index < _pool.Count; ++index)
            {
                // Debug.Log($"GameplayObjectManager.Retain<{typeof(T).FullName}>(): index: {index}");
                var res = _pool[index];
                if (!res.IsRetained)
                {
                    // Debug.Log($"GameplayObjectManager::Retain(): Found object at index: {index}");
                    res.Retain();
                    res.Reinitialize();
                    return res;
                }
            }

            // Debug.Log($"GameplayObjectManager::Retain(): No retainable object found");
            return null;
        }

        public void Release(T res)
        {
            if (!res.IsRetained) Debug.LogWarning("Attempt to release unretained resource: " + res);

            res.Release();
        }
    }
}
