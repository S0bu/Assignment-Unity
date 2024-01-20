using TMPro;
using UnityEngine;

public class Levels_assign : MonoBehaviour
{
    public GameObject level_holder;
    public GameObject holder_parent;
    public static string selected_topic;
    public Fetch_data ft;

    public void Topic_level(TextMeshProUGUI text)
    {
        selected_topic = text.text;
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = text.text;

        holder_parent.GetComponent<RectTransform>().offsetMin = new Vector2(0, -320);

        Instantiate_level_holders(text.text);

    }

    private void Instantiate_level_holders(string topic)
    {
        RectTransform rt = level_holder.GetComponent<RectTransform>();
        GameObject new_holder;
        //int value = 0, counter = 0;

        foreach (var item in ft.all_data[topic])
        {
            //counter++;
            new_holder = Instantiate(level_holder, holder_parent.transform);

            new_holder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "level " + item.Key;
            new_holder.SetActive(true);

            /*new_holder.GetComponent<RectTransform>().offsetMin = new Vector2(0, rt.offsetMin.y + value);
            new_holder.GetComponent<RectTransform>().offsetMax = new Vector2(0, -rt.offsetMax.y + value);*/

            //value -= 110;

            /*if (counter > 3)
                holder_parent.GetComponent<RectTransform>().offsetMin = new Vector2(0, holder_parent.GetComponent<RectTransform>().offsetMin.y - 110);
        */
        }
    }
}
