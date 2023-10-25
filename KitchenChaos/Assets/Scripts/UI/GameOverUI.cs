using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliverdText;
    [SerializeField] Button mainMenuButton;
    private float delayTimerMax = 1f;
    private float delayTimer;


    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    private void Start()
    {
        delayTimer = delayTimerMax;
        KitchenGameManager.instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.instance.IsGameOver())
        {
            Show();
            recipesDeliverdText.text = DeliveryManager.Instance.GetSuccessfulRecipeAmount().ToString();
            mainMenuButton.interactable = false;
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        if (KitchenGameManager.instance.IsGameOver())
        {
            delayTimer -= Time.deltaTime;
            if(delayTimer <= 0)
            {
                mainMenuButton.Select();
                mainMenuButton.interactable = true;
            }
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
