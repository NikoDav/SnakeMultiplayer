using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class PlayerCameraControl : NetworkBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    public override void OnStartAuthority()
    {
        _camera.gameObject.SetActive(true);
    }
}
