// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoObjectManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 20:08 on 2021/03/08
// +
// + Description:
// +    ZanzoObjectManager works in conjunction with ZanzoObject and ResourceDomain to manage object pooling.
// +    ZanzoObjectManager is mostly a wrapper around a ResourceDomain instance, so please refer to its
// +    documentation for more information on how the object pool is set up and used.
// +
// +    Populating a Manager:
// +        Items managed by this class should be mapped to values in an enum (one enum entry per type).
// +        For example, in a game with three enemies the enum to object mapping would look like:
// +
// +            EnemyType.One => Todori
// +            EnemyType.Two => WhizCheez
// +            EnemyType.Three => JimSlim
// +
// +        Populating the manager with a type is as simple as calling ZanzoObjectManager::InitializePool()
// +        and passing it the proper Enum entry, the object's prefab, and the total size of the pool:
// +
// +            ZanzoObjectManager::InitializePool(EnemyType.One, todoriPrefab, 75);
// +            ZanzoObjectManager::InitializePool(EnemyType.Two, whizCheezPrefab, 5);
// +            ZanzoObjectManager::InitializePool(EnemyType.Three, jimSlimPrefab, 20);
// +
// +        Hide() is immediately called on objects as soon as they are instantiated by the manager,
// +        this must be taken into account in the managed object's design.
// +
// +   Retaining an Object:
// +        Objects can be retained by calling Retain with the propery Enum entry:
// +
// +            var enemy = ZanzoObjectManager::Retain(EnemyType.One);
// +
// +        There is purposely no typed equivalent of Retain (there is no added benefit, add in subclass if useful)
// +        so typecast it inline if necessary:
// +
// +            var enemy = ZanzoObjectManager::Retain(EnemyType.One) as Todori;
// +
// +   Releasing an Object:
// +        Releasing an object is done by calling Release() and passing the object:
// +
// +            ZanzoObjectManager::Release(enemy)
// +
// +    Active Object Tracking:
// +        On top of retain/release functionality, managers also keep track of active objects.
// +        Whenever activate/deactivate is called on an object, its manager is automatically notified.
// +        Upon notification, the active resource list is updated to reflect all currently active objects
// +        handled by the manager. This list of active resources can be access by the property:
// +
// +            int ZanzoObjectManager::ActiveResources
// +
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using UnityEngine;

namespace Zanzo.Common
{
    // +-------------------------------------------------------------------------------
    // + Class: ZanzoObjectManager
    // + Description:
    // +    Insert Description Here
    // +-------------------------------------------------------------------------------
    public class ZanzoObjectManager<K, V> : ZanzoObject where K : System.Enum where V : ZanzoObject
    {
        // +-----------------------------------------------------------------------
        // + Data Members
        // +-----------------------------------------------------------------------
        // +---------------------------------------------------
        // + Static / Constants
        // +---------------------------------------------------

        // +---------------------------------------------------
        // + Private Members
        // +---------------------------------------------------
        private ResourceDomain<K, V> _resourceDomain = new ResourceDomain<K, V>();
        private List<V> _activeResources = new List<V>();

        // +---------------------------------------------------
        // + Public Members
        // +---------------------------------------------------
        // +-------------------------------
        // +-------------------------------
        // + Properties
        // +-------------------------------
        public ResourceDomain<K, V> ResourceDomain
        {
            get
            {
                return _resourceDomain;
            }
        }

        public IReadOnlyList<V> ActiveResources
        {
            get
            {
                return _activeResources;
            }
        }

        public bool HasActiveResources
        {
            get
            {
                return _activeResources.Count > 0;
            }
        }

        // +-----------------------------------------------------------------------
        // + Class Methods
        // +-----------------------------------------------------------------------
        // +---------------------------------------------------
        // + C'tor & Init Methods
        // +---------------------------------------------------
        public void InitializePool(K key, GameObject prefab, int size)
        {
            if (_resourceDomain.ContainsPool(key))
            {
                Debug.LogWarning("ZanzoObjectManager::InitializePool(): Cannot initialize pool, one is already present for key: " + key);
                return;
            }

            if (size <= 0)
            {
                Debug.LogWarning("ZanzoObjectManager::InitializePool(): pool size must be greater than zero: " + size);
                return;
            }

            _resourceDomain.CreatePool(key);

            for (int cnt = 0; cnt < size; ++cnt)
            {
                var obj = Instantiate(prefab);
                obj.transform.parent = transform;

                var cmp = obj.GetComponent<V>();
                cmp.Initialize();
                InitializeResource(cmp);
                cmp.Hide();

                // Don't add event handlers until after the object has been initialized.
                // This allows the object to either start activated / deactivated without
                // unnecessarily notifying those event listeners (e.g. this).
                cmp.Activated += OnResourceActivated;
                cmp.Deactivated += OnResourceDeactivated;

                _resourceDomain.AddResource(key, cmp);
            }
        }

        // Callback that can be overridden to provide custom initialization functionality.
        public virtual void InitializeResource(V res) {}

        public V Retain(K key)
        {
            var res = _resourceDomain.Retain(key);
            res.Reset();
            return res;
        }

        public void Release(V res)
        {
            if (res.IsActive)
            {
                Debug.LogWarning("ZanzoObjectManager::OnResourceReleased() - releasing an object without deactivating it: " + res);
                _activeResources.Remove(res);
            }

            _resourceDomain.Release(res);
        }

        // +---------------------------------------------------
        // + Event Handlers
        // +---------------------------------------------------
        public virtual void OnResourceActivated(ZanzoObject arg)
        {
            // Debug.Log("ZanzoObjectManager::OnResourceActivated(" + arg + ")");
            V res = (V)arg;
            _activeResources.Add(res);
        }

        public virtual void OnResourceDeactivated(ZanzoObject arg)
        {
            // Debug.Log("ZanzoObjectManager::OnResourceDeactivated(" + arg + ")");

            V res = (V)arg;
            _activeResources.Remove(res);
        }
    }
}
