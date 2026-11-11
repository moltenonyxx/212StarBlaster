using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projPrefab;
    [SerializeField] float projSpeed = 10f;
    [SerializeField] float projLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;
    [Header("AI Variables")]
    [SerializeField] bool useAI;
    [SerializeField] float minFireRate = 0.2f;
    [SerializeField] float fireRateVarience = 0f;
    [HideInInspector]public bool isFiring;
    Coroutine fireCoroutine;


    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

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

            proj.transform.rotation = transform.rotation;

            Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();
            projRB.linearVelocity = transform.up * projSpeed;

            Destroy(proj, projLifetime);

            float waitTime = Random.Range(baseFireRate - fireRateVarience, baseFireRate + fireRateVarience);
            waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
