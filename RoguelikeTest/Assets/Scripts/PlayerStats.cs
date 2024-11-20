using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    //script references to set stats
    [SerializeField] Movement moveScript;
    [SerializeField] Player playerScript;
    [SerializeField] Health healthScript;

    Dictionary<PlayerStat, float> stats;

    // Start is called before the first frame update
    void Start()
    {
        //setting initial stats
        stats = new Dictionary<PlayerStat, float>()
        {
            { PlayerStat.MovementSpeed, 300 },
            { PlayerStat.AttackSpeed, 0.75f },
            { PlayerStat.Attack, 4 },
            { PlayerStat.Health, 100 },
            { PlayerStat.AttackRange, 1 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increments the provided player stat by the provided amount.
    /// </summary>
    /// <param name="stat"></param>
    /// <param name="amount"></param>
    public void SetStat(PlayerStat stat, float amount)
    {
        stats[stat] += amount;

        //checks which stat is being incremented and processes accordingly
        switch ((int)stat)
        {
            case 0: playerScript.Attack = stats[stat]; break;
            case 1: healthScript.MaxHealth = (int)stats[stat]; break;
            case 2: playerScript.AttackCooldown = stats[stat]; break;
            case 3: moveScript.Speed = (int)stats[stat]; break;
        }
    }
}

public enum PlayerStat { Attack, Health, AttackSpeed, MovementSpeed, AttackRange }
