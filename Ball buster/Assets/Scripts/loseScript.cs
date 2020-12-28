using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loseScript : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField]
    private int lives;
    [SerializeField]
    private float deathThreshold = 1.2f;
    public Transform playerTransform;
    public Transform centreTransform;
    public Transform ballTransform;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //checking if the ball exists, if it does i am checking if the distance between the centre and player * death threshold is further than the distance between the ball and the centre 
        if (ballTransform == true && Vector2.Distance(centreTransform.position, playerTransform.position) * deathThreshold < (Vector2.Distance(centreTransform.position, ballTransform.position)))
        {
            StartCoroutine(GameRestartCoroutine());
        }




    }

    [SerializeField]
    private float GameRestartDeleay = 2;
    IEnumerator GameRestartCoroutine()
    {
        yield return new WaitForSeconds(GameRestartDeleay);
        restartgame();


    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
