using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eColorEnum
{
    Orange,
    Green,
    Blue,
    Pink,
    Yellow
}
public class TestFunction : MonoBehaviour
{
    public List<Color> colors;
    public MeshRenderer cubeMesh;
    public eColorEnum colorEnum;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(colorEnum)
        {
            case eColorEnum.Orange:
                cubeMesh.material.color = colors[0];
                break;
            case eColorEnum.Green:
                cubeMesh.material.color = colors[1];
                break;
            case eColorEnum.Blue:
                cubeMesh.material.color = colors[2];
                break;
            case eColorEnum.Pink:
                cubeMesh.material.color = colors[3];
                break;
            case eColorEnum.Yellow:
                cubeMesh.material.color = colors[4];
                break;
            default:
                cubeMesh.material.color = Color.red;
                break;
        }
    }
    
    private void changeColor()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            cubeMesh.material.color = colors[Random.Range(0,colors.Count)];
        }
    }

    private void OnMouseEnter()
    {
        //changeColor();
    }

    private void OnMouseExit()
    {
        //cubeMesh.material.color = Color.red;
    }

    private void OnMouseDown()
    {
        //changeColor();
        //Invoke(nameof(changeColor), 5);
        InvokeRepeating(nameof(changeColor), 1, 0.5f);
        
    }

    private void OnMouseUp()
    {
        //changeColor();
    }

    private void OnMouseDrag()
    {
        //changeColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}
