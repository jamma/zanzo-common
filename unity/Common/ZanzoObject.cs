// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 07:39 on 2021/03/08
// +
// + Description:
// +    This base class has functionality to make managing things a bit easier.
// +    The functionality is there so that it can be easily used within a ZanzoObjectManager,
// +    but this should still be the base class for all components in a project whether or not they're managed.
// +
// +    1.  All ZanzoObjects have a flag that marks whether or not they're currently retained by a Manager.
// +        This is done completely out of convenience, as it's far simpler to just query the object in
// +        question to see whether or not it's currently retained, than to check with the object's manager.
// +
// +    2.  All ZanzoObjects have a flag that handles the concept of activate/inactive,
// +           which abstracts the concept of active/inactive from its specific meaning in Unity.
// +        It makes perfect sense why Unity implemented and named it this way, but I frequently
// +        want to consider something "deactivated" while still displaying it on-screen.
// +        The most common example is deactivating an object that has been destroyed,
// +        but still wanting to display its destruct animation.
// +
// +        Hide() and Display() methods have been added, and these methods act more like the typical
// +        Unity gameObject.SetActive() method. These methods can be overridden to adapt to the needs
// +        of a particular subclass.
// +
// +
// +    3.  All ZanzoObjects emit events based on the above states:
// +            3. Activated
// +            4. Deactivated
// +
// +    4.  The expected lifecycle (order of events) for a typical ZanzoObject being used within a manager is:
// +            1. Retained
// +            2. Activated
// +            3. Deactivated
// +            4. Possible custom state
// +            5. Released
// +
// +        The order can be rearranged as long as care is taken in its respective manager, however.
// +-------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Zanzo.Common
{
    // +-------------------------------------------------------------------------------
    // + Class: ZanzoObject
    // + Description:
    // +    Insert Description Here
    // +-------------------------------------------------------------------------------
    public class ZanzoObject : MonoBehaviour, Retainable
    {
        // +---------------------------------------------------
        // + Events & Delegates
        // +---------------------------------------------------
        public delegate void ZanzoObjectNotify(ZanzoObject res);
        public event ZanzoObjectNotify Activated;
        public event ZanzoObjectNotify Deactivated;

        // +-----------------------------------------------------------------------
        // + Data Members
        // +-----------------------------------------------------------------------
        // +---------------------------------------------------
        // + Private Members
        // +---------------------------------------------------
        private bool _isActivated = false;
        private bool _isRetained = false;

        // +---------------------------------------------------
        // + Public Members
        // +---------------------------------------------------
        // +-------------------------------
        // + Properties
        // +-------------------------------
        public bool IsActive
        {
            get
            {
                return _isActivated;
            }
        }

        public bool IsRetained
        {
            get
            {
                return _isRetained;
            }
        }

        // +-----------------------------------------------------------------------
        // + Class Methods
        // +-----------------------------------------------------------------------
        // +---------------------------------------------------
        // + C'tor & Init Methods
        // +---------------------------------------------------
        public virtual void Initialize()
        {
        }

        // +---------------------------------------------------
        // + Component Functionality
        // +---------------------------------------------------
        // NOTE: My gut tells me that Retain / Release / Activate / Deactivate should NOT be virtual,
        //       but if the need arises reconsider this. Currently, I cannot imagine a scenario where it makes sense.
        //       Also, and probably more importantly, Retain / Release should probably only be callable to classes
        //       within Zanzo.Common. Exposing this globally is a bad idea, but I'm not sure if there's a way to 
        //       accomplish what I really want in C# (I want the functionality of the C++ friend keyword).
        public void Retain()
        {
            _isRetained = true;
        }

        public void Release()
        {
            _isRetained = false;
        }

        public void Activate()
        {
            _isActivated = true;
            Activated?.Invoke(this);
        }

        public void Deactivate()
        {
            _isActivated = false;
            Deactivated?.Invoke(this);
        }

        public virtual void Display()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Reset()
        {
        }

        // +---------------------------------------------------
        // + Unity Life-Cycle Methods
        // + Order: https://docs.unity3d.com/Manual/ExecutionOrder.html
        // +---------------------------------------------------
        // void Awake()
        // {
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
