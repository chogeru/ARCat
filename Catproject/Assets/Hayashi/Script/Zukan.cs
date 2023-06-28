using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zukan : MonoBehaviour
{
    public GameObject zukan;
    public GameObject zukanGoButtan;
    public GameObject shooter;
    public GameObject closebutton;
    public GameObject zukanUI;
    public GameObject gameUI;
    public void Start()
    {
        zukan.SetActive(false);
        zukanGoButtan.SetActive(true);
        shooter.SetActive(true);
        
    }
    public void GoZukan()
    {
        zukanUI.SetActive(true);
        zukan.SetActive(true);
        zukanGoButtan.SetActive(false);
        shooter.SetActive(false);
        closebutton.SetActive(false);
    }

    public void GoGame()
    {
        gameUI.SetActive(true);
        zukanUI.SetActive(false);
        zukan.SetActive(false);
        zukanGoButtan.SetActive(true);
        shooter.SetActive(true);
    }
}
