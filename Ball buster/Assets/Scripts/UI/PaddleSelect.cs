using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleSelect : MonoBehaviour
{

    private int selectedPad = 0;

    Image[] paddleImages;



    GameObject PaddlesObj;
    private readonly int distance = 460;


    private Vector2 DestinationVec2;
    private Vector2 previousSelectedVec2;
    bool ButtonClicked = false;
    float lerpPerc = 0f;
    private readonly float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        selectedPad = 0;
        PaddlesObj = gameObject;

        paddleImages = GetComponentsInChildren<Image>();




        previousSelectedVec2 = PaddlesObj.transform.position;
        DestinationVec2 = PaddlesObj.transform.position;

    }

    // Update is called once per frame

    void Update()
    {
        if (ButtonClicked)
        {
            if (previousSelectedVec2 != DestinationVec2)
            {

                lerpPerc += speed * Time.deltaTime;

                if (lerpPerc > 0.99)//this fix moves the item until lerp percent is 0.99 and then snaps to the exact position (change  to 0.5 to see example)
                {
                    ButtonClicked = false;

                    previousSelectedVec2 = DestinationVec2;
                    lerpPerc = 0f;

                }

            }
        }

        PaddlesObj.transform.localPosition = Vector2.Lerp(previousSelectedVec2, DestinationVec2, lerpPerc);


    }
    public void LeftClick()
    {
        if (!ButtonClicked)
        {


            selectedPad -= 1;
            DestinationVec2 = new Vector2(PaddlesObj.transform.localPosition.x + distance, PaddlesObj.transform.position.y);

            ButtonClicked = true;
            revealPaddle();
        }

        //change the paddle displayed
    }
    public void RightClick()
    {
        if (!ButtonClicked)
        {
            selectedPad += 1;

            DestinationVec2 = new Vector2(PaddlesObj.transform.localPosition.x - distance, PaddlesObj.transform.position.y);
            ButtonClicked = true;
            revealPaddle();
        }
        //change the paddle displayed

    }
    void revealPaddle()
    {


        if (paddleImages.Length > selectedPad + 1)//check the sketchy math on this one
        {
            Debug.Log(paddleImages[selectedPad + 1].name + "    -alpha");
            paddleImages[selectedPad + 1].color = new Color(paddleImages[selectedPad + 1].color.r, paddleImages[selectedPad + 1].color.g, paddleImages[selectedPad + 1].color.b, paddleImages[selectedPad + 1].color.a - 0.5f);
        }
        if (paddleImages.Length >= selectedPad)
        {
            Debug.Log(paddleImages[selectedPad].name + "    +alpha");
            paddleImages[selectedPad].color = new Color(paddleImages[selectedPad].color.r, paddleImages[selectedPad].color.g, paddleImages[selectedPad].color.b, paddleImages[selectedPad].color.a + 0.5f);
        }
        if (selectedPad > 0)
        {
            Debug.Log(paddleImages[selectedPad - 1].name + "    -alpha");
            paddleImages[selectedPad - 1].color = new Color(paddleImages[selectedPad - 1].color.r, paddleImages[selectedPad - 1].color.g, paddleImages[selectedPad - 1].color.b, paddleImages[selectedPad - 1].color.a - 0.5f);

        }


    }
    public void SelectPaddle()//called on button clicked to set the paddle
    {


        Debug.Log("selected");
        PlayerPrefs.DeleteKey("paddleSelected");
        PlayerPrefs.SetInt("paddleSelected", selectedPad);
    }
}

