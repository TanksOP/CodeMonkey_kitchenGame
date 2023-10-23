using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundEffectText;

    // Keybindings
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;

    [SerializeField] private Transform pressToRebindKeyTransform;


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


        // Rebinding keys button presses
        moveUpButton.onClick.AddListener(() =>{RebindBinding(GameInput.Binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact_Alternate); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
        


    }

    private void Start()
    {
        KitchenGameManager.instance.OnGameUnPaused += KitchenGameManager_OnGameUnPaused;

        UpdateVisual();
        HidePressToRebindKey();
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

        moveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        pauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.instance.RebindBinding(binding, () => { 
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
