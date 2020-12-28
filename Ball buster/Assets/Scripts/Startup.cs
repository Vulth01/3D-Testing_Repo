using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Startup : MonoBehaviour
{
    [Header("components for initialising player and its paddle")]
    [SerializeField]
    private Transform PlayerTrans;
    [SerializeField]
    private Transform centreTransform;

    [Header(" array of paddles available ")]
    public paddle[] arrPaddles;

    // public TextAsset paddleTextFile;

    private int selectedPaddle;

    private GameObject paddleObj;

    string filePath, fileName;

    string[] arrTextFile;
    // Start is called before the first frame update
    void Start()
    {
        fileName = "paddles.txt";
        filePath = Application.dataPath + "/utilities/" + "TextFiles/" + fileName;

        selectedPaddle = PlayerPrefs.GetInt("paddleSelected");

        paddleObj = arrPaddles[selectedPaddle].PaddleObj;

        arrTextFile = File.ReadAllLines(filePath);

        int i = 0;
        foreach (string line in arrTextFile)
        {
            Debug.Log(line);
            if (line.Substring(2, 1) == "T")
            {
                arrPaddles[i].Unlocked = true;
            }
            else if (line.Substring(2, 1) == "F")
                arrPaddles[i].Unlocked = false;
            i++;
        }

        GameObject paddleInstance = Instantiate(paddleObj, Vector3.zero, Quaternion.identity, PlayerTrans);
        paddleInstance.transform.localPosition = Vector3.zero;

        //  paddleInstance.GetComponent<movement>().Initialize(centreTransform);// give the dependancies, death to singletons(even though i dont really use them all that much)




    }

    // Update is called once per frame
    void Update()
    {

    }

}
[System.Serializable]
public class paddle
{

    public static int numPaddles = 5;
    public GameObject PaddleObj;
    public bool Unlocked = false;
    public bool paddleSpeed;



}

