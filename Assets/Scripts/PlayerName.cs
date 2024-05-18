using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SyncVar(hook = nameof(HandleName))] private string _playerName;
    private string Name => _playerName;


    private void HandleName(string oldText, string newText)
    {
        _text.text = $"Player: {_playerName}";
    }

    public override void OnStartServer()
    {
        _playerName = connectionToClient.connectionId.ToString();
    }
}
