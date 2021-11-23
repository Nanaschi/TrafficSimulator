using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [HideInInspector] public float carSpeed;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        TheCarGoes();
    }

    private void TheCarGoes()
    {
        transform.Translate(new Vector3(carSpeed, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>().color != spriteRenderer.color && collision.GetComponent<CarController>()) 
        { SceneManager.LoadScene("GameOver"); }
        if (collision.gameObject.tag == "ScoreArea") {  print("Score!"); GameEvents.current.ChangingTheScore(); }
    }
}
