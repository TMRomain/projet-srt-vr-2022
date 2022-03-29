using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class LineRendererSettings : MonoBehaviour
{
    public GameObject panel;
    public Image img;
    public Button btn;
    public ActionBasedController actionBasedController;
    
    [SerializeField] private LineRenderer rend;
    private Vector3[] points;
    public LayerMask layerMask;
    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();
        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 100);
        
        rend.SetPositions(points);
        rend.enabled = true;

        img = panel.GetComponent<Image>();
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;

            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0,0,100);
            rend.startColor = Color.green;
            rend.endColor = Color.green;

            hitBtn = false;
        }
        rend.SetPositions(points);
        rend.material.color = rend.startColor;

        return hitBtn;
    }

    public void ColorChangeOnClick()
    {
        if (btn != null)
        {
            if (btn.name == "BtnHub") img.color = Color.blue;
            if (btn.name == "BtnLevel") img.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (AlignLineRenderer(rend) && actionBasedController.selectAction.action.triggered)
        {
            btn.onClick.Invoke();
        }
    }
}
