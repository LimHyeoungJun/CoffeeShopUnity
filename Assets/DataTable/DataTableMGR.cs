using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataTableIDs
{
    String,
}

public static class DataTableMGR 
{
    private static Dictionary<System.Type, DataTable> tables =
         new Dictionary<System.Type, DataTable>();

    static DataTableMGR()//��𼱰� ȣ���ϸ� �ʱ�ȭ
    {
        tables.Clear();

        var stringTable = new StringTable();
        tables.Add(typeof(StringTable), stringTable);
    }

    
    public static T GetTable<T>() where T : DataTable
    {
        var id = typeof(T);
        if (!tables.ContainsKey(id))
        {
            return null;
        }
        return tables[id] as T;
    }

}
