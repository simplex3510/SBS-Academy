using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TargetType
{
    enemy,
    player
}

public class Projectile : MonoBehaviour
{
    public E_TargetType m_targetType = E_TargetType.enemy;
    public int m_targetMax = 1;
    public List<GameObject> m_targets = new List<GameObject>();
    public float m_damage = 1;
    public bool m_isRight = false;

    public void Spawn(Transform _pos)
    {
        transform.position = _pos.position;
        transform.rotation = _pos.rotation;

        this.gameObject.SetActive(true);

        m_targets.Clear();

        Debug.Log(" Spawn :" + transform.position);

    }
    public void SetFlipX(bool _isRight)
    {
        m_isRight = _isRight;

        Vector3 thisScale = transform.localScale;
        if (m_isRight)
        {
            thisScale.x = -Mathf.Abs(thisScale.x);
        }
        else
        {
            thisScale.x = Mathf.Abs(thisScale.x);
        }
        transform.localScale = thisScale;
    }
    void PlayDamage_enemy(Collider collision)
    {
        if (m_targets.Count >= m_targetMax)
            return;
        // Debug.Log(" PlayDamage_enemy");
        if (collision.CompareTag("EnemyHitBox"))
        {
            // Debug.Log(" PlayDamage_enemy -- EnemyHitBox");
            GameObject obj = collision.transform.parent.gameObject;
            m_targets.Add(obj);
            obj.GetComponent<Enemy>().TakeDamage();
            
        }
    }
    void PlayDamage_player(Collider collision)
    {
        if (m_targets.Count >= m_targetMax)
            return;
        Debug.Log(" PlayDamage_player");
        if (collision.CompareTag("PlayerHitBox"))
        {
            Debug.Log(" PlayDamage_player -- PlayerHitBox");
            GameObject obj = collision.transform.parent.gameObject;
            m_targets.Add(obj);
            Debug.Log("  obj.GetComponent<Player>().TakeDamage(m_damage) ");
            obj.GetComponent<Player>().TakeDamage(m_damage);
        }
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        switch (m_targetType)
        {
            case E_TargetType.enemy:
                PlayDamage_enemy(collision);
                break;
            case E_TargetType.player:
                PlayDamage_player(collision);
                break;
        }
    }


    public virtual void Release()
    {
        this.gameObject.SetActive(false);
    }
}
