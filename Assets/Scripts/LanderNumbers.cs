using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class LanderNumbers : MonoBehaviour
{
    public Transform Parent;
    public Transform TextParent;
    List<GameObject> NumberText;
    Transform[] Landers;
    public Material TextMat;
    public GameObject textObject;
    private int Numbers = 0;

    private void Start()
    {
        NumberText = new List<GameObject>();
    }
    private void Awake()
    {
        //Landers = new List<Transform>();

        
       // CreateNumbers(Parent);
    }
    public void CreateNumbers(Transform scene)
    {
        Landers = scene.Find("Objects").Find("Landers").GetComponentsInChildren<Transform>();
        for (int i = 1;i<Landers.Length;i++)
        {
            Vector2 CurrentPositionOfLander = Landers[i].position;
            if(i==1)
            {
                CurrentPositionOfLander.y += 2;
            }
            var n = Instantiate(textObject,CurrentPositionOfLander, Quaternion.identity) ;
            Numbers += 1;
            n.GetComponent<TextMeshProUGUI>().text = Numbers.ToString();
            n.transform.parent = TextParent;
        }

    }
}
