using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] UnityEvent<Vector2> onTargetFound;

    Rigidbody2D rb;
    Transform target;

    int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onTargetFound.Invoke((target.position - transform.position).normalized);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (!col.gameObject.GetComponent<Player>()) return;
        col.gameObject.GetComponent<Health>().TakeDamage(damage);
    }

    public void Instantiate(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }
}
