using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDrop : MonoBehaviour
{
    CurrencyManager currencyManager;

    public int value = 1;
    int attractionSpeed = 8;

    private void Awake()
    {
        //assign currency manager here because Gameplay Manager isn't a prefab
        //which makes it so that I can't assign currencyManager in the Currency prefab
        currencyManager = GameObject.Find("Gameplay Manager").GetComponent<CurrencyManager>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AttractionRadius"))
        {
            // Move the collectible toward the player
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, attractionSpeed * Time.deltaTime);


        }
    }
    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            //Currency currency = other.gameObject.GetComponent<Currency>();
            print("Collided with currency");
            currencyManager.AddCurrency(value);
            Destroy(gameObject);
        }
    }



}
