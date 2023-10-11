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
    private int days = 0;

    public GameObject Start;
    public GameObject End;

    private Dictionary<int, GuestTable.Data> guestInfo = new Dictionary<int, GuestTable.Data>();
    private Dictionary<int, BadGuestTable.Data> BadguestInfo = new Dictionary<int, BadGuestTable.Data>();
  
    public void Awake()
    {
        LoadGuestInfo();
        UIManager.instance.ActiveMaterialButton(false);
    }
    
    private void LoadGuestInfo()
    {
        GuestTable guestTable = new GuestTable();
        BadGuestTable badGuestTable = new BadGuestTable();

        foreach (var pair in guestTable.dic)
        {
            int id = pair.Key;
            guestInfo[id] = pair.Value;
        }
        foreach (var pair in badGuestTable.dic)
        {
            int id = pair.Key;
            BadguestInfo[id] = pair.Value;
        }

    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            DayContorller.instance.CurrentDay += 1;
        }
        if(DayContorller.instance.CurrentDay > days)
        {
            days = DayContorller.instance.CurrentDay;
            GameManager.instance.SetStartPoint();
            Debug.Log(days);
            MaterialController.instance.MaterialSetUp();
        }

        if(DayContorller.instance.CurrentDay >= 4)
        {
            UIManager.instance.ActiveMaterialButton(true);
        }

        if(spawnList.Count < 1)
        {
            timer += Time.deltaTime;
            if (timer > SpawnTime)
            {

                var npc = Instantiate(NPCprefab, transform.position, Quaternion.identity);

                int id = Random.Range(10001, 10131);//랜덤으로 npc소환 출현 날짜가 현재 날짜보다 높으면 낮을때 까지 다시뽑음
                while (guestInfo[id].day > DayContorller.instance.CurrentDay)
                {
                    id = Random.Range(10001, 10131);
                    if(guestInfo[id].day <= DayContorller.instance.CurrentDay)
                    {
                        break;
                    }
                }

                npc.Setup(guestInfo[id].drinks, Start, End, guestInfo[id].line, guestInfo[id].waitingtime, guestInfo[id].cost, guestInfo[id].number);
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
                if(DayContorller.instance.guestCount == 5)
                {
                    //Destroy(npc);
                    DayContorller.instance.CurrentDay += 1;
                    DayContorller.instance.guestCount = 0;
                }
            }
        }
    }
    public GuestTable.Data RandomDataByDay(int givenDay)
    {
        List<int> validKeys = new List<int>();

        // 조건에 맞는 키들만 모아둡니다.
        foreach (var key in guestInfo.Keys)
        {
            if (guestInfo[key].day <= givenDay)
            {
                validKeys.Add(key);
            }
        }

        // validKeys 리스트가 비어있지 않다면 그 중 하나를 랜덤하게 선택합니다.
        if (validKeys.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, validKeys.Count);
            int selectedKey = validKeys[randomIndex];

            return guestInfo[selectedKey];
        }

        return null; // 만약 조건에 맞는 키가 없다면 null을 반환
    }

}
