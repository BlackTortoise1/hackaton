using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageUIScript : MonoBehaviour {

    public Text TimeTillDeath;
    public Text Ability;
    public Text DeadTimeLeft;

    public Image EnergyBar;
    public float EnergyBarFillSpeed = 0.2F;

    public Image GuardianHappinessBar;
    public float ColorChangeSpeed = 0.1F;
    public float GuardianHappinessDecreaseSpeed = 0.1F;

    // Use this for initialization
    void Start () {
        DeadTimeLeft.text = "";
        Ability.text = "";
        TimeTillDeath.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        
        if(EnergyBar.fillAmount < 1)
            EnergyBar.fillAmount += Time.deltaTime * EnergyBarFillSpeed;

        //if (GuardianHappinessBar.fillAmount > 0)
        {
            GuardianHappinessBar.fillAmount -= Time.deltaTime * GuardianHappinessDecreaseSpeed;
            Color aux = GuardianHappinessBar.color;
            aux.r += Time.deltaTime * ColorChangeSpeed;
            aux.g -= Time.deltaTime * ColorChangeSpeed;
            GuardianHappinessBar.color = aux;
        }

        if (GameObject.Find("GameManager").GetComponent<GameState>().PlayerCommittedSuicide)
        {
            Debug.Log("UI");
            TimeTillDeath.text = GameState.Instance.ElapsedTimeBeforeDying.ToString();
        }

        if (GameState.Instance.PlayerIsDead)
        {
            TimeTillDeath.text = "";
            DeadTimeLeft.text = GameState.Instance.ElapsedDeadTime.ToString();
            if(GameState.Instance.CurrentAbility == GameState.MarshmallowAbility.fire)
                Ability.text = "You can ignite your enemies !!";

            if (GameState.Instance.CurrentAbility == GameState.MarshmallowAbility.ice)
                Ability.text = "You can freeze your enemies !!";

            if (GameState.Instance.CurrentAbility == GameState.MarshmallowAbility.expanded)
                Ability.text = "You can eat your enemies !!";
        }
    }
}
