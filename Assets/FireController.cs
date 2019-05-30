using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_fireForce = 10f;
    public int BallCount = 20;
    GameObject BallText;


    void Start()
    {
        BallText = GameObject.Find("BallNum");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            BallCount -= 1;

        }
        this.BallText.GetComponent<Text>().text = BallCount.ToString("D2");
    }

    void Fire()
    {
        if (BallCount > 0)
        {
            Vector3 offset = Camera.main.transform.forward * 2;
            GameObject go = Instantiate(m_bulletPrefab, Camera.main.transform.position + offset, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(Camera.main.gameObject.transform.forward * m_fireForce, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("Bullet Prefab に Rigidbody が追加されていない。");
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void attackHit()
    {
        BallCount += 5;
    }
}
