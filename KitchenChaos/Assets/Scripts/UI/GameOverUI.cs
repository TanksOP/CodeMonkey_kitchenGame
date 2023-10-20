using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliverdText;

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
