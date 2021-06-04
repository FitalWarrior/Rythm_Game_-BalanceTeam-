using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _cubes;
    public Transform[] _points;
    public float _beatpersec = (60/85)*2;
    private float _timer;
    
        
    void Update()
    {
        if (_timer>_beatpersec)
        {
            GameObject cube = Instantiate(_cubes[Random.Range(0, 2)], _points[Random.Range(0, 3)]);
            cube.transform.localPosition = Vector2.zero;
            _timer -= _beatpersec;
        }
        _timer += Time.deltaTime;
    }
}
