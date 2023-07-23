using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using SimpleMan.CoroutineExtensions;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayableDirector ending;
    int i = 0;
    void OnEnable()
    {
        CardScript.OnCardGoneEvent += CardGone;
    }
    void OnDisable()
    {
        CardScript.OnCardGoneEvent -= CardGone;
    }
    void CardGone()
    {
        if(i < 12)
            this.Delay(10f, () => CardManager.Instance.SpawnCard());
        else
            ending.Play();
        i++;
    }
}
