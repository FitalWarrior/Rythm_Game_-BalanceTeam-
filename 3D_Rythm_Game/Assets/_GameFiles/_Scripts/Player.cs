using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

    int _gemCount;
    public Text _gemText;

    public ParticleSystem _flash;

    public GameObject _playerScript;

    public AudioSource _audioSource;
    public AudioClip _shotClip;

    private int _hp = 2;
    public Image _hpIcon;


    public GameObject _restartPanel;
    public GameObject _WinPanel;
    void Start()
    {
        _pos = GetComponent<Transform>();
        SetRandomColor();
        _flash.startColor = _sprite.color;
        LoadGame();


    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) { _body.velocity = Vector2.up * _jumpForce; }

        if (_pos.position.y < -1.5f) { _pos.transform.position = new Vector3(0, -1.5f, 0); }
        _gemText.text = _gemCount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChange")
        {
            SetRandomColor();
            _flash.startColor = _sprite.color;
            Destroy(collision.gameObject);
            return;
        }


        if (collision.tag == "Gem")
        {
            _gemCount += 1;
            _gemText.text = _gemCount.ToString();
            SaveGame();
            Debug.Log("LevelComplate");
            Destroy(collision.gameObject);
            _WinPanel.SetActive(true);
            _audioSource.enabled = false;
            return;
        }

        if (collision.tag != _currentColor)
        {
            _hp -= 1;
            _audioSource.PlayOneShot(_shotClip);
            Instantiate(_flash, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(_hpIcon);
            if (_hp <= 0)
            {
                _playerScript.SetActive(false);
                _restartPanel.SetActive(true);
                Debug.Log("GAMEOVER!");
            }

        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 3);

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

    public void SaveGame()
    {
        string key = "GameData";
        PlayerPrefs.SetInt(key, _gemCount);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        string key = "GameData";
        if (PlayerPrefs.HasKey(key))
        {
            _gemCount = PlayerPrefs.GetInt(key);
            PlayerPrefs.Save();
        }

    }

    private void OnApplicationQuit()
    {
        string key = "GameData";
        PlayerPrefs.SetInt(key,_gemCount);
        PlayerPrefs.Save();
    }


}
