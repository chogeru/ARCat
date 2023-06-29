using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class ARTestScript : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] GameObject placementPrefab;
    ARPlaneManager planeManager;
    ARRaycastManager raycastManager;
    PlayerInput playerInput;
    bool isReady;
   
    // Start is called before the first frame update
    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        playerInput = GetComponent<PlayerInput>();
        raycastManager = GetComponent<ARRaycastManager>();
    }
    GameObject instantiatebObject = null;
    void OnTouch(InputValue touchInfo)
    {
        var touchPosition = touchInfo.Get<Vector2>();
        var hits = new List<ARRaycastHit>();
        if(raycastManager.Raycast(touchPosition,hits,
            TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(instantiatebObject==null)
            {
                {
                    instantiatebObject = Instantiate(placementPrefab,
                    hitPose.position, hitPose.rotation);
                }
            }
            else
            {
                instantiatebObject.transform.position = hitPose.position;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
