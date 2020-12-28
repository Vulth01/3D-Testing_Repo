using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("public components to be cached")]
    public SpriteRenderer obstacleRenderer;

    public TextMeshProUGUI textMeshProUGUI;

    public audioManagerScript audiomanager;

    public int obstacleLives = 5;



    // private float colorChangeRatio;

    public void SetUpFunct()
    {
        obstacleRenderer = GetComponent<SpriteRenderer>();//some of my most satisfying code yet is seeing this cache work first try
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        audiomanager = FindObjectOfType<audioManagerScript>();
        textMeshProUGUI.text = obstacleLives.ToString();
    }

    public void PlayCollisionSound(Collision2D collisionInfo)
    {
        if (obstacleLives > 1 && collisionInfo.collider.tag == "Ball")
        {

            audiomanager.Play("boom");//plays boom on hit using audio manager every time the blueball hits it and the lives are above 1 because the boom cant play when the pop plays
        }
        if (collisionInfo.collider.tag == "Ball" && obstacleLives > 0)
        {
            Debug.Log("hit");
            obstacleLives -= 1;
            textMeshProUGUI.text = obstacleLives.ToString();//displays the obstaclelives on the respective obstacle
                                                            // obstacleRenderer.color = new Color(obstacleRenderer.color.r,obstacleRenderer.color.g,obstacleRenderer.color.b,1-colorChangeRatio);
                                                            //            Debug.Log(obstacleRenderer.color*colorChangeRatio);

        }
        if (obstacleLives == 0)
        {
            audiomanager.Play("pop");
            Destroy(gameObject);
        }

    }


}
