/*
* Copyright  (c) AnshumanSekhar
*/

using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    #region Variables
    private GameObject gun;
    private GameObject spawnPoint;
    private bool isShooting;
    public GameObject bulletPrefab;

	#endregion


	#region UnityMethods
	void Start () 
	{
        gun = gameObject.transform.GetChild(0).gameObject;
        spawnPoint = gun.transform.GetChild(0).gameObject;
        

        isShooting = false;
	
	}
    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Instantiate(bulletPrefab);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.position = spawnPoint.transform.position;
        bullet.transform.rotation = spawnPoint.transform.rotation;


        rb.AddForce(spawnPoint.transform.forward * 500f);
       

        GetComponentInChildren<AudioSource>().Play();
        gun.GetComponent<Animation>().Play();

        Destroy(bullet, 1);
        yield return new WaitForSeconds(1f);
        isShooting = false;


    }
	
	void Update ()
	{
        RaycastHit hit;
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.red);
        
        
        if(Physics.Raycast(spawnPoint.transform.position,spawnPoint.transform.forward,out hit, 1000f))
        {
            
            if (hit.collider.name.Contains("zoombie"))
            {
                Debug.Log("Hitting Zoombie");
                if (!isShooting)
                {
                    Debug.Log("Shooting");
                    StartCoroutine("Shoot");
                }
            }
        }
	}
	#endregion
}
