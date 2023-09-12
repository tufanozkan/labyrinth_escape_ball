using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ballcontrol : MonoBehaviour
{
    public UnityEngine.UI.Text can;
    public UnityEngine.UI.Button replay;
    public TextMeshProUGUI durum;
    private Rigidbody rg;
    public float hiz = 1.3f;
    int cansayaci = 3;
    bool gamestate = true;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cansayaci == 0)
        {
            gamestate = false;
            durum.text = "GAME OVER!!:(";
            replay.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(gamestate==true)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rg.AddForce(kuvvet * hiz);
            replay.gameObject.SetActive(false);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objname = collision.gameObject.name;
        if (objname.Equals("finish"))
        {
            durum.text = "YOU WON!!:)";
            rg.velocity = Vector3.zero;
        }
        else if(! objname.Equals("gameplain") && !objname.Equals("anotherplain"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";
        }
    }
}
