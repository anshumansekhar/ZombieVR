/*
* Copyright  (c) AnshumanSekhar
*/

using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

    #region Variables

    private Transform goal;
    private NavMeshAgent navMeshAgent;
    //public GameObject zoombiePrefab;


	#endregion


	#region UnityMethods
	void Start () 
	{
        goal = Camera.main.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = goal.position;

        GetComponent<Animation>().Play("walk");
	
	}
	void OnTriggerEnter(Collider col)
    {
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(col.gameObject);
        navMeshAgent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("back_fall");
        Destroy(gameObject, 6);
        GameObject zombie = Instantiate(Resources.Load("zoombie",typeof(GameObject))) as GameObject;

        float randomX = UnityEngine.Random.Range(-12f, 10f);
        float constantY = 0.01f;
        float randomZ = UnityEngine.Random.Range(-30f, 0f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);


        while(Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3f)
        {
            randomX= UnityEngine.Random.Range(-12f, 12f);
            randomZ = UnityEngine.Random.Range(-13f, 13f);
            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }
    }
	#endregion
}
