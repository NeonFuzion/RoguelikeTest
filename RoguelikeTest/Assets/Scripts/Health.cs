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
        if (curIFrameDur < iFrameDuration) curIFrameDur += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        if (curIFrameDur < iFrameDuration) return;
        curIFrameDur = 0;
        curHealth -= damage;
        onDamageTaken.Invoke(damage, (float)curHealth / maxHealth);
        StartCoroutine(DamageIndicationFlash());
        if (curHealth >= 0) return;
        onDeath.Invoke();
        Destroy(gameObject);
    }

    public void AddDeathListener(UnityAction unityAction)
    {
        onDeath.AddListener(unityAction);
    }

    IEnumerator DamageIndicationFlash()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
