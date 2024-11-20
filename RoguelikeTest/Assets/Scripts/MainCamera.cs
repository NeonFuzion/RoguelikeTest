using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] UnityEvent<int> onEnemyDeath;
    [SerializeField] List<Sprite> tileSprites;
    [SerializeField] Tilemap tilemap;

    float spawnCD, curSpawnCD;
    int spawnRange, difficultyLevel, curDifLv, border;
    float enemyDmg;

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = 10;
        curDifLv = 0;
        spawnCD = 3;
        curSpawnCD = 0;
        spawnRange = 10;
        enemyDmg = 15;
        border = 15;

        //Create map
        for (int x = -border; x <= border; x++)
        {
            for (int y = -border; y <= border; y++)
            {
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = tileSprites[Random.Range(0, tileSprites.Count)];
                tilemap.SetTile(new Vector3Int(x, y), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //setting camera to follow player
        transform.position = target.position + Vector3.back * 10;

        //checking when to spawn enemies & increment difficulty
        curSpawnCD += Time.deltaTime;
        if (curSpawnCD < spawnCD) return;
        curSpawnCD = 0;
        curDifLv++;
        
        //creating new enemy
        GameObject enemy = Instantiate(prefabEnemy,
            new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange)),
            Quaternion.identity);
        enemy.GetComponent<Enemy>().Instantiate(target, Mathf.RoundToInt(enemyDmg));
        enemy.GetComponent<Health>().AddDeathListener(EnemyDeathEvent);

        //incrementing level if necessary
        if (curDifLv < difficultyLevel) return;
        curDifLv = 0;
        difficultyLevel++;
        spawnCD *= 0.9f;
        enemyDmg *= 1.1f;
    }

    /// <summary>
    /// Calls an event whenever an enemy dies. Is used for experience gain for XP bar in UI.
    /// </summary>
    public void EnemyDeathEvent()
    {
        onEnemyDeath.Invoke(5);
    }
}
