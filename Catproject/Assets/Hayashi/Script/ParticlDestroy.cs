using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

}
