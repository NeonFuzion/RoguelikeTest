using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] int upgradeCount;
    [SerializeField] GameObject player, prefabUpgrade, prefabUpgradeScreen;
    [SerializeField] UnityEvent<Upgrade> onUpgradeSelected;
    [SerializeField] Upgrade[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Shuffles array of Upgrades.
    /// </summary>
    /// <param name="array"></param>
    void Shuffle(Upgrade[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            Upgrade tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }

    /// <summary>
    /// Creates cards in UI when player gains enough experience to level up.
    /// </summary>
    public void CreateUpgradeCards()
    {
        //create screen that displays upgrades
        GameObject upgradeScreen = Instantiate(prefabUpgradeScreen);
        upgradeScreen.transform.SetParent(transform, false);
        Time.timeScale = 0;
        Shuffle(upgrades);

        //creates each individual upgrade card
        for (int i = 0; i < upgradeCount; i++)
        {
            GameObject upgrade = Instantiate(prefabUpgrade, transform.position, Quaternion.identity);
            upgrade.transform.SetParent(upgradeScreen.transform.GetChild(0), false);
            upgrade.GetComponent<UpgradeObject>().Initialize(upgrades[i], player);
        }
    }

}
