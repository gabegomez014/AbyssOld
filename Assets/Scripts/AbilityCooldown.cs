using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public string abilityButtonAxisName = "Fire1";
    //public Image darkMask;
    //public Text cooldownTextDisplay;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject abilityHolder;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float cooldownDuration;
    private float nextReadyTime;
    private float cooldownTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, abilityHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject abilityHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        //darkMask.sprite = ability.aSprite;
        cooldownDuration = ability.aBaseCoolDown;
        abilitySource.clip = ability.aSound;
        ability.Initialize(abilityHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextReadyTime)
        {
            AbilityReady();
            string currentEventName = EventSystem.current.currentSelectedGameObject.name;
            

            switch (currentEventName)
            {
                case "AbilityIcon1":
                    print("We see ability 1 being used");
                    ButtonTriggered(0);
                    break;

                case "AbilityIcon2":
                    print("We see ability 2 being used");
                    ButtonTriggered(1);
                    break;

                default:
                    print("Not an ability");
                    break;
            }
            
        }
        else
        {
            Cooldown();
        }

    }

    private void AbilityReady()
    {
        //cooldownTextDisplay.enabled = false;
        //darkMask.enabled = false;
    }

    private void Cooldown()
    {
        cooldownTimeLeft -= Time.deltaTime;
        float roundedCD = Mathf.Round(cooldownTimeLeft);
        //cooldownTextDisplay.text = roundedCD.ToString();
        //darkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);
    }

    private void ButtonTriggered(int abilityIndex)
    {
        nextReadyTime = cooldownDuration + Time.time;
        cooldownTimeLeft = cooldownDuration;
        //darkMask.enabled = true;
        //cooldownTextDisplay.enabled = true;

        abilitySource.Play();
        ability.TriggerAbility(abilityIndex);
    }
}
