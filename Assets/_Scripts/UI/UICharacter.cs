using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacter : MonoBehaviour
{
    [SerializeField] GameObject UiStatus;
    [SerializeField] List<StatusCustomer> listStatusCustomer;

    public StatusCustomer getUIStatus()
    {
        if (listStatusCustomer == null) return null;
        foreach (StatusCustomer uiStatus in listStatusCustomer)
        {
            if (uiStatus.HasCustomer == false)
            {
                return uiStatus;
            }
        }
        GameObject objStatus = Instantiate(UiStatus, this.transform);
        listStatusCustomer.Add(objStatus.GetComponent<StatusCustomer>());
        return listStatusCustomer[listStatusCustomer.Count - 1];
    }
}
