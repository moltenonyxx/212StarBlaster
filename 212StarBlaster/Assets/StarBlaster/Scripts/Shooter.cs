using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projPrefab;
    [SerializeField] float projSpeed = 10f;
    [SerializeField] float projLifetime = 5f;
    [SerializeField] float fireRate = 1f;
    public bool isFiring;
    Coroutine fireCoroutine;
    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null) 
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject proj = Instantiate(projPrefab, transform.position, Quaternion.identity);

            Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();
            projRB.linearVelocityY = projSpeed;

            Destroy(proj, projLifetime);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
