using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInfo : MonoBehaviour
{
    public static int PlayerLv;
    public static float PlayerExp;
    public TMP_InputField PlayerName;
    public TMP_InputField PlayerInfoTxt;

    public void PlayerInfoSave()
    {
        PlayerPrefs.SetString("Name",PlayerName.text);
        PlayerPrefs.SetString("Info",PlayerInfoTxt.text);
    }

    public void PlayerInfoLoad()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            PlayerName.text = PlayerPrefs.GetString("Name");
            PlayerInfoTxt.text = PlayerPrefs.GetString("Info");
        }
    }

    public void Update()
    {
        PlayerInfoSave();
        PlayerInfoLoad();
    }
}
