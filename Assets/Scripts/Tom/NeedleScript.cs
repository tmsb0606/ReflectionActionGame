using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("����");
            collision.gameObject.SetActive(false);
        }
    }
}
