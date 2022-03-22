using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAgent : MonoBehaviour
{

    public GameObject camera;
    public GameObject leftbutton;
    public GameObject rightbutton;
    bool isOnleftbutton =true;
    bool isOnrightbutton =true;

    private void FixedUpdate()
    {
        if(camera.transform.position.x <= -12)
        {
            if (isOnrightbutton)
            {
                rightbutton.SetActive(false);
                isOnrightbutton = false;
            }

        }
        else if (camera.transform.position.x >= 0)
        {
            if (isOnleftbutton)
            {
                leftbutton.SetActive(false);
                isOnleftbutton = false;
            }
            
            
        }
    }


    public void leftButtonClick()
    {
        float X = camera.transform.position.x +3;

        camera.transform.position = new Vector2(X, camera.transform.position.y);
        

        if (!isOnrightbutton)
        {
            rightbutton.SetActive(true);
            isOnrightbutton = true;
        }

    }
    public void rightButtonClick()
    {
        float X = camera.transform.position.x -3;
        
        camera.transform.position = new Vector2(X, camera.transform.position.y);
       

        if (!isOnleftbutton)
        {
            leftbutton.SetActive(true);
            isOnleftbutton = true;
        }
    }

}
