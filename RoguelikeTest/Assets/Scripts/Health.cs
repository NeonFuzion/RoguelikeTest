using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int curHealth, maxHealth;
    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent<int, float> onDamageTaken;

    float iFrameDuration, curIFrameDur;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        iFrameDuration = 0.283f;
        curIFrameDur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //incrementing invinciblity frame duration
        if (curIFrameDur < iFrameDuration) curIFrameDur += Time.deltaTime;
    }

    /// <summary>
    /// Takes damage specified by amount.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        //applies damage if not invincible
        if (curIFrameDur < iFrameDuration) return;
        curIFrameDur = 0;
        curHealth -= damage;
        onDamageTaken.Invoke(damage, (float)curHealth / maxHealth);
        StartCoroutine(DamageIndicationFlash());

        //destroys object if its health is less than 0
        if (curHealth >= 0) return;
        onDeath.Invoke();
        Destroy(gameObject);
    }

    public void AddDeathListener(UnityAction unityAction)
    {
        onDeath.AddListener(unityAction);
    }

    /// <summary>
    /// Coroutine that changes color of object when hit.
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageIndicationFlash()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
