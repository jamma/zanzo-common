// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayObjectDomain.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 10:50 on 2023/03/27
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// using UnityEngine;

// using Zanzo.Common;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: GameplayObjectDomain
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class GameplayObjectDomain<T> : ZanzoObject where T : GameplayObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        private List<T> _activeSprites = new List<T>();

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------
        public IReadOnlyList<T> ActiveSprites { get => _activeSprites; }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public virtual void OnGameplayObjectActivated(T gpo)
        {
            _activeSprites.Add(gpo);
            // MaxActiveSprites = Math.Max(MaxActiveSprites, _activeSprites.Count);
        }

        public virtual void OnGameplayObjectDeactivated(T gpo)
        {
            _activeSprites.Remove(gpo);
        }
    }
}
