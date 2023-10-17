using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
public class GuestTable : DataTable
{
    public class Data
    {
        public int ID { get; set; }
        public int day { get; set; }
        public float waitingtime { get; set; }
        public string line { get; set; }
        public string drinks { get; set; }
        public int cost {  get; set; }
        public int number {  get; set; }
    }

    public Dictionary<int, Data> dic = new Dictionary<int, Data>();

    public GuestTable()//생성자
    {
        //path = "Tables/ptype_getoffwork_recipes_table";
        path = "Tables/20231017_normal_Customerline";
        Load();
    }

    public override void Load()
    {
        var csvstr = Resources.Load<TextAsset>(path);//여기 요청할때는 확장자를 지워줘야함 ex).csv
        TextReader reader = new StringReader(csvstr.text);
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<Data>();

        foreach (var record in records)
        {
            dic[record.ID] = record;
        }
    }

    public Data GetString(int id)
    {
        if (!dic.ContainsKey(id))
        {
            return null;
        }
        return dic[id];
    }
}
