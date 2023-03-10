using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerController playerController;
    public PlayerMover playerMover;
    public PlayerShooter playerShooter;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput.onInputStateChanged += playerController.processInputState;
        playerController.onPlayerStateChanged += playerMover.processPlayerState;
        playerController.onPlayerStateChanged += playerShooter.processPlayerStateChanged;
    }
}
