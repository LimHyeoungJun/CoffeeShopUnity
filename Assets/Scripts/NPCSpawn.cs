using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    private List<NPC> spawnList = new List<NPC>();
    public NPC NPCprefab;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    private float SpawnTime = 1f;
    public string menu = null;
    private float timer = 0;
    private int days = 0;

    public GameObject Start;
    public GameObject End;

    private Dictionary<int, GuestTable.Data> guestInfo = new Dictionary<int, GuestTable.Data>();
    private Dictionary<int, BadGuestTable.Data> BadguestInfo = new Dictionary<int, BadGuestTable.Data>();
    private Dictionary<string,string> CheckMaterial = new Dictionary<string, string>();
    Dictionary<string, List<string>> coffees = new Dictionary<string, List<string>>();

    private bool isone = true;
    private int SpawnCount;
    public void Awake()
    {
        LoadGuestInfo();
        UIManager.instance.ActiveMaterialButton(false);
        GameManager.instance.IsTimeToGo = true;
        GameManager.instance.StarPoint = GameManager.instance.MaxStarPoint;
        GameManager.instance.SaveingMoney = GameManager.instance.PlayerMoney;
    }
    
    private void LoadGuestInfo()
    {
        GuestTable guestTable = new GuestTable();
        BadGuestTable badGuestTable = new BadGuestTable();
        MaterialKRNameTable materialKRNameTable = new MaterialKRNameTable();
        StringTable stringTable = new StringTable();
        

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
        foreach(var pair in materialKRNameTable.dic)
        {
            string id = pair.Key;
            CheckMaterial[id] = pair.Value;
            //Debug.Log($"{pair.Key}:{pair.Value}");
        }
        foreach (var pair in stringTable.dic)
        {
            List<string> ingredients = new List<string>();
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist1)) ingredients.Add(pair.Value.ingredientlist1);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist2)) ingredients.Add(pair.Value.ingredientlist2);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist3)) ingredients.Add(pair.Value.ingredientlist3);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist4)) ingredients.Add(pair.Value.ingredientlist4);
            ingredients.Sort();
            coffees[pair.Value.name] = ingredients;
        }


    }
    public void Update()
    {
        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    DayContorller.instance.CurrentDay += 1;
        //}
        if(DayContorller.instance.CurrentDay > days )
        {
            days = DayContorller.instance.CurrentDay;
            GameManager.instance.SetStartPoint();
            Debug.Log(days);
            MaterialController.instance.MaterialSetUp();
            GameManager.instance.StarPoint = GameManager.instance.MaxStarPoint;
            UIManager.instance.StarSetUp();
            //GameManager.instance.SaveingMoney = GameManager.instance.PlayerMoney;
           
        }

        if (DayContorller.instance.CurrentDay >= 4&& isone)
        {
            UIManager.instance.ActiveMaterialButton(true);
            isone = false;
        }

        if (spawnList.Count < 1 && GameManager.instance.IsTimeToGo)
        {
            timer += Time.deltaTime;
            if (timer > SpawnTime)
            {

                var npc = Instantiate(NPCprefab, transform.position, Quaternion.identity);


                if(SpawnCount == 3&&DayContorller.instance.CurrentDay >=4)
                {
                    int id = Random.Range(20001, 20030);//랜덤으로 npc소환 출현 날짜가 현재 날짜보다 높으면 낮을때 까지 다시뽑음
                    while (BadguestInfo[id].day > DayContorller.instance.CurrentDay)
                    {
                        id = Random.Range(20001, 20030);
                        if (BadguestInfo[id].day <= DayContorller.instance.CurrentDay)
                        {
                            break;
                        }
                    }
                    npc.Setup(BadguestInfo[id].drinks, Start, End, BadguestInfo[id].line, BadguestInfo[id].waitingtime, BadguestInfo[id].cost, BadguestInfo[id].number);
                    SetCheckBoardMenu(BadguestInfo[id].drinks);
                    spawnList.Add(npc);
                    npc.oderComplet += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 1f);
                    };
                    npc.oderFalde += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 2f);
                    };
                    timer = 0f;
                    SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                    ++SpawnCount;
                }
                else
                {
                    int id = Random.Range(10001, 10131);//랜덤으로 npc소환 출현 날짜가 현재 날짜보다 높으면 낮을때 까지 다시뽑음
                    while (guestInfo[id].day > DayContorller.instance.CurrentDay)
                    {
                        id = Random.Range(10001, 10131);
                        if (guestInfo[id].day <= DayContorller.instance.CurrentDay)
                        {
                            break;
                        }
                    }
                    npc.Setup(guestInfo[id].drinks, Start, End, guestInfo[id].line, guestInfo[id].waitingtime, guestInfo[id].cost, guestInfo[id].number);
                    SetCheckBoardMenu(guestInfo[id].drinks);
                    spawnList.Add(npc);
                    npc.oderComplet += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 1f);
                    };
                    npc.oderFalde += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 2f);
                    };
                    timer = 0f;
                    SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                    ++SpawnCount;
                }
                

               


            }
           
        }
        else if (!GameManager.instance.IsTimeToGo)//npc5명 카운트
        {
            Debug.Log("날짜 변경");
            
            foreach (var c in spawnList)
            {
                Destroy(c);
            }
            spawnList.Clear();
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
    private void SetCheckBoardMenu(string menu)
    {
        foreach (var pair in coffees)
        {
            if (pair.Key == menu)
            {
                string material1 = pair.Value.Count > 0 ? TranslateToKorean(pair.Value[0]) : " ";
                string material2 = pair.Value.Count > 1 ? TranslateToKorean(pair.Value[1]) : " ";
                string material3 = pair.Value.Count > 2 ? TranslateToKorean(pair.Value[2]) : " ";
                string material4 = pair.Value.Count > 3 ? TranslateToKorean(pair.Value[3]) : " ";

                UIManager.instance.SetCheackBoardMenu(TranslateToKorean(menu), material1, material2, material3, material4);
                return;
            }
        }
    }

    private string TranslateToKorean(string material)
    {
        if (CheckMaterial.ContainsKey(material))
        {
            return CheckMaterial[material];
        }
        else
        {
            return material; // 혹은 다른 기본값
        }
    }

}
