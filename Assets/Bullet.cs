using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_lifeTime = 1.5f;

    void Start()
    {
        Destroy(this.gameObject, m_lifeTime);
    }
}
