using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    int attackDamage;
    [SerializeField]
    float attackRange;

    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    LayerMask targetLayer;

    public bool isAttacking = false;

    public void Attack()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, targetLayer);

        if (hitResults == null)
            return;
        foreach (Collider2D hit in hitResults)
        {
            if (hit.GetComponent<IDamageable<int>>() != null)
            {
                hit.GetComponent<IDamageable<int>>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }



}
