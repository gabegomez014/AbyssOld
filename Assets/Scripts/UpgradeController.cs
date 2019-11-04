using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    private PlayerInfo playerInfo;

    GameObject khonoGO;
    GameObject powerGO;
    GameObject defenseGO;
    GameObject speedGO;
    GameObject atkSpdGO;
    GameObject resetBtn;
    GameObject saveBtn;

    GameObject powerPBtn;           // The P stands for "Plus"
    GameObject powerDBtn;           // The D stands for "Decrease"
    GameObject defensePBtn;
    GameObject defenseDBtn;
    GameObject speedPBtn;
    GameObject speedDBtn;
    GameObject atkSpdPBtn;
    GameObject atkSpdDBtn;

    public void DecreaseStat(string stat)
    {
        switch (stat)
        {
            case "Power":
                playerInfo.khono += 1;
                playerInfo.power -= 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                powerGO.GetComponent<TextMeshProUGUI>().text = playerInfo.power.ToString();
                break;

            case "Defense":
                playerInfo.khono += 1;
                playerInfo.defense -= 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                defenseGO.GetComponent<TextMeshProUGUI>().text = playerInfo.defense.ToString();
                break;

            case "Speed":
                playerInfo.khono += 1;
                playerInfo.speed -= 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                speedGO.GetComponent<TextMeshProUGUI>().text = playerInfo.speed.ToString();
                break;

            case "AtkSpd":
                playerInfo.khono += 1;
                playerInfo.atkSpd -= 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                atkSpdGO.GetComponent<TextMeshProUGUI>().text = playerInfo.atkSpd.ToString();
                break;
        }
    }

    public void IncreaseStat(string stat)
    {
        switch (stat)
        {
            case "Power":
                playerInfo.khono -= 1;
                playerInfo.power += 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                powerGO.GetComponent<TextMeshProUGUI>().text = playerInfo.power.ToString();
                break;

            case "Defense":
                playerInfo.khono -= 1;
                playerInfo.defense += 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                defenseGO.GetComponent<TextMeshProUGUI>().text = playerInfo.defense.ToString();
                break;

            case "Speed":
                playerInfo.khono -= 1;
                playerInfo.speed += 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                speedGO.GetComponent<TextMeshProUGUI>().text = playerInfo.speed.ToString();
                break;

            case "AtkSpd":
                playerInfo.khono -= 1;
                playerInfo.atkSpd += 1;

                khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
                atkSpdGO.GetComponent<TextMeshProUGUI>().text = playerInfo.atkSpd.ToString();
                break;
        }
    }

    private void Start()
    {
        LoadInfo();

        powerPBtn = GameObject.Find("PowerPlusBtn");
        powerDBtn = GameObject.Find("PowerDecBtn");
        defensePBtn = GameObject.Find("DefensePlusBtn");
        defenseDBtn = GameObject.Find("DefenseDecBtn");
        speedPBtn = GameObject.Find("SpeedPlusBtn");
        speedDBtn = GameObject.Find("SpeedDecBtn");
        atkSpdPBtn = GameObject.Find("AtkSpdPlusBtn");
        atkSpdDBtn = GameObject.Find("AtkSpdDecBtn");
    }

    private void SetInfo()
    {
        khonoGO = GameObject.Find("KhonoPts");
        powerGO = GameObject.Find("PowerPts");
        defenseGO = GameObject.Find("DefensePts");
        speedGO = GameObject.Find("SpeedPts");
        atkSpdGO = GameObject.Find("AtkSpdPts");
        resetBtn = GameObject.Find("ResetBtn");
        saveBtn = GameObject.Find("SaveBtn");

        khonoGO.GetComponent<Text>().text = playerInfo.khono.ToString();
        powerGO.GetComponent<TextMeshProUGUI>().text = playerInfo.power.ToString();
        defenseGO.GetComponent<TextMeshProUGUI>().text = playerInfo.defense.ToString();
        speedGO.GetComponent<TextMeshProUGUI>().text = playerInfo.speed.ToString();
        atkSpdGO.GetComponent<TextMeshProUGUI>().text = playerInfo.atkSpd.ToString();
        resetBtn.SetActive(false);
        saveBtn.SetActive(false);
    }

    private void LoadInfo()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.abyss"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.abyss", FileMode.Open);
            playerInfo = (PlayerInfo)bf.Deserialize(file);
            file.Close();

            SetInfo();
        }
    }
}
