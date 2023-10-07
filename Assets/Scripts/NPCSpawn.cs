using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    private List<NPC> spawnList = new List<NPC>();
    public NPC NPCprefab;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    private float SpawnTime = 1f;
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
        
        if(spawnList.Count < 1)
        {
            timer += Time.deltaTime;
            if (timer > SpawnTime)
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
                npc.oderFalde += () =>
                {
                    spawnList.Remove(npc);
                    Destroy(npc.gameObject, 3f);
                };
                timer = 0f;
                SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                if(DayContorller.instance.guestCount > 5)
                {
                    Destroy(npc);
                }
            }
        }
    }

}
