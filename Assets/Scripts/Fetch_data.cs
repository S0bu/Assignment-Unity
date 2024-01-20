using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
using Newtonsoft.Json;

public class Fetch_data : MonoBehaviour
{
    //public List<string> topics = new();
    //public Dictionary<string,List<int>> levels = new();
    public Dictionary<string,Dictionary<int, List<string>>> all_data = new();
    private async void Awake()
    {
        string apiUrl = "https://testinterest.s3.amazonaws.com/assignmentData.json";

        using HttpClient httpClient = new();
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Dictionary<string, Dictionary<int, List<Dictionary<string,string>>>> responseObject = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<int, List<Dictionary<string,string>>>>>(responseData);

                foreach (var kvp in responseObject)
                {
                    List<int> temp = new();
                    Dictionary<int, List<string>> level_t = new();
                    foreach (var item in kvp.Value)
                    {
                        List<string> q = new();
                        foreach (var item2 in item.Value)
                        {
                            foreach (var item3 in item2)
                            {
                                if(item3.Key.Equals("subtopic_name"))
                                    q.Add(item3.Value);
                            }
                        }
                        level_t.Add(item.Key, q);
                    }
                    all_data.Add(kvp.Key, level_t);
                }
            }
            else
            {
                print($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            print($"Exception: {ex.Message}");
        }


        /*foreach (var outerKeyValue in all_data)
        {
            print($"Outer Key: {outerKeyValue.Key}");

            foreach (var innerKeyValue in outerKeyValue.Value)
            {
                print($"  Inner Key: {innerKeyValue.Key}");

                foreach (var innerListValue in innerKeyValue.Value)
                {
                    print($"    List Value: {string.Join(", ", innerListValue)}");
                }
            }
        }*/

    }

}


