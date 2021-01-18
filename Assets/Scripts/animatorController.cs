using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    private Animator ani;

    public Animator door;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            ani.SetTrigger("Player");
            door.SetTrigger("Down");
        }
    }
}
