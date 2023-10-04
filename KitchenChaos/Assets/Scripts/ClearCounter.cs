using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object here
            if (player.HasKitchenObject())
            {
                //player has an object                
                player.GetKitchenObject().SetKitchenObjectParent(this);
                
            }
            else
            {
                //player has nothing
            }
        }
        else{
            // there is a kitchen object here
            if (player.HasKitchenObject())
            {
                //player has an object

                KitchenObject oldKitchenObject = null;
                KitchenObject newKitchenObject = null;

                oldKitchenObject = GetKitchenObject();                
                newKitchenObject = player.GetKitchenObject();

                ClearKitchenObject();
                player.GetKitchenObject().SetKitchenObjectParent(this);
                oldKitchenObject.SetKitchenObjectParent(player);
                SetKitchenObject(newKitchenObject);

            }
            else
            {
                //player has nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }  
            
}
