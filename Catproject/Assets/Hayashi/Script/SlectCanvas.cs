using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlectCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SelectCanvs;
    [SerializeField]
    private GameObject m_TitleCanvas;
    public void SelectCanvasOpen()
    {
        m_SelectCanvs.SetActive(true);
        m_TitleCanvas.SetActive(false);
    }
}
