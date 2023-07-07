using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrapPositionHandler : MonoBehaviour
{
    Transform trapTransform;
    Vector3 initialPosition;
    BucketGravity gravity;
    // Start is called before the first frame update
    void Start()
    {
        trapTransform = GetComponent<Transform>();
        initialPosition = trapTransform.position;
        gravity = GetComponent<BucketGravity>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
