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

using Zanzo.Common.Enum;

namespace Zanzo.Common
{
    // +-------------------------------------------------------------------------------
    // + Class: GameplayObject
    // + Description:
    // +    Insert Description Here
    // +-------------------------------------------------------------------------------
    public abstract class GameplayObject : ZanzoObject
    {
        // Data Members  --------------------------------------------------------------------------
        // Static / Constants  ------------------------------------------------
        public const string ActiveNodeName = "Active";
        public const string InactiveNodeName = "Inactive";

        // Private Members  ---------------------------------------------------
        private Rigidbody2D _rigidbody;
        private List<Collider2D> _colliders;

        // Inspector / Editor Properties  -------------------------------------
        [SerializeField] private GameObject _activeNode;
        [SerializeField] private GameObject _inactiveNode;

        // Properties  --------------------------------------------------------
        public Rigidbody2D Rigidbody { get { return _rigidbody; } }
        public List<Collider2D> Colliders { get { return _colliders; } }
        public GameObject ActiveNode { get { return _activeNode; } }
        public GameObject InactiveNode { get { return _inactiveNode; } }

        // Class Methods  -------------------------------------------------------------------------
        // C'tor & Init Methods  ----------------------------------------------
        public override void Initialize()
        {
            base.Initialize();

            _rigidbody = GetComponent<Rigidbody2D>();
            _colliders = new List<Collider2D>(GetComponents<Collider2D>());

            if (_activeNode == null) _activeNode = transform.Find(ActiveNodeName).gameObject;
            if (_inactiveNode == null) _inactiveNode = transform.Find(InactiveNodeName).gameObject;
        }

        // Component Functionality  -------------------------------------------
        public override void Activate()
        {

            _activeNode?.SetActive(true);
            _inactiveNode?.SetActive(false);
            base.Activate();
        }

        public override void Deactivate()
        {

            _activeNode?.SetActive(false);
            _inactiveNode?.SetActive(true);
            base.Deactivate();
        }

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
