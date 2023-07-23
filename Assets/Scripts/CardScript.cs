using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardScript : MonoBehaviour
{
    public delegate void OnCardGone();
    public static OnCardGone OnCardGoneEvent;

    [SerializeField] RectTransform Rect;
    [SerializeField] GameObject Card;
    Vector3 offset;
    Plane dragPlane;
    public TMP_Text Text;
    public CardScriptableObject cso;

    void OnMouseDown()
    {
        dragPlane = new Plane(ChoicesManager.Instance.maincamera.transform.forward, transform.position); 
        Ray camRay = ChoicesManager.Instance.maincamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }
    void OnMouseDrag()
    {   
        Ray camRay = ChoicesManager.Instance.maincamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }
    void OnDisable()
    {
        OnCardGoneEvent?.Invoke();
    }
    void OnMouseUp()
    {
        if(Rect.Overlaps(ChoicesManager.Instance.yesrect))
        {
            run();
            Destroy(gameObject);
        }
        if(Rect.Overlaps(ChoicesManager.Instance.norect))
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = new Vector3(0,1,0);
        }
    }
    void Awake()
    {
        transform.localPosition = new Vector3(0,1,0);
    }
    public void run()
    {
        MapManager.Instance.DamageRandomCountry(cso.DamageCountries);
        ConsensusManager.Instance.WarFund += cso.ChangeWarBy;
        ConsensusManager.Instance.Tax += cso.ChangeTaxBy;
        ConsensusManager.Instance.Welfare = (ulong)(System.Convert.ToSingle(ConsensusManager.Instance.Welfare) + cso.ChangeWelfareBy);
        ConsensusManager.Instance.CentralBank += cso.ChangeCentralBankBy;
        ConsensusManager.Instance.ReElectionFund += cso.ChangeElectionFundBy;
    }
}
