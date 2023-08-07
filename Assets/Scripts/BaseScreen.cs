using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    Start, GameOver, Popups
}

public class BaseScreen : MonoBehaviour
{
    
   

        public ScreenType screenType;
        [HideInInspector]
        public Canvas canvas;
        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    
}
