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
    private string currentEventName;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, abilityHolder);
    }

    void Update()
    {
        if (Time.time > nextReadyTime)
        {
            AbilityReady();
        }
    }

    public void Initialize(Ability selectedAbility, GameObject abilityHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        button = GetComponent<Button>();
        //darkMask.sprite = ability.aSprite;
        cooldownDuration = ability.aBaseCoolDown;
        abilitySource.clip = ability.aSound;
        ability.Initialize(abilityHolder);
        AbilityReady();
    }

    public void AbilityClickHandle(int index)
    {
        if (Time.time > nextReadyTime) {
            AbilityTriggered(index);
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
        button.enabled = true;
    }

    private void Cooldown()
    {
        cooldownTimeLeft -= Time.deltaTime;
        float roundedCD = Mathf.Round(cooldownTimeLeft);
        //cooldownTextDisplay.text = roundedCD.ToString();
        //darkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);
    }

    private void AbilityTriggered(int abilityIndex)
    {
        nextReadyTime = cooldownDuration + Time.time;
        cooldownTimeLeft = cooldownDuration;
        //darkMask.enabled = true;
        //cooldownTextDisplay.enabled = true;
        button.enabled = false;


        abilitySource.Play();
        ability.TriggerAbility(abilityIndex);
    }
}
