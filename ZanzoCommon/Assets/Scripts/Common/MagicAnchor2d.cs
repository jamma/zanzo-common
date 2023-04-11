// +-------------------------------------------------------------------------------------------------------------------
// + File: MagicAnchor2d.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:47 on 2021/04/20
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

using Zanzo.Common;

namespace Zanzo.Common
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: MagicAnchor2d
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class MagicAnchor2d : ZanzoObject
    {
        // Private Members  -------------------------------------------------------------------------------------------
        private bool isRaised = true;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        [SerializeField] private SpriteRenderer _anchorSprite;
        [SerializeField] private Vector2 _anchorPosition = new Vector2();

        // Properties  ------------------------------------------------------------------------------------------------
        public SpriteRenderer AnchorSprite
        {
            get
            {
                return _anchorSprite;
            }
        }

        public Vector2 AnchorPosition
        {
            get
            {
                return _anchorPosition;
            }

            set
            {
                _anchorPosition = value;

                if (_anchorSprite != null)
                {
                    _anchorSprite.transform.position = _anchorPosition;
                }
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return transform.InverseTransformPoint(_anchorPosition);
            }

            set
            {
                SetLocalPosition(value);
            }
        }

        public Vector2 Position
        {
            get
            {
                return _anchorPosition;
            }

            set
            {
                SetPosition(value);
            }
        }

        public float Rotation
        {
            get
            {
                return transform.eulerAngles.z;
            }

            set
            {
                SetRotation(value);
            }
        }

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();
            IniitializeAnchorPosition();
        }

        public void IniitializeAnchorPosition()
        {
            if (_anchorSprite != null)
            {
                _anchorSprite.transform.position = _anchorPosition;
            }
        }

        // Component Functionality  -----------------------------------------------------------------------------------
        public void RaiseAnchor()
        {
            isRaised = true;
        }

        public void LowerAnchor()
        {
            isRaised = false;
        }

        private void SetLocalPosition(Vector2 localAnchorPosition)
        {
            var worldPos = transform.TransformPoint(localAnchorPosition);
            SetPosition(worldPos);
        }

        private void SetPosition(Vector2 worldAnchorPosition)
        {
            var localAnchorPosition = transform.InverseTransformPoint(_anchorPosition);
            var localOrigin = transform.InverseTransformPoint(new Vector3());
            Vector2 originToAnchorDelta = localOrigin - localAnchorPosition;
            transform.position = transform.TransformPoint(originToAnchorDelta);
        }

        private void SetRotation(float degrees)
        {
            if (isRaised)
            {
                // Debug.Log("MagicAnchor2d::SetRotation() - Pivot is raised, cannot move");
                return;
            }

            var degreesDelta = degrees - transform.eulerAngles.z;

            Vector3 anchorPosV3 = _anchorPosition;
            Quaternion rot = Quaternion.AngleAxis(degreesDelta, Vector3.forward);
            transform.position = rot * (transform.position - anchorPosV3) + anchorPosV3;
            transform.rotation = rot * transform.rotation;
        }
    }
}
