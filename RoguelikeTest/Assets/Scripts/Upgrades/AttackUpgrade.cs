using UnityEngine;

[CreateAssetMenu(fileName = "AttackUpgrade", menuName = "Upgrade/AttackUpgrade")]
public class AttackUpgrade : Upgrade
{
    [SerializeField] float attackIncrease;

    public override void Instantiate(GameObject player)
    {
        base.Instantiate(player);

        playerStats.SetStat(PlayerStat.Attack, attackIncrease);
    }
}
