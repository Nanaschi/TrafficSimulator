using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPooler : MonoBehaviour
{
    public Transform pointToSpawn;
    GameObject instantiatedCar;
    [SerializeField] [Range(.3f, 1)] float minTimeBeforeSpawn;
    [SerializeField] [Range(1, 2)] float  maxTimeBefreSpawn;
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
        public Button buttonToSpawn;
        public Color color;
        public float carSpeed;
    }
    public Pool pool;
    Queue<GameObject> queueOfObjects; 
    List<Queue<GameObject>> queuesOfObjects;
    private void Start()
    {
        InstantiateThePoolOfGameObjects();
    }

    private void InstantiateThePoolOfGameObjects()
    {
            queuesOfObjects = new List<Queue<GameObject>>();
      
            pool.buttonToSpawn.gameObject.GetComponent<Image>().color = pool.color;

            queueOfObjects = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                instantiatedCar = Instantiate(pool.prefab, transform);
                 instantiatedCar.transform.position = pointToSpawn.position;
                //instantiatedCar.SetActive(false);
                instantiatedCar.GetComponent<SpriteRenderer>().color = pool.color;
                queueOfObjects.Enqueue(instantiatedCar);
            }
            queuesOfObjects.Add(queueOfObjects);
        
     }

    public IEnumerator Delay(float minTime, float maxTime, float carSpeed)
    {
        while (true)
        {
            SpawnFromPoolOneObject(pool.carSpeed);
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    public void SpawnRandomlyVariousObjects(float carSpeed)
    {
        StartCoroutine(Delay(minTimeBeforeSpawn, maxTimeBefreSpawn, carSpeed));
    }

   public void StopTheMovement()
    {
        StopAllCoroutines();
    }
    
    public void SetTheSpeed(float carSpeed)
    {
        
        foreach (var car in GetComponentsInChildren<CarController>())
        {
            car.GetComponent<CarController>().carSpeed = carSpeed;
        }
    }
    public void SpawnFromPoolOneObject(float carSpeed)
    {
        var obj = queuesOfObjects[0].Dequeue();
        obj.SetActive(true);
        obj.GetComponent<CarController>().carSpeed = carSpeed;
        obj.transform.position = pointToSpawn.position;
        obj.transform.rotation = transform.rotation;
        queuesOfObjects[0].Enqueue(obj);
    }
    public void DespawnFromPoolOneObject()
    {
        var obj = queuesOfObjects[0].Dequeue();
        obj.GetComponent<CarController>().carSpeed = 0;
        queuesOfObjects[0].Enqueue(obj);
    }

}
