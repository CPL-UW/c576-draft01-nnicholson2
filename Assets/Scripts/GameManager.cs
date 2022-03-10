using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public GameObject myPrefab;

    public Text deckSizeText;

    private void Start() {
        for (int i = 0; i < 10; i++) {
        GameObject go = (GameObject)Instantiate(myPrefab);
        Debug.Log("Instantiated");
        deck.Add(go);
        }
    }

     public void DrawCard() {
         if(deck.Count >= 1) {
             GameObject randCard = deck[Random.Range(0, deck.Count)];
             Debug.Log("Drawing card");
             Debug.Log(randCard);

             for(int i = 0; i < availableCardSlots.Length; i++) {
                 if(availableCardSlots[i] == true) {
                     //randCard.gameObject.SetActive(true);
                     randCard.transform.position = cardSlots[i].position;
                     Debug.Log(randCard.transform.position);
                     Debug.Log(cardSlots[i].position);
                     availableCardSlots[i] = false;
                     deck.Remove(randCard);
                     return;
                 }
             }
         }
     }

    private void Update() {
        deckSizeText.text = deck.Count.ToString();        
    }
}
