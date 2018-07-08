using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_bomb_flashing : MonoBehaviour
{

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool camera = false;
    public float flashingCount;
    float oldFlashingCount;
    float red, green, blue, alfa;
    Renderer rend;
    Quaternion rot;

    void Start()
    {
        flashingCount = 90;
        red = 255;
        green = 255;
        blue = 255;
        alfa = 0;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rot = this.transform.rotation;
        float y = rot.eulerAngles.x;
        if (camera && y == 270 && flashingCount > -30)
        {
            flashingCount--;
        }

        if(flashingCount > 0)
        {
            if (flashingCount <=89  && flashingCount >= 60)
            {
                alfa = 150;
            }
            else if (flashingCount <= 40 && flashingCount >= 20)
            {
                alfa = 150;
            }
            else if (flashingCount <= 10 && flashingCount >= 1)
            {
                alfa = 150;
            }
            else alfa = 0;
            rend.material.color = new Color(red, green, blue, alfa);
        }

        if (flashingCount <= 0 && flashingCount > -30)
        {
            alfa = 255;
            rend.material.color = new Color(red, green, blue, alfa);
            //if(flashingCount == -30)
            //{
            //    Destroy(this.gameObject);
            //}
            //    //GetComponent<CapsuleCollider>().enabled = true;
            //    //Destroy(this.gameObject);
            //    //Destroy(this.player);
            //    //Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);
            //    //Instantiate(Explosionrange, ExploadPos.transform.position, Quaternion.identity);
        }
    }

    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけcameraを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            camera = true;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
