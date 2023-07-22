using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // spawn cards
    // oil cards, telecommunication cards, war cards, banking cards.

    // "missions"
    [SerializeField] List<GameObject> Cards;
    [SerializeField] List<CardScriptableObject> OilCards;
    [SerializeField] List<CardScriptableObject> TeleCards;
    [SerializeField] List<CardScriptableObject> WarCards;
    [SerializeField] List<CardScriptableObject> BankCards;

    [SerializeField] List<List<CardScriptableObject>> CardSO; 

    void Start()
    {
        GameObject csgo = Instantiate(Cards[0], new Vector3(0,1,0), Quaternion.identity, transform);
        CardScript cs = csgo.GetComponent<CardScript>(); // I hate this
        cs.cso = OilCards[0];
        cs.Text.text = cs.cso.CardText;
    }
}
