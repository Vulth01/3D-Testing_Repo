using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    private Transform mainCam;
    public Transform optionsTrans;
    public Transform paddleTrans;
    public Transform startMenuTrans;
    private Transform DestinationVec2;
    private Transform previousSelectedVec2;
    public float speed = 1f;



    void Start()
    {
        DestinationVec2 = startMenuTrans;
        previousSelectedVec2 = startMenuTrans;
        mainCam = gameObject.transform;
    }

    public void SelectPaddle()
    {
        DestinationVec2 = paddleTrans;
        ButtonClicked = true;
    }
    public void SelectStart()
    {
        DestinationVec2 = startMenuTrans;
        ButtonClicked = true;
    }
    public void SelectOptions()
    {

        DestinationVec2 = optionsTrans;
        ButtonClicked = true;


    }
    float XThreshhold = 0.5f;
    public bool ButtonClicked = false;
    float lerpPerc = 0f;
    void Update()
    {


        if (previousSelectedVec2 != DestinationVec2)
        {
            if (ButtonClicked)
            {
                lerpPerc += speed * Time.deltaTime;
            }
            if (mainCam.position.x == DestinationVec2.position.x && mainCam.position.y == DestinationVec2.position.y && ButtonClicked)
            {
                ButtonClicked = false;
                previousSelectedVec2 = DestinationVec2;
                lerpPerc = 0f;

            }
        }
        mainCam.transform.position = Vector2.Lerp(previousSelectedVec2.position, DestinationVec2.position, lerpPerc); // because this actually still moves the z axis ....
        mainCam.transform.position = new Vector3(mainCam.position.x, mainCam.position.y, -20);//this  resets the z position so that it does'nt run away and look at nothing





    }
}
