using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintManager : MonoBehaviour
{
    public GameObject hint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            hint.SetActive(false);
        }
    }
}
