// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 21:16 on 2021/03/23
// +
// + Description:
// +    Base class for all Zanzo project GameObjects.
// +    GameObject are not required to have a Rigidbody and/or colliders.
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
        // Events & Delegates  --------------------------------------------------------------------
        public delegate void GameplayObjectNotify(GameplayObject res);
        public event GameplayObjectNotify Retained;
        public event GameplayObjectNotify Released;

        // Data Members  --------------------------------------------------------------------------
        // Static / Constants  ------------------------------------------------

        // Private Members  ---------------------------------------------------

        // Inspector / Editor Properties  -------------------------------------

        // Properties  --------------------------------------------------------
        public bool IsRetained { get; private set; } = false;

        // Class Methods  -------------------------------------------------------------------------
        // C'tor & Init Methods  ----------------------------------------------
        // public override void Initialize()
        // {
        //     base.Initialize();
        // }

        // Component Functionality  -------------------------------------------
        // NOTE: My gut tells me that Retain / Release should NOT be virtual. If a need comes up, rethink this thoroughly.
        public void Retain()
        {
            IsRetained = true;
            Retained?.Invoke(this);
        }

        public void Release()
        {
            IsRetained = false;
            Released?.Invoke(this);
        }
    }
}
