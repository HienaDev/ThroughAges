using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private KeyCode shoot = KeyCode.Mouse0;

    [SerializeField] private float fireRate = 0.5f;
    private float justShot;
    private Animator animator;

    [SerializeField] private GameObject shotManager;
    [SerializeField] private GameObject shotPrefab;
    private List<GameObject> instantiatedShots;

    // Start is called before the first frame update
    void Start()
    {

        justShot = Time.time;

        animator = GetComponent<Animator>();

        instantiatedShots = new List<GameObject>();

        StartCoroutine(CreateShots());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shoot) && Time.time - justShot > fireRate)
        {
            Shoot();
            
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Shoot");
        justShot = Time.time;
    }

    public void ResetTrigger()
    {
        animator.ResetTrigger("Shoot");
        
    }

    private IEnumerator CreateShots()
    {
        for (int i = 0; i < 10 / fireRate; i++) 
        {
            GameObject shotClone = Instantiate(shotPrefab, shotManager.transform);
            instantiatedShots.Add(shotClone);
            yield return null;
        }

    }
}
