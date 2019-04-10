/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    public class Inputs : MonoBehaviour
    {
        #region variables
        public struct InputLeftXStick //Sticks
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }

        public struct InputRightXStick
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }

        public struct InputLeftYStick
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }

        public struct InputLTrigger //Triggers
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }

        public struct InputRTrigger
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }

        public struct InputTrigger
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }


        public struct InputXButton //XButton
        {
            public float joy1;
            public float joy2;
            public float joy3;
        }
        

        public InputLeftXStick InputLeftXAxis;
        public InputRightXStick InputRightXAxis;
        public InputLeftYStick InputLeftYAxis;
        public InputLTrigger InputLeftTrigger;
        public InputLTrigger InputRightTrigger;
        public InputTrigger inputTrigger;
        public InputXButton InputButtonX;
        #endregion


        void Update()
        {
            //Joystick1
            InputLeftXAxis.joy1 = Input.GetAxis("LeftXAxis1");
            InputRightXAxis.joy1 = Input.GetAxis("RightXAxis1");
            InputLeftYAxis.joy1 = Input.GetAxis("LeftYAxis1");
            InputLeftTrigger.joy1 = Input.GetAxis("LeftTrigger1") - 1.0f;
            InputRightTrigger.joy1 = Input.GetAxis("RightTrigger1") + 1.0f;
            inputTrigger.joy1 = Input.GetAxis("Trigger1");
            if (Input.GetButtonDown("Fire1"))
                InputButtonX.joy1 = 1;
            else
                InputButtonX.joy1 = 0;


            //Joystick2
            InputLeftXAxis.joy2 = Input.GetAxis("LeftXAxis2");
            InputRightXAxis.joy2 = Input.GetAxis("RightXAxis2");
            InputLeftYAxis.joy2 = Input.GetAxis("LeftYAxis2");
            InputLeftTrigger.joy2 = Input.GetAxis("LeftTrigger2") - 1.0f;
            InputRightTrigger.joy2 = Input.GetAxis("RightTrigger2") + 1.0f;
            inputTrigger.joy2 = Input.GetAxis("Trigger2");
            if (Input.GetButtonDown("Fire2")) 
                InputButtonX.joy2 = 1;
            else
                InputButtonX.joy2 = 0;

            //Joystick3
            InputLeftXAxis.joy3 = Input.GetAxis("LeftXAxis3");
            InputRightXAxis.joy3 = Input.GetAxis("RightXAxis3");
            InputLeftYAxis.joy3 = Input.GetAxis("LeftYAxis3");
            InputLeftTrigger.joy3 = Input.GetAxis("LeftTrigger3") - 1.0f;
            InputRightTrigger.joy3 = Input.GetAxis("RightTrigger3") + 1.0f;
            inputTrigger.joy3 = Input.GetAxis("Trigger3");
            if (Input.GetButtonDown("Fire3"))
                InputButtonX.joy3 = 1;
            else
                InputButtonX.joy3 = 0;
        }
    }
}