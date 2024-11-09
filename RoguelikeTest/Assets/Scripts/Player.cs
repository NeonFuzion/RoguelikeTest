using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] Transform damagePoint;
    [SerializeField] UnityEvent<Vector2> onDirectionInput;

    Rigidbody2D rb;
    int border;
    float atkCD, curAtkCD, attack;

    public float AttackCooldown {  get => atkCD; set => atkCD = value; }
    public float Attack {  get => attack; set => attack = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        border = 15;
        atkCD = 0.75f;
        curAtkCD = 0;
        attack = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) direction += Vector2.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector2.down;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        onDirectionInput.Invoke(direction);

        transform.up = -(Vector2)(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -border, border),
            Mathf.Clamp(transform.position.y, -border, border));

        curAtkCD += Time.deltaTime;
        if (curAtkCD < atkCD) return;
        curAtkCD = 0;
        StartCoroutine(ShowDamagePoint());

        foreach (Collider2D col in Physics2D.OverlapCircleAll(damagePoint.position, 2))
        {
            if (!col.GetComponent<Enemy>()) continue;
            col.GetComponent<Health>().TakeDamage((int)attack);
        }
    }

    IEnumerator ShowDamagePoint()
    {
        damagePoint.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damagePoint.gameObject.SetActive(false);
    }

    public void IncreaseSlashSize(float multiplier)
    {
        damagePoint.localScale = Vector3.one * multiplier;
    }
}
