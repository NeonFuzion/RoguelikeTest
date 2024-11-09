using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedUpgrade", menuName = "Upgrade/AttackSpeedUpgrade")]
public class AttackSpeedUpgrade : Upgrade
{
    [SerializeField] float attackSpeedIncrease;

    public override void Instantiate(GameObject player)
    {
        base.Instantiate(player);

        playerStats.SetStat(PlayerStat.MovementSpeed, attackSpeedIncrease);
    }
}
