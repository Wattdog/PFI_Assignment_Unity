using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowWorld : MonoBehaviour
{
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    private Camera cam;
    public GameObject uiText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        uiText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if (transform.position != pos)
            transform.position = pos;

        if (!lookAt.gameObject.activeInHierarchy)
            uiText.SetActive(false);
    }
}
