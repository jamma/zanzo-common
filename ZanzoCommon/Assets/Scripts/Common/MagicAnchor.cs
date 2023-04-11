// +-------------------------------------------------------------------------------------------------------------------
// + File: MagicAnchor.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:31 on 2021/04/02
// +
// + Description:
// +    Used to set the transformation point for child components. Modifying the transformation point will not modify
// +    modify the screen placement of any child components. This allows easily changing the anchor point of an
// +    object (or group of objects) when positioning them, as well as rotation around an arbitrary point.
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: MagicAnchor
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class MagicAnchor : MonoBehaviour
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;
        // public SpriteRenderer bounds
        public Vector2 bounds;

        // Properties  ------------------------------------------------------------------------------------------------
        // public bool SomeProperty
        // {
        //     get
        //     {
        //         return _somePrivateMember;
        //     }
        //     set
        //     {
        //         _somePrivateMember = value;
        //     }
        // }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
    }
}
