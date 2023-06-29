using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{
    
    public float deleteTime = 3.0f;
    // Start is called before the first frame update
    void Awake()
    {
        //CatFood‚ğíœ‚·‚é
        Destroy(gameObject,deleteTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉCatƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collision.gameObject.tag == "Cat")
        {
         
            //Á‚¦‚é
            Destroy(gameObject);
        }
    }
}
