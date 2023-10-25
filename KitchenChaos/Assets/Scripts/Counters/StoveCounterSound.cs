using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{

    [SerializeField] private StoveCounter stoveCounter;
    private AudioSource audioSouce;
    private float warningSoundTimer;
    bool playWarningSound;

    private void Awake()
    {
        audioSouce = GetComponent<AudioSource>();
    }

    private void Start()
    {
        stoveCounter.OnStoveStateChanged += StoveCounter_OnStoveStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;
        playWarningSound = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
    }

    private void StoveCounter_OnStoveStateChanged(object sender, StoveCounter.OnStoveStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if (playSound)
        {
            audioSouce.Play();
        }
        else
        {
            audioSouce.Pause();
        }
    }

    private void Update()
    {
        if (playWarningSound)
        {
            warningSoundTimer -= Time.deltaTime;
            if (warningSoundTimer <= 0)
            {
                float warningSoundTimerMax = .2f;
                warningSoundTimer = warningSoundTimerMax;

                SoundManager.instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }
        
    }
}
