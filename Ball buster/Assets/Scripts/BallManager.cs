using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform centerTrans;
    public Transform playerTrans;
    public Rigidbody2D ballBody;
    public Ball ballScript;
    public TextMeshProUGUI CountdownText;
    [SerializeField]
    private float startSpeed = 600f;

    public GameObject NewBallObject;
    void Start()
    {
        ballScript = FindObjectOfType<Ball>();
        StartCoroutine(ballStartcoroutine());

    }

    [SerializeField]
    private int BallStartDelay = 5;


    IEnumerator ballStartcoroutine()
    {

        yield return new WaitForSeconds(1);

        for (int i = BallStartDelay; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1);

        }
        CountdownText.text = "Start";

        yield return new WaitForSeconds(1);
        CountdownText.enabled = false;
        ballScript.enabled = false;
        Vector2 direction = (playerTrans.position - centerTrans.position);
        direction.Normalize();
        ballBody.AddForce((direction) * startSpeed);



    }
    // Update is called once per frame
    void Update()
    {

    }
}
