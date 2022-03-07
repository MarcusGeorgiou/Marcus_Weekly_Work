using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charName;
    public int health = 100;
    public int attack;
    public int defense;

    public GameObject nameTAG;

    // Awake is caslled once an object is spawned
    void Awake()
    {
        InitStats();
    }

    private void InitStats()
    {
        attack = Random.Range(5, 20);
        defense = Random.Range(5, 20);
    }

    public void UpdateName(string newName)
    {
        charName = newName;
        nameTAG.GetComponent<TextMesh>().text = charName;
    }
}
