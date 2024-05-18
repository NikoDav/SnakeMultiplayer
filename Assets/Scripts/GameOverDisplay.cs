using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _text;
    
    void Start()
    {
        GameOverHandler.ClientOnGameOver += ClientHandlerGameOver;
    }

    private void OnDestroy()
    {
        GameOverHandler.ClientOnGameOver -= ClientHandlerGameOver;
    }

    private void ClientHandlerGameOver(string name)
    {
        _canvas.gameObject.SetActive(true);
        _text.text = $"{name} wins";
    }

    public void RestartGame()
    {
        if(NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
            _canvas.gameObject.SetActive(false);
        }
        else
        {
            NetworkManager.singleton.StopClient();
            _canvas.gameObject.SetActive(false);
        }
    }

    
}
