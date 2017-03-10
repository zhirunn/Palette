using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWarning : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //GUI Warning maybe?
        print("Cannot return!");
    }
}
