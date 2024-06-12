using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    public Transform EndPosItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "s")
        {
            collision.gameObject.transform.position = EndPosItem.position;
        }
    }
}
