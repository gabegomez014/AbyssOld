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
    private PlayerInfo infoCopy;

    GameObject khonoGO;
    GameObject powerGO;
    GameObject defenseGO;
    GameObject speedGO;
    GameObject atkSpdGO;
    GameObject resetBtn;
    GameObject saveBtn;

    public void DecreaseStat(string stat)
    {
        switch (stat)
        {
            case "Power":
                if (infoCopy.power > 1)
                {
                    infoCopy.khono += 1;
                    infoCopy.power -= 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    powerGO.GetComponent<TextMeshProUGUI>().text = infoCopy.power.ToString();
                }
                break;


            case "Defense":
                if (infoCopy.defense > 1)
                {
                    infoCopy.khono += 1;
                    infoCopy.defense -= 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    defenseGO.GetComponent<TextMeshProUGUI>().text = infoCopy.defense.ToString();
                }
                break;

            case "Speed":
                if (infoCopy.speed > 1)
                {
                    infoCopy.khono += 1;
                    infoCopy.speed -= 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    speedGO.GetComponent<TextMeshProUGUI>().text = infoCopy.speed.ToString();
                }
                break;

            case "AtkSpd":
                if (infoCopy.atkSpd > 1)
                {
                    infoCopy.khono += 1;
                    infoCopy.atkSpd -= 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    atkSpdGO.GetComponent<TextMeshProUGUI>().text = infoCopy.atkSpd.ToString();
                }
                break;
        }

        if (!infoCopy.Equals(playerInfo))
        {
            print("Tester");
            resetBtn.SetActive(true);
            saveBtn.SetActive(true);
        }
    }

    public void IncreaseStat(string stat)
    {
        switch (stat)
        {

            case "Power":
                if (infoCopy.khono > 0)
                {
                    infoCopy.khono -= 1;
                    infoCopy.power += 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    powerGO.GetComponent<TextMeshProUGUI>().text = infoCopy.power.ToString();
                }
                break;

            case "Defense":
                if (infoCopy.khono > 0)
                {
                    infoCopy.khono -= 1;
                    infoCopy.defense += 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    defenseGO.GetComponent<TextMeshProUGUI>().text = infoCopy.defense.ToString();
                }
                break;

            case "Speed":
                if (infoCopy.khono > 0)
                {
                    infoCopy.khono -= 1;
                    infoCopy.speed += 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    speedGO.GetComponent<TextMeshProUGUI>().text = infoCopy.speed.ToString();
                }
                break;

            case "AtkSpd":
                if (infoCopy.khono > 0)
                {
                    infoCopy.khono -= 1;
                    infoCopy.atkSpd += 1;

                    khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
                    atkSpdGO.GetComponent<TextMeshProUGUI>().text = infoCopy.atkSpd.ToString();
                }
                break;
        }

        if(!infoCopy.Equals(playerInfo))
        {
            print("Tester");
            resetBtn.SetActive(true);
            saveBtn.SetActive(true);
        }
    }

    public void ResetStats()
    {
        infoCopy = playerInfo;
        SetInfo();
    }

    private void Start()
    {
        LoadInfo();
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

        khonoGO.GetComponent<Text>().text = infoCopy.khono.ToString();
        powerGO.GetComponent<TextMeshProUGUI>().text = infoCopy.power.ToString();
        defenseGO.GetComponent<TextMeshProUGUI>().text = infoCopy.defense.ToString();
        speedGO.GetComponent<TextMeshProUGUI>().text = infoCopy.speed.ToString();
        atkSpdGO.GetComponent<TextMeshProUGUI>().text = infoCopy.atkSpd.ToString();
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
            infoCopy = playerInfo;
            file.Close();

            SetInfo();
        }
    }
}
