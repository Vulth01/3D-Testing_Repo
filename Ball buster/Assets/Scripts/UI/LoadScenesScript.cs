using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int nextScene;
    private int previousScene;
   
   void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        previousScene = SceneManager.GetActiveScene().buildIndex - 1;

    }
   public void LoadNextSceneFunction()
    {
   
        SceneManager.LoadScene(nextScene);
       
    }
    public void LoadPreviousSceneFunction()
    {
        SceneManager.LoadScene(previousScene);
    }
    public void quitFunction()
    {
        Application.Quit();
        
    }
    public void LoadSceneID(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
