using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject startScreen;
    GameObject upgradeScreen;
    GameObject optionScreen;
    GameObject abilityScreen;
    GameObject extrasScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Assigns the first child of the Game Object this script is attached to.
        startScreen = this.gameObject.transform.GetChild(0).gameObject;

        upgradeScreen = this.gameObject.transform.GetChild(1).gameObject;

        optionScreen = this.gameObject.transform.GetChild(2).gameObject;

        abilityScreen = this.gameObject.transform.GetChild(3).gameObject;

        extrasScreen = this.gameObject.transform.GetChild(4).gameObject;

    }

    public void ToGame()
    {
        StartCoroutine( LoadYourAsyncScene() );
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
            print("Current Progress: " + asyncLoad.progress);
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
}
