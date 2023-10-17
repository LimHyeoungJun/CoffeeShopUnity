using CsvHelper.Configuration;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class BadGuestTable : DataTable
{
    public class Data
    {
        public int ID { get; set; }
        public int day { get; set; }
        public string customer { get; set; }
        public float waitingtime { get; set; }
        public string line { get; set; }
        public string drinks { get; set; }
        public int cost { get; set; }
        public int number { get; set; }
    }

    public Dictionary<int, Data> dic = new Dictionary<int, Data>();

    public BadGuestTable()//생성자
    {
        path = "Tables/231016CBT_BADcustomerline (1)";
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
