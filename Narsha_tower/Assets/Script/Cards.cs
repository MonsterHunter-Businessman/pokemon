using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//개선사항이 많이 필요
public enum TowerCards
{
    none,
    nun,
    Assassin,
    spear
}

public class Cards : MonoBehaviour
{
    public TextMeshProUGUI Cardname;
    public TextMeshProUGUI Carddescription;
    public TowerCards TowerCard;
    public static int CardDmg;
    public static int CardIndex;
    public string CardNametxt;
    public string CardInfo;
    Button Button;
    public static int CardPrice;
    public GameObject CardImage;
    public int[] hasCard;

    void Start()
    {
        CardIndex = 0;
        hasCard = new int[((int)TowerCard)];
    }


    void Update()
    {    
        mercenaryType();
        Cardname.text = CardNametxt;
        Carddescription.text = CardInfo;
      
    }
    public void mercenaryType()
    {
        switch (TowerCard)
        {
            case TowerCards.nun:
                CardNametxt = "사제";
                CardInfo = " 10초마다 아군의 체력을 5회복 합니다.적을 단일 공격합니다.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/nunImg");
                CardPrice = 200;
                CardDmg = 7;
                break;
            case TowerCards.Assassin:
                CardNametxt = "암살자";
                CardInfo = " 상대에게 공격을 받지 않습니다.적을 단일 공격합니다";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/assassin");
                CardPrice = 100;
                CardDmg = 15;
                break;
            case TowerCards.spear:
                CardNametxt = "창병";
                CardInfo = "상대의 어그로를 우선으로 먹습니다.적을 단일 공격합니다.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/spear");
                CardPrice = 500;
                CardDmg = 10;
                break;
        }
        if (CardIndex == 0)
        {
            TowerCard = TowerCards.nun;
        }
        if (CardIndex == 1)
        {
            TowerCard = TowerCards.Assassin;
        }
        if (CardIndex == 2)
        {
            TowerCard = TowerCards.spear;
        }
        if(CardIndex == 3)
        {
            TowerCard = TowerCards.none;
        }
    }
}
