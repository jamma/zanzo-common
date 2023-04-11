// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayObject2d.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 08:30 on 2022/08/15
// +
// + Description:
// +    Specialization of GameplayObject for 2D.
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using UnityEngine;

using Zanzo.Common;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: GameplayObject2d
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class GameplayObject2d : GameplayObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        // private float _privateMember;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // [SerializeField] private Rigidbody2D _rigidbody;
        // [SerializeField] private List<Collider2D> _colliders;

        // Properties  ------------------------------------------------------------------------------------------------
        public Rigidbody2D Rigidbody { get; private set; }
        public IReadOnlyList<Collider2D> Colliders { get; private set; }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();

            Rigidbody = GetComponent<Rigidbody2D>();
            Colliders = new List<Collider2D>(GetComponents<Collider2D>());
        }

        // public override void Reinitialize() {}

        public override void Activate()
        {
            base.Activate();
            if (Colliders != null) EnableActiveColliders();
        }

        public override void Deactivate()
        {
            if (Colliders != null) EnableInactiveColliders();
            base.Deactivate();
        }

        public virtual void DisableAllColliders()
        {
            for (int index = 0; index < Colliders.Count; ++index)
            {
                var cldr = Colliders[index];
                cldr.enabled = false;
            }
        }

        public virtual void EnableAllColliders()
        {
            for (int index = 0; index < Colliders.Count; ++index)
            {
                var cldr = Colliders[index];
                cldr.enabled = true;
            }
        }

        public virtual void EnableActiveColliders()
        {
            EnableAllColliders();
        }

        public virtual void EnableInactiveColliders()
        {
            DisableAllColliders();
        }

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
    }
}
