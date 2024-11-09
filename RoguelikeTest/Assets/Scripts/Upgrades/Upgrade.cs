using UnityEngine;

public class Upgrade : ScriptableObject
{
    [SerializeField] protected string upgradeName, description;

    protected GameObject player;
    protected PlayerStats playerStats;

    public string UpgradeName { get => upgradeName; }
    public string Description { get => description; }

    public virtual void Instantiate(GameObject player)
    {
        this.player = player;
        playerStats = player.GetComponent<PlayerStats>();
    }
}
