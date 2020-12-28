using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject ShopUI;
    public int Level1Scene;
    // Start is called before the first frame update
    [SerializeField] private GameObject GameUI;

    private playerController player;
    void Awake() 
    {
        player = FindObjectOfType<playerController>(); 
    }
  public void  OnResumeClick()
    {
        
        MenuUI.SetActive(false);
        GameUI.SetActive(true);

    }
    public void OnPauseClick() 
    {
        GameUI.SetActive(false);
        MenuUI.SetActive(true);
       
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene(Level1Scene);
    }
    public void OnOptionsClick()
    {
        MenuUI.SetActive(false);
        OptionsUI.SetActive(true);
    }
    public void OnBackClick()
    {
        
        OptionsUI.SetActive(false);
        MenuUI.SetActive(true);
    }
    public void OnShopClick()
    {
        if (ShopUI.activeSelf)
        {
            ShopUI.SetActive(false);
            Debug.Log("close shop");
           
        }
        else
        {
            ShopUI.SetActive(true);
            Debug.Log("openShop");
        }
       
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
