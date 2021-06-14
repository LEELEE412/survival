using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Serializable]
    public class RequiredItem
    {
        [SerializeField] 
        public string name;
        [SerializeField] 
        public int count;
    }
    [SerializeField] 
    List<RequiredItem> Requireditem;
    public GameObject TargetObject;
    private Inventory theInven;
    private bool isItemCheck = false;
    private bool isInventoryCheck = true;
    void Start()
    {
        theInven = FindObjectOfType<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!isItemCheck)
            {
                for (int i = 0; i < Requireditem.Count; i++)
                {
                    Debug.Log(theInven.GetItemCount(Requireditem[i].name));
                    Debug.Log(Requireditem[i].count);
                    if (theInven.GetItemCount(Requireditem[i].name) < Requireditem[i].count)
                    {
                        isInventoryCheck = false;
                    }
                }
                if(isInventoryCheck)
                    other.transform.position = TargetObject.transform.position;
                
                isInventoryCheck = true;
            }
        }
    }
}