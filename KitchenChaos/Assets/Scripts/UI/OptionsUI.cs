using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] Button musicButton;
    [SerializeField] Button soundEffectButton;
    [SerializeField] Button closeButton;
    [SerializeField] TextMeshProUGUI musicText;
    [SerializeField] TextMeshProUGUI soundEffectText;

    private void Awake()
    {
        Instance = this;

        soundEffectButton.onClick.AddListener(() =>
        {
            SoundManager.instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });


    }

    private void Start()
    {
        KitchenGameManager.instance.OnGameUnPaused += KitchenGameManager_OnGameUnPaused;

        UpdateVisual();
        Hide();
    }

    private void KitchenGameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectText.text = "Sound Effects: " + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.instance.GetVolume() * 10f);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
