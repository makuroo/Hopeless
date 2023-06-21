using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTransformData", menuName = "TransformData")]
public class TransformData : ScriptableObject
{
    public Vector2 position;
    public Vector2 playerInitialPosition;

    //panggil jika kena finish
    public void ResetData()
    {
        position = Vector2.zero;
    }
}
