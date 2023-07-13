using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Camera
{
    public class GameCamera : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] GameObject mainCamera;
        [Space(10)]
        [SerializeField] GameObject mayhouseCamera;
        // Start is called before the first frame update
        void Start()
        {
            mainCamera.SetActive(true);
            mayhouseCamera.SetActive(false);
        }

   
        public void GoMyHouse()
        {
            mainCamera.SetActive(false);
            mayhouseCamera.SetActive(true);
        }
        public void GameScene()
        {
            mainCamera.SetActive(true);
            mayhouseCamera.SetActive(false);
        }
    }
}