using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ques_assign : MonoBehaviour
{
    public GameObject ques_holder;
    List<GameObject> temp = new();
    int size = 0;
    public Fetch_data ft;

    public void level_selected(TextMeshProUGUI level)
    {
        Show_ques(Levels_assign.selected_topic, (int)(level.text[^1] - '0'));
    }

    private void Show_ques(string topic, int lvl)
    {
        GameObject new_holder;
        foreach (var item in ft.all_data[topic][lvl])
        {
            new_holder = Instantiate(ques_holder, transform);
            temp.Add(new_holder.gameObject);
            new_holder.transform.SetSiblingIndex(lvl + 2);
            new_holder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item;
            new_holder.SetActive(true);
        }
    }

    public void Another_level()
    {
        if(temp.Count == 0) { return; }
        //int n = ft.all_data[Levels_assign.selected_topic][last_lvl].Count;
        foreach(var item in temp)
        {
            Destroy(item.gameObject);
        }
        temp.Clear();
    }
    public void back()
    {
        int n = transform.childCount;
        //print(n);
        while (n > 2)
        {
            Destroy(transform.GetChild(n-1).gameObject);
            n--;
        }
    }
}
