using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    // normal - default = no special abillities
    // fire - can trow fire at cockroaches => kills them
    // ice - can blow ice at cockroaches => freezes them for a certain time period
    // expanded - can now eat cockroaches => becomes poisonous (The guardian won't be TOO happy about that !! )
    public enum MarshmallowAbility { normal, fire, ice, expanded }

    bool GamePaused = false;

    public static GameState Instance = null;

    public Vector3 player_pos;
    // Guardian "happiness" value
    public float GuardianState = 100.0F;
    //Marshmallow current ability 
    public MarshmallowAbility CurrentAbility = MarshmallowAbility.normal;

    private MarshmallowAbility DesiredAbility;

    // ~~~~ DEAD
    // The player is currently dead 
    // This is the time where he can use his new ability
    public bool PlayerIsDead= false;
    // How long the player remains dead before respawning
    private float DeadTime = 5.0F;
    public float ElapsedDeadTime = 0;
    // ~~~~ DEAD

    // ~~~~ Suicide
    // If set it means the player committed suicide and will die after a few seconds
    public bool PlayerCommittedSuicide = false;
    // How long the player is still alive after a suicide attempt
    private float TimeBeforeDying = 5.0F;
    public float ElapsedTimeBeforeDying = 0;
    // ~~~~ Suicide

    
    public float PlayerDelicious = 0;


    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

            //If instance already exists and it's not this:
            else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

    MarshmallowAbility GetCurrentAbility ()
    {
        return CurrentAbility;
    }

    public void PlayerIsReckless(MarshmallowAbility AbilityToObtain)
    {
        PlayerCommittedSuicide = true;
        ElapsedTimeBeforeDying = TimeBeforeDying;
        DesiredAbility = AbilityToObtain;

    }

    private void Update()
    {
        if (PlayerCommittedSuicide)
            Debug.Log("suicide");

        if (GamePaused)
            return;

        if(PlayerCommittedSuicide)
        {
            ElapsedTimeBeforeDying -= Time.deltaTime;
            // Everyone must die at least once in a lifetime
            if(ElapsedTimeBeforeDying <= 0)
            {
                PlayerIsDead = true;
                ElapsedDeadTime = DeadTime;
                PlayerCommittedSuicide = false;
                CurrentAbility = DesiredAbility;
            }
        }

        if(PlayerIsDead)
        {
            ElapsedDeadTime -= Time.deltaTime;
            // And like a pheonix it shall be reborn
            if (ElapsedDeadTime <= 0)
            {
                PlayerIsDead = false;
                CurrentAbility = MarshmallowAbility.normal;
            }
        }

    }

}
