using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _movePlayer : MonoBehaviour
{
    public float _minPos;
    public float _maxPos;

    void Update() 
    {
        if (Input.GetKeyDown("d"))
        {
            transform.position = new Vector3(_maxPos, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("a"))
        {
            transform.position = new Vector3(_minPos, transform.position.y, transform.position.z);
        }
    }
}
