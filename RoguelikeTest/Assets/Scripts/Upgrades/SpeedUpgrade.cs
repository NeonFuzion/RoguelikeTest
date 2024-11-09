using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUpgrade", menuName = "Upgrade/SpeedUpgrade")]
public class SpeedUpgrade : Upgrade
{
    [SerializeField] float speedIncrease;

    public override void Instantiate(GameObject player)
    {
        base.Instantiate(player);

        playerStats.SetStat(PlayerStat.MovementSpeed, speedIncrease);
    }
}
