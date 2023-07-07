using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusNamespace
{
    public class VerticalMovement : MonoBehaviour
    {
        
        //public float distanceLow, distanceHigh, speedLow, speedHigh;
        [SerializeField]private float t = 0.0f;
        public float distance, speed, timeStart;
        private float originalPosY;
        [SerializeField] private float playSFXTreshold;

        void Start()
        {
            originalPosY = transform.position.y;

        }

        void Update()
        {
            transform.position = new Vector3(transform.position.x, originalPosY + Mathf.Sin(t) * distance, transform.position.z);
            t += speed * Time.deltaTime;
            if(transform.position.y < playSFXTreshold && GetComponent<AudioSource>()!=null && GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }
        }
    }
}
