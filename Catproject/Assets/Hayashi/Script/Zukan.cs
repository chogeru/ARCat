using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zukan : MonoBehaviour
{
    public GameObject zukan;
    public GameObject zukanGoButtan;
    public GameObject shooter;
    public void Start()
    {
        zukan.SetActive(false);
        zukanGoButtan.SetActive(true);
        shooter.SetActive(true);
    }
    public void GoZukan()
    {
        zukan.SetActive(true);
        zukanGoButtan.SetActive(false);
        shooter.SetActive(false);
    }

    public void GoGame()
    {
        zukan.SetActive(false);
        zukanGoButtan.SetActive(true);
        shooter.SetActive(true);
    }
}
