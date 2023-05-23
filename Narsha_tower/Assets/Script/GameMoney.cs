using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMoney : MonoBehaviour
{
    public TextMeshProUGUI Tmp;
    // Start is called before the first frame update
    void Start()
    {
        Tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Tmp.text = BtnManager.GameMoney.ToString();
    }
}
