using TMPro;
using UnityEngine;

public class Topics_assign : MonoBehaviour
{
    private GameObject topic_holder;
    public Fetch_data ft;

    public void Start()
    {
        topic_holder = transform.GetChild(0).gameObject;
        RectTransform rt = topic_holder.GetComponent<RectTransform>();
        GameObject new_holder;
        int value = 0;

        foreach(var item in ft.all_data)
        {
            new_holder = Instantiate(topic_holder, transform);

            new_holder.GetComponent<RectTransform>().offsetMin = new Vector2(0, rt.offsetMin.y + value);
            new_holder.GetComponent<RectTransform>().offsetMax = new Vector2(0, -rt.offsetMax.y + value);

            new_holder.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.Key;
            value -= 110;
        }
        Destroy(topic_holder);
    }
}
