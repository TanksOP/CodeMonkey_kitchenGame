using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO() 
    { 
        return kitchenObjectSO; 
    } 

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent){

        if (this.kitchenObjectParent != null) 
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchinObject())
        {
            Debug.LogError("Kitchen object parent allready has a kitchen object");
        }
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetkitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
