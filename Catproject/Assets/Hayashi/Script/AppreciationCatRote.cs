using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppreciationCatRote : MonoBehaviour
{
    private float catRotate=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(500, 498, 508);
        transform.rotation = Quaternion.Euler(catRotate, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        catRotate += Time.deltaTime;
    }
}
