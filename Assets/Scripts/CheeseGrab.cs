using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseGrab : MonoBehaviour {

    public LayerMask charMask;

    void OnTriggerEnter2D(Collider2D mouse)
    {
        if (charMask == (charMask | 1 << mouse.gameObject.layer))
        {
            MouseControlScript enter = mouse.gameObject.GetComponent<MouseControlScript>();
            if (!enter.hasCheese)
            {
                enter.hasCheese = true;
                Destroy(gameObject);
            }
           
        }
    }
}
