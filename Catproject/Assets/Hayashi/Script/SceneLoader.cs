using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public void ClickStartButton()
        {
            SceneManager.LoadScene("HayashiTest");
        }
        public void GoEndressMode()
        {
            SceneManager.LoadScene("EndlessScene");
        }
        public void GoTitleScene()
        {
            SceneManager.LoadScene("Title");
        }
    }
}