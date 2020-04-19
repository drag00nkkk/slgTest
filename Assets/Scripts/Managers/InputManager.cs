using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLGLib
{
    public class InputManager : Singleton<InputManager>, IManager
    {
        private readonly KeyCode[] listenKeyUpList =
        {
            KeyCode.A,
            KeyCode.W,
            KeyCode.D,
            KeyCode.S,
        };

        public Action<KeyCode> OnKeyUp;

        public void OnInitScene()
        {
            
        }

        public void Update()
        {
            foreach (var upKeyCode in listenKeyUpList)
            {
                if (Input.GetKeyUp(upKeyCode))
                {
                    HandleKeyUp(upKeyCode);
                }
            }
        }

        private void HandleKeyUp(KeyCode keyCode)
        {
            OnKeyUp?.Invoke(keyCode);
        }
    }
}