using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[System.Serializable]
public class BoolEvent : UnityEvent<bool>
{
}

namespace Valve.VR
{

    public class NewInputSystem : MonoBehaviour
    {
        Hand hand;
        [SerializeField] int _handNo;
        bool _trigger;
        public SteamVR_Action_Boolean onTriggerAction;
        public BoolEvent _onTrigger;
        public UnityEvent _onTriggerPress;
        public UnityEvent _onTriggerUp;

        public SteamVR_Action_Boolean onGripAction;
        public BoolEvent _onGrip;

        public SteamVR_Action_Boolean onTouchAction;
        public BoolEvent _onTouch;

        private void OnEnable()
        {
            if (hand == null)
                hand = Player.instance.GetHand(_handNo);

            //onTriggerAction.AddOnChangeListener(OnTriggerActionChange, SteamVR_Input_Sources.Any);
            //onGripAction.AddOnChangeListener(OnGripActionChange, hand.handType);
            //onTouchAction.AddOnChangeListener(OnTouchActionChange, hand.handType);
        }

        private void OnDisable()
        {
            //if (onTriggerAction != null)
            //    onTriggerAction.RemoveOnChangeListener(OnTriggerActionChange, hand.handType);
            //onGripAction.RemoveOnChangeListener(OnGripActionChange, hand.handType);
            //onTouchAction.RemoveOnChangeListener(OnTouchActionChange, hand.handType);

        }

        //private void OnTriggerActionChange(SteamVR_Action_In actionIn)
        //{
        //    if (onTriggerAction.GetStateDown(hand.handType))
        //    {
        //        _onTrigger.Invoke(true);
        //        _trigger = true;

        //    }
        //    else
        //    {
        //        _onTrigger.Invoke(false);
        //        _trigger = false;
        //    }
        //}
        //private void OnGripActionChange(SteamVR_Action_In actionIn)
        //{
        //    if (onGripAction.GetStateDown(hand.handType))
        //    {
        //        _onGrip.Invoke(true);
        //    }
        //    else
        //    {
        //        _onGrip.Invoke(false);
        //    }
        //}
        //private void OnTouchActionChange(SteamVR_Action_In actionIn)
        //{
        //    if (onTouchAction.GetStateDown(hand.handType))
        //    {
        //        _onTouch.Invoke(true);
        //    }
        //    else
        //    {
        //        _onTouch.Invoke(false);
        //    }
        //}

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_trigger)
            {
                 _onTriggerPress.Invoke();

            }
            else
            {

                _onTriggerUp.Invoke();
            }

            if (onTriggerAction.stateDown)
            {
                _trigger = true;
                _onTrigger.Invoke(true);
            }

            if (onTriggerAction.stateUp)
            {
                _trigger = false;
                _onTrigger.Invoke(false);

            }

            if (onGripAction.stateDown)
            {
                _onGrip.Invoke(true);
            }
            if (onGripAction.stateUp)
            {
                _onGrip.Invoke(false);
            }
            if (onTouchAction.stateDown)
            {
                _onTouch.Invoke(true);
            }
            if (onTouchAction.stateUp)
            {
                _onTouch.Invoke(false);

            }
        }
    }
}
