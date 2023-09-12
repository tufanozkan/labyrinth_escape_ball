using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = target.position + distance;
    }
}
