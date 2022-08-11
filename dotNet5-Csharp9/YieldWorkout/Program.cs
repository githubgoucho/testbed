using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        List<Int32> _lstData = new();
        _lstData.Add(31);
        _lstData.Add(23);
        _lstData.Add(44);
        _lstData.Add(53);
        _lstData.Add(87);
        _lstData.Add(89);
        _lstData.Add(99);
        _lstData.Add(65);
        _lstData.Add(14);

        IEnumerable<Int32> _data = GetData(_lstData);
        foreach(var record in _data)
        {
            Console.WriteLine(record);
        }
    }
    public static IEnumerable<Int32> GetData(List<Int32> lstData)
    {
        foreach (var _id in lstData)
        {
            if(_id > 50)
                yield return _id;
        }
    }
 }