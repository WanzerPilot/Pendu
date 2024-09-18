using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] int maxProfiles = 3;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] RectTransform slotParent;
    List <ProfileSlotController> slots;


    private void Start()
    {
        CreateSlot();
        AssignsSlotProfiles();
    }
    void CreateSlot()
    {
        slots = new List <ProfileSlotController>();
        
        for (int i = 0; i < maxProfiles; i++)
        {
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(slotParent, false);
            ProfileSlotController slotCtrl = slotInstance.GetComponent<ProfileSlotController>();
            slots.Add(slotCtrl);

        }
    }

    void AssignsSlotProfiles()
    {
        List<string> profilesList = UserHolder.Instance.GetAllProfiles();
        for (int i = 0; i < maxProfiles; i++)
        {
            if (i > profilesList.Count -1) break;
            slots[i].SetProfile(profilesList[i]);
        }
    }

}
