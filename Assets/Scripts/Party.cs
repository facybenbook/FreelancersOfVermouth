using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<PartyMember> party = new List<PartyMember>();

    void Start()
    {
        GameObject characters = GameObject.FindGameObjectWithTag("Characters");
        party.AddRange(characters.GetComponentsInChildren<PartyMember>());
        SelectPartyMember();
    }

    public void SelectPartyMember(PartyMember memberToSelect = null)
    {
        Debug.Log("in SelectPartyMember");
        foreach (PartyMember partyMember in party)
        {
            if (partyMember == memberToSelect) 
            {
                partyMember.Select();
            } else
            {
                partyMember.Deselect();
            }
        }
    }
}
