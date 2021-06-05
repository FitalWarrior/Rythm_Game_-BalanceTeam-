using UnityEngine;
using UnityEngine.UI;

public class FolowPlayer : MonoBehaviour
{
    public Transform _playerPos;
    public GameObject _gameOverPoint;
    public GameObject _restartPanel;
   

    private void Update()
    {
        if (_playerPos.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _playerPos.position.y, transform.position.z);

        }

        if (_playerPos.position.y < _gameOverPoint.transform.position.y)
        {
            _restartPanel.SetActive(true);
            Debug.Log("GAMEOVER!");            
        }

        
    }

}
