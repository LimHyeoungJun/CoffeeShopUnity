using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NpcData
{
    [SerializeField]
    public NPC NpcPrefab;
    [SerializeField]
    public string name;
}
public class NPCSpawn : MonoBehaviour
{
    private List<NPC> spawnList = new List<NPC>();
    public NPC NPCprefab;
    public List<NpcData> NPCPre = new List<NpcData>();
    private float WatingTimer;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    private float SpawnTime = 1f;
    public string menu = null;
    private float timer = 0;
    private int days = 0;

    public GameObject Start;
    public GameObject End;
    public GameObject see;

    private Dictionary<int, GuestTable.Data> guestInfo = new Dictionary<int, GuestTable.Data>();
    private Dictionary<int, BadGuestTable.Data> BadguestInfo = new Dictionary<int, BadGuestTable.Data>();
    private Dictionary<string,string> CheckMaterial = new Dictionary<string, string>();
    Dictionary<string, List<string>> coffees = new Dictionary<string, List<string>>();

    private bool isone = true;
    private int SpawnCount;
    private bool oneone = true;
    private int cost;
    private string saveLine;


    public void Awake()
    {
        LoadGuestInfo();
        UIManager.instance.ActiveMaterialButton(false);
        GameManager.instance.IsTimeToGo = true;
        GameManager.instance.StarPoint = GameManager.instance.MaxStarPoint;
        GameManager.instance.SaveingMoney = GameManager.instance.PlayerMoney;
        SaveDataManager.instance.LoadData();
        saveLine = "��?��";
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
            SpawnCount = 0;
            oneone = true;
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
                if(SpawnCount == 0 && DayContorller.instance.CurrentDay >=3)
                {
                    int id = UnityEngine.Random.Range(20001, 20035);//�������� npc��ȯ ���� ��¥�� ���� ��¥���� ������ ������ ���� �ٽû���
                    while (BadguestInfo[id].day > DayContorller.instance.CurrentDay)
                    {
                        id = UnityEngine.Random.Range(20001, 20035);
                        if (BadguestInfo[id].day <= DayContorller.instance.CurrentDay)
                        {
                            break;
                        }
                    }
                    //���⼭ ���� ���� ���̸��� �°� �𵨸� list���� ã�Ƽ� �𵨸� �ѱ�
                    //var badnpc = Instantiate(NPCprefab, transform.position, Quaternion.identity);
                    var badnpc = Instantiate(GetModelByName(BadguestInfo[id].customer), transform.position, Quaternion.identity);

                    badnpc.Setup(BadguestInfo[id].drinks, Start, End, see, BadguestInfo[id].line, BadguestInfo[id].waitingtime, BadguestInfo[id].cost, BadguestInfo[id].number);
                    SetCheckBoardMenu(BadguestInfo[id].drinks);
                    cost = BadguestInfo[id].cost;
                    spawnList.Add(badnpc);
                    badnpc.oderComplet += () =>
                    {
                        spawnList.Remove(badnpc);
                        Destroy(badnpc.gameObject, 1f);
                    };
                    badnpc.oderFalde += () =>
                    {
                        spawnList.Remove(badnpc);
                        Destroy(badnpc.gameObject, 2f);
                    };
                    timer = 0f;
                    SpawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
                    ++SpawnCount;
                }
                else
                {
                    //int id = UnityEngine.Random.Range(10001, 10135);//�������� npc��ȯ ���� ��¥�� ���� ��¥���� ������ ������ ���� �ٽû���
                    //while (guestInfo[id].day > DayContorller.instance.CurrentDay)
                    //{
                    //    id = UnityEngine.Random.Range(10001, 10135);
                    //    if (guestInfo[id].day <= DayContorller.instance.CurrentDay && !saveLine.Equals(guestInfo[id].drinks))
                    //    {
                    //        break;
                    //    }
                    //}
                    int id = UnityEngine.Random.Range(10001, 10135);
                    while (true)
                    {
                        if (guestInfo[id].day <= DayContorller.instance.CurrentDay && !saveLine.Equals(guestInfo[id].drinks))
                        {
                            break;
                        }
                        id = UnityEngine.Random.Range(10001, 10135);
                    }
                    //var npc = Instantiate(NPCprefab, transform.position, Quaternion.identity);
                    //NPC obj = GetModelByName("1");
                    int n = UnityEngine.Random.Range(1, 9);
                    var npc = Instantiate(GetModelByName(n.ToString()), transform.position, Quaternion.identity);
                    //Debug.Log(GetModelByName(1.ToString()));
                    npc.Setup(guestInfo[id].drinks, Start, End, see, guestInfo[id].line, guestInfo[id].waitingtime, guestInfo[id].cost, guestInfo[id].number);
                    saveLine = guestInfo[id].drinks;
                    SetCheckBoardMenu(guestInfo[id].drinks);
                    cost = guestInfo[id].cost;
                    spawnList.Add(npc);
                    npc.oderComplet += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 1.5f);
                    };
                    npc.oderFalde += () =>
                    {
                        spawnList.Remove(npc);
                        Destroy(npc.gameObject, 2f);
                        
                    };
                    timer = 0f;
                    SpawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
                    ++SpawnCount;
                }
                
            }
           
        }
        else if (!GameManager.instance.IsTimeToGo && GameManager.instance.oneone)//npc5�� ī��Ʈ
        {
            //Debug.Log("��¥ ����");
            foreach (var c in spawnList)
            {
                Destroy(c);
            }
            spawnList.Clear();
            if(!GameManager.instance.IsCompletDrink)
            {
                UIManager.instance.MoneyUpdate(GameManager.instance.PlayerMoney -= cost);
                UIManager.instance.AddMinusMoney(cost);
                GameManager.instance.IsCompletDrink = true;
            }
            
            GameManager.instance.oneone = false;
        }
       
        if (GameManager.instance.PlayerMoney <= -20000)
        {
            GameManager.instance.TimerDead = true;
        }


    }
    public GuestTable.Data RandomDataByDay(int givenDay)
    {
        List<int> validKeys = new List<int>();

        // ���ǿ� �´� Ű�鸸 ��ƵӴϴ�.
        foreach (var key in guestInfo.Keys)
        {
            if (guestInfo[key].day <= givenDay)
            {
                validKeys.Add(key);
            }
        }

        // validKeys ����Ʈ�� ������� �ʴٸ� �� �� �ϳ��� �����ϰ� �����մϴ�.
        if (validKeys.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, validKeys.Count);
            int selectedKey = validKeys[randomIndex];

            return guestInfo[selectedKey];
        }

        return null; // ���� ���ǿ� �´� Ű�� ���ٸ� null�� ��ȯ
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
            return material; // Ȥ�� �ٸ� �⺻��
        }
    }
    private NPC GetModelByName(string modelName)
    {
        foreach (var npcData in NPCPre)
        {
            

            if (npcData.name.Equals(modelName))
            {
                return npcData.NpcPrefab;
            }
        }

        return null;
    }

}
