using Cat;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PictureBookExplanation : MonoBehaviour
{
    //ê}ä”ÇÃê‡ñæ
    [SerializeField]
    [Space(25)]
    [Header("éOñ—îLÇÃê‡ñæUI")]
    private GameObject mikenekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("çïîLÇÃê‡ñæUI")]
    private GameObject kuronekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("ÉçÉ{îLÇÃê‡ñæUI")]
    private GameObject robonekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("Ç≥Ç©Ç»îLÇÃê‡ñæUI")]
    private GameObject sakananekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("è_ÇÁÇ©îLÇÃê‡ñæUI")]
    private GameObject yawarakanekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("ãïñ≥îLÇÃê‡ñæUI")]
    private GameObject kyomunekoExplanation;
    [SerializeField]
    [Space(25)]
    [Header("ê}ä”ÇÃê‡ñæUI")]
    private GameObject zukannUI;

    CatMove catMove;
    
    public void MikenekoIindication()
    {
        if (catMove.m_ZukanKaihou == true)
        {
            mikenekoExplanation.SetActive(true);
            zukannUI.SetActive(false);
        }
    }
    public void CloseMikeneko()
    {
        
        mikenekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
    public void KuronekoIindication()
    {
        kuronekoExplanation.SetActive(true);
        zukannUI.SetActive(false);
    }
    public void CloseKuroneko()
    {
        kuronekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
    public void RobonekoIindication()
    {
        robonekoExplanation.SetActive(true);
        zukannUI.SetActive(false);
    }
    public void CloseRobot()
    {
        robonekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
    public void SakananekoIindication()
    {
        sakananekoExplanation.SetActive(true);
        zukannUI.SetActive(false);
    }
    public void CloseSakananeko()
    {
        sakananekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
    public void YawarakanekoIindication()
    {
        yawarakanekoExplanation.SetActive(true);
        zukannUI.SetActive(false);
    }
    public void CloseYawarakaneko()
    {
        yawarakanekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
    public void KyomunekoIindication()
    {
        kyomunekoExplanation.SetActive(true);
        zukannUI.SetActive(false);
    }
    public void CloseKyomuneko()
    {
        kyomunekoExplanation.SetActive(false);
        zukannUI.SetActive(true);
    }
}
