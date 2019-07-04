using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<PartyMember> party = new List<PartyMember>();

    void Start()
    {
        Debug.Log("lets party");
        GameObject characters = GameObject.FindGameObjectWithTag("Characters");
        party.AddRange(characters.GetComponentsInChildren<PartyMember>());

        Debug.Log(party.Count);

        foreach (PartyMember partyMember in party)
        {
            Debug.Log("party member");
        }

    }

    void Update()
    {
        
    }
}
