using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

String content = File.ReadAllText("icao.txt");
// Create an instance of HTML document
HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
doc.LoadHtml(content);

List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@id='example-table']")
            .Descendants("tr")
            .Skip(1)
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
            .ToList();

var airCraft = new List<Aircraft>();
foreach (var airType in table)
{
    airCraft.Add(new Aircraft(airType[0],airType[1],airType[2]));
}

string json = JsonConvert.SerializeObject(airCraft);

Console.WriteLine($"\n{json}\n");
var i = table.Count;

record Aircraft(string Sign, string ShorSign, string FullTypeName);