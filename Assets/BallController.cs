using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float delta = 0f;
    public float destroyTime = 10f;
    public GameObject BGenerator;
    public GameObject FireC;

    private void Start()
    {
        BGenerator = GameObject.Find("BallGenerator");
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision other)
    {
        //GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<ParticleSystem>().Play();
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
 //           BGenerator.GetComponent<BallGenerator>().attackHit();
            BGenerator.GetComponent<FireController>().attackHit();
        }
    }

	private void Update()
	{
        this.delta += Time.deltaTime;

        if (this.delta > this.destroyTime)
        {
            Destroy(this.gameObject);
        }
	}
}
