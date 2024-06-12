using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPos : MonoBehaviour
{
    public bool r1_c1, r1_c2, r1_c3, r1_c4, r1_c5;
    public bool r2_c1, r2_c2, r2_c3, r2_c4, r2_c5;
    public bool r3_c1, r3_c2, r3_c3, r3_c4, r3_c5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "s")
        {
            if (r1_c1)
            {
                FindAnyObjectByType<AppControl>().r1_c1s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r1_c2)
            {
                FindAnyObjectByType<AppControl>().r1_c2s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r1_c3)
            {
                FindAnyObjectByType<AppControl>().r1_c3s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r1_c4)
            {
                FindAnyObjectByType<AppControl>().r1_c4s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r1_c5)
            {
                FindAnyObjectByType<AppControl>().r1_c5s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r2_c1)
            {
                FindAnyObjectByType<AppControl>().r2_c1s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r2_c2)
            {
                FindAnyObjectByType<AppControl>().r2_c2s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r2_c3)
            {
                FindAnyObjectByType<AppControl>().r2_c3s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r2_c4)
            {
                FindAnyObjectByType<AppControl>().r2_c4s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r2_c5)
            {
                FindAnyObjectByType<AppControl>().r2_c5s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r3_c1)
            {
                FindAnyObjectByType<AppControl>().r3_c1s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r3_c2)
            {
                FindAnyObjectByType<AppControl>().r3_c2s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r3_c3)
            {
                FindAnyObjectByType<AppControl>().r3_c3s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r3_c4)
            {
                FindAnyObjectByType<AppControl>().r3_c4s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
            if (r3_c5)
            {
                FindAnyObjectByType<AppControl>().r3_c5s = collision.gameObject.GetComponent<Image>().sprite.name;
            }
        }
    }
}
