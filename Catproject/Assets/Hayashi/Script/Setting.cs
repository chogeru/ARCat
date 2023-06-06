using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject title;
    public GameObject volume;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void VolumeSetting()
    {
        title.SetActive(false);
        volume.SetActive(true);

    }
    public void GoTitle()
    {
        title.SetActive(true);
        volume.SetActive(false);

    }
}
