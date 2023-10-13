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
                    int id = Random.Range(20001, 20030);//�������� npc��ȯ ���� ��¥�� ���� ��¥���� ������ ������ ���� �ٽû���
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
                    int id = Random.Range(10001, 10131);//�������� npc��ȯ ���� ��¥�� ���� ��¥���� ������ ������ ���� �ٽû���
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
        else if (!GameManager.instance.IsTimeToGo)//npc5�� ī��Ʈ
        {
            Debug.Log("��¥ ����");
            
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

}
