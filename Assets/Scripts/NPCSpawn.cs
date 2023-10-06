using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class NPCSpawn : MonoBehaviour
{
    private List<NPC> spawnList = new List<NPC>();
    public NPC NPCprefab;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    public string menu = null;
    private float timer = 0;

    public GameObject Start;
    public GameObject End;

    //TestCode
    private string[] menus = { "espresso", "ice_espresso", "americano", "ice_americano" };
    
    public void Awake()
    {
        
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(spawnList.Count < 1)
        {
            if(timer > Random.Range(minSpawnTime, maxSpawnTime))
            {
                int index = Random.Range(0, menus.Length);
                menu = menus[index];
                var npc = Instantiate(NPCprefab, transform.position, Quaternion.identity);
                npc.Setup(menu, Start, End);
                spawnList.Add(npc);
                npc.oderComplet += () =>
                {
                    spawnList.Remove(npc);
                    Destroy(npc.gameObject, 1f);
                };
                timer = 0f;
            }
        }
    }

}
