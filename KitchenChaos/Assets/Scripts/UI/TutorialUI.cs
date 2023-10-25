using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;


    private void Start()
    {
        GameInput.instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();

        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.instance.IsCountDownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        keyPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
        keyGamepadInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
