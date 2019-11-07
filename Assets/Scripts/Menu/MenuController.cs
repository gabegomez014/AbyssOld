using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject startScreen;
    GameObject upgradeScreen;
    GameObject optionScreen;
    GameObject abilityScreen;
    GameObject extrasScreen;

    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        //Assigns the first child of the Game Object this script is attached to.
        startScreen = this.gameObject.transform.GetChild(0).gameObject;

        upgradeScreen = this.gameObject.transform.GetChild(1).gameObject;

        optionScreen = this.gameObject.transform.GetChild(2).gameObject;

        abilityScreen = this.gameObject.transform.GetChild(3).gameObject;

        extrasScreen = this.gameObject.transform.GetChild(4).gameObject;

        //DeleteInfo();

        if (!File.Exists(Application.persistentDataPath + "/PlayerInfo.abyss"))
        {
            playerInfo = new PlayerInfo();
            SaveInfo();          
        }

        else if (File.Exists(Application.persistentDataPath + "/PlayerInfo.abyss"))
        {
            LoadInfo();
        }


    }

    public void ToGame()
    {
        if (playerInfo.newPlayer == true)
        {
            ToUpgradeScreen(startScreen);
        }

        else
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ToUpgradeScreen(GameObject currentScreen)
    {
        upgradeScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    public void ToStartScreen(GameObject currentScreen)
    {
        startScreen.SetActive(true);
        if (currentScreen == upgradeScreen)
        {
            LoadInfo();
        }
        currentScreen.SetActive(false);
    }

    public void ToOptionScreen(GameObject currentScreen)
    {
        optionScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    public void ToAbilityScreen(GameObject currentScreen)
    {
        abilityScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    public void ToExtrasScreen(GameObject currentScreen)
    {
        extrasScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    private void LoadInfo()
    {
        // This function loads  up the Player Info file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.abyss", FileMode.Open);
        playerInfo = (PlayerInfo)bf.Deserialize(file);
        file.Close();
    }

    private void SaveInfo()
    {
        // This function saves the player info file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.abyss");
        bf.Serialize(file, playerInfo);
        file.Close();
    }

    private void DeleteInfo()
    {
        // This has been used mostly for testing purposes thus far
        File.Delete(Application.persistentDataPath + "/PlayerInfo.abyss");
    }
}
