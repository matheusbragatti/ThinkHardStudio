using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //selectEffect("mouse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float generator;
    public void selectEffect(string typeInput)
    {

        generator = Random.Range(1f, 5f);

        if(typeInput == "mouse")
        {
            Debug.Log("ENTERED IN MOUSE");
            generator = 2;
            switch(generator)
            {
                case 1:
                invertMouse();
                break;

                case 2:
                flipScreen();
                break;

                case 3:
                playSoundWindows();
                break;

                case 4:
                playSoundNotification();
                break;

            }
        }

        if(typeInput == "keys")
        {
            Debug.Log("ENTERED IN KEYS");
            switch(generator)
            {
                case 1:
                swapKeys();
                break;

                case 2:
                flipScreen();
                break;

                case 3:
                playSoundWindows();
                break;

                case 4:
                playSoundNotification();
                break;

            }
        }



    }

public float mouseY = 0;
public float mouseX = 0;
public Transform alvo;
void invertMouse()
{
    transform.RotateAround (alvo.position, transform.right, -Input.GetAxis ("Mouse Y") * mouseY);
}


void flipScreen()
{
    Matrix4x4 mat = Camera.main.projectionMatrix;
    mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
    Camera.main.projectionMatrix = mat;
}


void playSoundWindows()
{

}

void playSoundNotification()
{

}

void swapKeys()
{

    
}


}
