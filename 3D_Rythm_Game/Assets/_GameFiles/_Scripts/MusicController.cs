using UnityEngine.UI;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] _clips;
    public Text[] _text;

    public AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }
       

    public void Clip0() 
    {
        _audioSource.clip = _clips[0];
        _text[0].text = _clips[0].name;
    }
    public void Clip1()
    {
        _audioSource.clip = _clips[1];
        _text[1].text = _clips[1].name;

    }
    public void Clip2()
    {
        _audioSource.clip = _clips[2];
    }
    public void Clip3()
    {
        _audioSource.clip = _clips[3];
    }
    public void Clip4()
    {
        _audioSource.clip = _clips[4];
    }
    public void Clip5()
    {
        _audioSource.clip = _clips[5];
    }
}
