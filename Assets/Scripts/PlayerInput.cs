using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void cliclAction();
    public static event cliclAction OnClick;
    public static event cliclAction OnClickUp;

    public bool shoot ;


    // Update is called once per frame
    void Update( )
    {
        if (shoot) return;
        
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (OnClick != null)
                {
                    OnClick();
                }
            }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (OnClick != null)
            {
                OnClickUp();
            }
        }

    }
   

}
