using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;
    public int age; //16 - 80
    public int previousClaims; //0, 1, 2, 3
    public int gender; //0 male, 1 female
    public int carType; // 0 = Eco, 1 = SUV, 2 = Truck, 3 = Sports
    public int riskScore;
    public int riskScoreLevel; //0, 1, 2 low, mod, high

    public int handIndex;
    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();

        riskScore = 0;
        age = Random.Range(16, 80);
        previousClaims = Random.Range(0, 4);
        gender = Random.Range(0, 2);
        carType = Random.Range(0, 4);

        //calculate risk score
        if (age >= 16 && age < 24) {
            riskScore += 20;
        } else if (age >= 24 && age < 41) {
            riskScore += 15;
        } else if (age >= 41 && age < 61) {
            riskScore += 10;
        }else if (age > 61) {
            riskScore += 5;
        }

        if (gender == 0) {
            riskScore += 10;
        } else if (gender == 1) {
            riskScore += 5;
        }

        if (carType == 0) {
            riskScore += 5;
        } else if (carType == 1) {
            riskScore += 10;
        } else if (carType == 2) {
            riskScore += 15;
        } else if (carType == 3) {
            riskScore += 20;
        }

        if (previousClaims == 0) {
            riskScore += 5;
        } else if (previousClaims == 1) {
            riskScore += 10;
        } else if (previousClaims == 2) {
            riskScore += 15;
        } else if (previousClaims == 3) {
            riskScore += 20;
        }

        //Find calculated Risk range
        if (riskScore <= 30) {
            riskScoreLevel = 0;
        } else if (riskScore > 30 && riskScore < 61) {
            riskScoreLevel = 1;
        } else if (riskScore > 60) {
            riskScoreLevel = 2;
        }


    }

    private void OnMouseDown() {
        if (hasBeenPlayed == false) {
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile(){
        
    }
}
