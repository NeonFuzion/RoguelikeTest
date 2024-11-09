using UnityEngine;

[CreateAssetMenu(fileName = "HealthUpgrade", menuName = "Upgrade/HealthUpgrade")]
public class HealthUpgrade : Upgrade
{
    [SerializeField] float healthIncrease;

    public override void Instantiate(GameObject player)
    {
        base.Instantiate(player);

        playerStats.SetStat(PlayerStat.Health, healthIncrease);
    }
}
