using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

public class StringTable : DataTable
{
    public class Data
    {
        public string day {  get; set; }
        public string name {  get; set; }
        public string ingredientlist1 {  get; set; }
        public string ingredientlist2 {  get; set; }
        public string ingredientlist3 {  get; set; }
        public string ingredientlist4 {  get; set; }

    }

    public Dictionary<string, Data> dic = new Dictionary<string, Data>();

    public StringTable()//생성자
    {
        //path = "Tables/ptype_getoffwork_recipes_table";
        path = "Tables/DAY60_CBT_getoffwork_recipes_table";
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
        if(!dic.ContainsKey(id))
        {
            return null;
        }
        return dic[id];
    }
}
