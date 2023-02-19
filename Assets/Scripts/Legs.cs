using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    bool isTouchingGround;

    public bool GetIsTouchingGround()
    {
        return isTouchingGround;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGround = false;
    }
}
