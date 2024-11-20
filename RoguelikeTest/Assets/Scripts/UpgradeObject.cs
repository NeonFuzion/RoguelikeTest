using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;

    Upgrade upgrade;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets up the upgrade object (card) to apply upgrade when selected
    /// </summary>
    /// <param name="upgrade"></param>
    /// <param name="player"></param>
    public void Initialize(Upgrade upgrade, GameObject player)
    {
        this.upgrade = upgrade;
        this.player = player;

        text.text = upgrade.UpgradeName + "\n" + upgrade.Description;
        button.onClick.AddListener(ApplyUpgrade);
    }

    /// <summary>
    /// Unpauses gameplay and triggers the selected upgrade's setup.
    /// </summary>
    public void ApplyUpgrade()
    {
        Time.timeScale = 1;
        Destroy(transform.parent.parent.gameObject);
        upgrade.Instantiate(player);
    }
}
