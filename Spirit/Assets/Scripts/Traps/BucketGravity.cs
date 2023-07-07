using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketGravity : MonoBehaviour
{

    public float gravity = -10f;
    public float maxFallSpeed = -50f;
    public float groundY = 0f; //nilai position y object saat menyentuh ground

    private Vector3 velocity = Vector3.zero;
    public bool isGrounded = false;
    public Vector2 initialPosition;
    [SerializeField] private float seconds;

    private void Start()
    {
        transform.position = initialPosition;
    }

    void FixedUpdate()
    {
        ApplyGravity();
        Move();
        Grounded();
    }

    void ApplyGravity()
    {
        if (!isGrounded)
        {
            velocity.y += gravity* Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y, maxFallSpeed, Mathf.Infinity);
        }
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
        Debug.Log(velocity);
    }

    void Grounded()
    {
        if (transform.position.y <= groundY)
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
            Return();
        }
    }

    void Return()
    {
        if (isGrounded)
        {
            enabled = false;
            isGrounded = false;
            velocity = Vector2.zero;
            StartCoroutine(Delay(seconds));
        }
    }

    private IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.position = initialPosition;
    }
}
