using UnityEngine;

public class Player : MonoBehaviour
{
    public float _jumpForce = 10f;
    public Rigidbody2D _body;
    Transform _pos;
    public string _currentColor;
    public SpriteRenderer _sprite;
    public Color _colorRed;
    public Color _colorGreen;
    public Color _colorPurple;
    public Color _colorYellow;
    void Start()
    {
        _pos = GetComponent<Transform>();
        SetRandomColor();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){_body.velocity = Vector2.up * _jumpForce;        }

        if (_pos.position.y < -1.5f){_pos.transform.position = new Vector3(0, -1.5f, 0);}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChange")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
                         
            if (collision.tag!=_currentColor)
            {
                Debug.Log("GAMEOVER!");
            }
}

    void SetRandomColor() 
    {
        int index = Random.Range(0, 4);       
                   
        switch (index)
        {
            case 0:
                _currentColor = "Red";
                _sprite.color = _colorRed;
                    break;
            case 1:
                _currentColor = "Green";
                _sprite.color = _colorGreen;
                break;
            case 2:
                _currentColor = "Purple";
                _sprite.color = _colorPurple;
                break;
            case 3:
                _currentColor = "Yellow";
                _sprite.color = _colorYellow;
                break;
        }
    }
}
