// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 21:16 on 2021/03/23
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Zanzo.Common
{
    // +-------------------------------------------------------------------------------
    // + Class: GameplayObject
    // + Description:
    // +    Insert Description Here
    // +-------------------------------------------------------------------------------
    public abstract class GameplayObject : ZanzoObject
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
        private Rigidbody2D _rigidbody;
        private List<Collider2D> _colliders;

        // +---------------------------------------------------
        // + Public Members
        // +---------------------------------------------------
        // +-------------------------------
        // + Inspector / Editor Properties
        // +-------------------------------

        // +-------------------------------
        // + Properties
        // +-------------------------------
        public Rigidbody2D Rigidbody
        {
            get
            {
                return _rigidbody;
            }
        }

        public List<Collider2D> Colliders
        {
            get
            {
                return _colliders;
            }
        }

        // +-----------------------------------------------------------------------
        // + Class Methods
        // +-----------------------------------------------------------------------
        // +---------------------------------------------------
        // + C'tor & Init Methods
        // +---------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();

            _rigidbody = GetComponent<Rigidbody2D>();
            _colliders = new List<Collider2D>(GetComponents<Collider2D>());
        }

        // +---------------------------------------------------
        // + Component Functionality
        // +---------------------------------------------------
        public bool ContainsCollider(Collider2D cldr)
        {
            return _colliders.Contains(cldr);
        }

        public void DisableAllColliders()
        {
            for (int index = 0; index < _colliders.Count; ++index)
            {
                var cldr = _colliders[index];
                cldr.enabled = false;
            }
        }

        public void EnableAllColliders()
        {
            for (int index = 0; index < _colliders.Count; ++index)
            {
                var cldr = _colliders[index];
                cldr.enabled = true;
            }
        }

        // +---------------------------------------------------
        // + Unity Component Life-Cycle Methods
        // + Order: https://docs.unity3d.com/Manual/ExecutionOrder.html
        // +---------------------------------------------------
        // void Awake()
        // {
        //     Initialize();
        // }

        // void OnEnable()
        // {
        // }

        // void OnDisable()
        // {
        // }

        // void Start()
        // {
        // }

        // void Update()
        // {
        // }

        // void FixedUpdate()
        // {
        // }

        // void LateUpdate()
        // {
        // }

        // void OnApplicationQuit()
        // {
        // }

        // void OnDisable()
        // {
        // }
    }
}
