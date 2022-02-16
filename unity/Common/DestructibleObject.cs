// +-------------------------------------------------------------------------------------------------------------------
// + File: DestructibleObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 10:20 on 2021/03/16
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using UnityEngine;

using Zanzo.Common.Enum;

namespace Zanzo.Common
{
    // +-------------------------------------------------------------------------------
    // + Class: DestructibleObject
    // + Description:
    // +    Insert Description Here
    // +-------------------------------------------------------------------------------
    public class DestructibleObject : GameplayObject
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        public delegate void InvaderNotify(DestructibleObject res);
        public event InvaderNotify DestructBegin;
        public event InvaderNotify DestructEnd;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public const string IntactNodeName = "Intact";
        public const string DestructNodeName = "Destruct";

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // private GameObject _intactNode;
        private GameObject _destructNode;

        // Properties  ------------------------------------------------------------------------------------------------
        // // I don't really like the name "DestructState" for this, just plain ol' State is a better term
        // // but I don't want to reserve such a generic and useful name in what is meant to always be a superclass.
        // // Is there another term I can use to properly describe this property without
        // public DestructibleObjectState DestructState
        // {
        //     get
        //     {
        //         return _destructibleObjectState;
        //     }
        // }

        // public GameObject IntactNode
        // {
        //     get
        //     {
        //         return _intactNode;
        //     }
        // }

        public GameObject DestructNode { get { return _destructNode; } }

        // Private Members  -------------------------------------------------------------------------------------------
        // private DestructibleObjectState _destructibleObjectState = DestructibleObjectState.Intact;

        // Class Methods  ---------------------------------------------------------------------------------------------
        // C'tor & Init Methods  ------------------------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();

            // _intactNode = transform.Find(IntactNodeName).gameObject;
            _destructNode = transform.Find(DestructNodeName).gameObject;
        }

        // Component Functionality  ---------------------------------------------------------------
        public virtual void EnableIntactColliders()
        {
            EnableAllColliders();
        }

        public virtual void EnableDestructColliders()
        {
            DisableAllColliders();
        }

        public virtual void Destruct()
        {
            SetToDestructBeginState();
            RunDestructAnimation();
            DestructBegin?.Invoke(this);
        }

        // public override void Reinitialize()
        // {
        //     base.Reinitialize();
        //     // _destructibleObjectState = DestructibleObjectState.Intact;
        //     // SetToIntactState();
        //     // Deactivate();
        // }

        public override void Activate()
        {
            _destructNode.SetActive(false);
            EnableIntactColliders();
            base.Activate();
        }

        public override void Deactivate()
        {
            DisableAllColliders();
            _destructNode.SetActive(false);
            base.Deactivate();
        }

        // private void SetToIntactState()
        // {
        //     // _destructibleObjectState = DestructibleObjectState.Intact;
        //     // _intactNode.SetActive(true);
        //     _destructNode.SetActive(false);
        //     EnableIntactColliders();
        // }

        private void SetToDestructBeginState()
        {
            EnableDestructColliders();
            // _destructibleObjectState = DestructibleObjectState.DestructBegin;
            ActiveNode.SetActive(false);
            InactiveNode.SetActive(false);
            _destructNode.SetActive(true);
        }

        private void SetToDestructEndState()
        {
            DisableAllColliders();
            // _destructibleObjectState = DestructibleObjectState.DestructEnd;
            ActiveNode.SetActive(false);
            InactiveNode.SetActive(false);
            _destructNode.SetActive(false);
        }

        public virtual void RunDestructAnimation()
        {
            OnDestructAnimationEnd();
        }

        public virtual void OnDestructAnimationEnd()
        {
            SetToDestructEndState();
            DestructEnd?.Invoke(this);
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
