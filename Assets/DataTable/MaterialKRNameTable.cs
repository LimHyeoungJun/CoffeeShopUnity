using CsvHelper.Configuration;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class MaterialKRNameTable : DataTable
{
   
     public class Data
     {
        public string ingredients { get; set; }
        public string kr_name { get; set; }
     }

    public Dictionary<string, string> dic = new Dictionary<string, string>();

    public MaterialKRNameTable()//������
    {
        path = "Tables/231010_bilge";
        Load();
    }

    public override void Load()
    {
        var csvstr = Resources.Load<TextAsset>(path);//���� ��û�Ҷ��� Ȯ���ڸ� ��������� ex).csv
        TextReader reader = new StringReader(csvstr.text);
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<Data>();

        foreach (var record in records)
        {
            dic[record.ingredients] = record.kr_name;
        }
    }

    public string GetString(string id)
    {
        if (!dic.ContainsKey(id))
        {
            return null;
        }
        return dic[id];
    }
}
