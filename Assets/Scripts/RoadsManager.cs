using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsManager : MonoBehaviour
{
    CarPooler[] carPoolers;

    int roadNumber;
    private void Awake()
    {
        carPoolers = GetComponentsInChildren<CarPooler>();

        StartCoroutine(Delay());
    }

    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        //RandomSpawnFromTheRoad();
    }


    public int RandomSpawnFromTheRoad()
    {
        var randomNumber = Random.Range(0, carPoolers.Length);
        carPoolers[randomNumber].SpawnRandomlyVariousObjects(0);
        carPoolers[randomNumber].pool.buttonToSpawn.interactable = true;
        return randomNumber;
    }

    public void SwitchCar()
    {
        bool next = false;
   
        for (int i = 0; i < carPoolers.Length; i++)
        {

             if (carPoolers[i].pool.buttonToSpawn.interactable == true)
            {
                
                next = true;
            }

        }
           
       carPoolers[roadNumber].pool.buttonToSpawn.interactable = false;
        carPoolers[roadNumber].StopTheMovement();
        carPoolers[roadNumber].SetTheSpeed(0);
        roadNumber += 1;

        if (carPoolers.Length == roadNumber)
            {
                roadNumber = 0;
            }
        print(roadNumber);

        carPoolers[roadNumber].pool.buttonToSpawn.interactable = true;
            carPoolers[roadNumber].SpawnRandomlyVariousObjects(.3f);


    }

}
