using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public enum AttackableObjectType
    {
        Player,
        Tree
    }
    public int health;
    public SpriteRenderer spriteRenderer;
    public AttackableObjectType objectType;


      
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(objectType == AttackableObjectType.Tree)
        {
            HitFeedBack();
        }
        CheckIfWeDead();
    }

    protected void CheckIfWeDead()
    {
        if(health <= 0)
        {
            health = 0;
            if(objectType == AttackableObjectType.Tree)
            {
                TreeDestroyFeedBack();
            }
        }
    }

    private void HitFeedBack()
    {
        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => spriteRenderer.DOBlendableColor(Color.white, 0.05f));
    }

    private void TreeDestroyFeedBack()
    {
        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => Destroy(gameObject));
    }


}
