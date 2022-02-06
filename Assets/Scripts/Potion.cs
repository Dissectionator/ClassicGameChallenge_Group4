using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour { 
     private Player1 player;

    [SerializeField] private PotionType potionType;

    public enum PotionType {
       main,
    }
    public PotionType GetPotionType() {
        return potionType;
    }
}