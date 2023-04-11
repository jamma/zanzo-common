// +-------------------------------------------------------------------------------------------------------------------
// + File: UiObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:25 on 2022/06/20
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;
using UnityEngine.UI;

using Zanzo.Common;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: UiObject
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class UiObject : ZanzoObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public const int SomeConstant = 32476;
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // [SerializeField] private string _inspectorProperty;

        // Properties  ------------------------------------------------------------------------------------------------
        // public bool SomeProperty { get; set; }
        public RectTransform CachedRectTransform { get; private set; }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();
            CachedRectTransform = GetComponent<RectTransform>();
        }

        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
    }
}
