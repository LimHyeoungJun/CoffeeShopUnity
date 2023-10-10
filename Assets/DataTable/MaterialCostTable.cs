using CsvHelper.Configuration;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class MaterialCostTable : DataTable
{
    public class Data
    {
        public int number { get; set; }
        public string name { get; set; }
        public int cash {  get; set; }

    }

    public Dictionary<string, Data> dic = new Dictionary<string, Data>();

    public MaterialCostTable()//생성자
    {
        //path = "Tables/ptype_getoffwork_recipes_table";
        path = "Tables/231010_ingredients_money";
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
            dic[record.name] = record;
        }
    }

    public Data GetString(string id)
    {
        if (!dic.ContainsKey(id))
        {
            return null;
        }
        return dic[id];
    }
}
