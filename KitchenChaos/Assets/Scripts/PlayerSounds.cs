using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public static event EventHandler OnPlayerFootstep;

    private Player player;
    private float footstepTimer;
    private float footstepTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0f)
        {
            footstepTimer = footstepTimerMax;
            if (player.IsWalking())
            {
                OnPlayerFootstep?.Invoke(this, EventArgs.Empty);
            }
            
        }
    }

}
