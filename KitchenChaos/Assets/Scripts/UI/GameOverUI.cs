using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliverdText;
    [SerializeField] Button mainMenuButton;


    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    private void Start()
    {
        KitchenGameManager.instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.instance.IsGameOver())
        {
            Show();
            recipesDeliverdText.text = DeliveryManager.Instance.GetSuccessfulRecipeAmount().ToString();
            mainMenuButton.Select();
        }
        else
        {
            Hide();
        }
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
