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
    public static CardManager Instance;
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }
    public void SpawnCard()
    {
        int card = Random.Range(0,3);
        GameObject csgo = Instantiate(Cards[card], new Vector3(0,1,0), Quaternion.identity, transform);
        CardScript cs = csgo.GetComponent<CardScript>(); // I hate this
        switch(card)
        {
            case 0:
                cs.cso = OilCards[Random.Range(0,OilCards.Count)];
            break;
            case 1:
                cs.cso = TeleCards[Random.Range(0,TeleCards.Count)];
            break;
            case 2:
                cs.cso = WarCards[Random.Range(0,WarCards.Count)];
            break;
            case 3:
                cs.cso = BankCards[Random.Range(0,BankCards.Count)];
            break;
        }
        cs.Text.text = cs.cso.CardText;
    }
}
