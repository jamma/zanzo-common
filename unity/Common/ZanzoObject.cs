// +-------------------------------------------------------------------------------------------------------------------
// + File: ZanzoObject.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 11:25 on 2021/03/27
// +
// + Description:
// +    This base class has functionality to make managing things a bit easier.
// +    The functionality is there so that it can easily be used within a ZanzoObjectManager,
// +    but this should still be the base class for all components in a project whether or not they're managed.
// +
// +    1.  The methods Initialize() and Reinitialize() have similar names, but slightly different purposes.
// +        If implemented, Initialize() should be called to complete proper set up of the component.
// +        This call is expected to be called once ONLY, either immediately or soon after instantiation.
// +
// +        Reinitialize() should be called to reset the state of the component for re-use. This method can be called
// +        whenever and however often as necessary. Ideally this method would be called Reset(), but that would clash
// +        with a Unity MonoBehaviour life-cycle method of the same name.
// +
// +    2.  All ZanzoObjects have a flag that marks whether or not they're currently retained by a Manager.
// +        This is done completely out of convenience, as it's far simpler to just query the object in
// +        question to see whether or not it's currently retained, than to check with the object's manager.
// +
// +    3.  All ZanzoObjects have a flag that handles the concept of activate/inactive,
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
// +    4.  All ZanzoObjects emit events based on the above states:
// +            3. Activated
// +            4. Deactivated
// +
// +    5.  The expected lifecycle (order of events) for a typical ZanzoObject being used within a manager is:
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
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: ZanzoObject
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ZanzoObject : MonoBehaviour, Retainable
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        public delegate void ZanzoObjectNotify(ZanzoObject res);
        public event ZanzoObjectNotify Activated;
        public event ZanzoObjectNotify Deactivated;

        // Private Members  -------------------------------------------------------------------------------------------
        private bool _isActivated = false;
        private bool _isRetained = false;

        // Properties  ------------------------------------------------------------------------------------------------
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

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public virtual void Initialize() {}
        public virtual void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------

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
    }
}
