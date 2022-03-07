using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject fighterPrefab;
    public int teamSize = 3;

    public string[] fighterNames;
    public GameObject[] aFighters;
    public GameObject[] bFighters;

    // Start is called before the first frame update
    void Start()
    {
        // Create teams and call generation
        aFighters = CreateTeam(aFighters);
        bFighters = CreateTeam(bFighters);

        // Randomly chose fighters
        GameObject randA = aFighters[Random.Range(0, teamSize)];
        GameObject randB = bFighters[Random.Range(0, teamSize)];
        Battle(randA, randB);
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
    {
        // Create team and spawn fighters
        incTeam = new GameObject[teamSize];
        for(int i = 0; i < teamSize; i++)
        {
            // Spawn fighter (go = game object)
            GameObject go = Instantiate(fighterPrefab);

            // Asign to team
            incTeam[i] = go;

            // Pick random name for fighter
            go.GetComponent<Character>().UpdateName(fighterNames[Random.Range(0, fighterNames.Length)]);
        }

        return incTeam;
    }

    public void Battle(GameObject fighterA, GameObject fighterB)
    {
        int coinFlip = Random.Range(0, 2);
        Character fAStats = fighterA.GetComponent<Character>();
        Character fBStats = fighterB.GetComponent<Character>();

        if(coinFlip == 0)
        {
            fBStats.health -= fAStats.attack - fBStats.defense;

            Debug.Log("Fighter A attacks Fighter B");
            Debug.Log("Fighter B's health is now: " + fBStats.health);
        }
        else
        {
            fAStats.health -= fBStats.attack - fAStats.defense;

            Debug.Log("Fighter B attacks Fighter A");
            Debug.Log("Fighter A's health is now: " + fAStats.health);
        }
    }
}
