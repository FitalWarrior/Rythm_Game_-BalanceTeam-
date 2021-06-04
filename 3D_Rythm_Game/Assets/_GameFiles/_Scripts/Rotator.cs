using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float _speed = 100f;

    private void Update()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }
}
