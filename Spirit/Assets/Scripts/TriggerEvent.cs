using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish,
    Trigger,
}
public class TriggerEvent : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> OnTrigger;
    public bool isGameManager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag.ToString())
        {
            Debug.Log(gameObject.tag + " Kena! " + col.gameObject.tag);
            OnTrigger?.Invoke(col.gameObject);
        }

        if (gameObject.CompareTag("Checkpoint"))
        {
           gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        }
    }

}
