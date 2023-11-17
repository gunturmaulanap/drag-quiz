using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class car : MonoBehaviour
{
    public TMP_Text soal_tampil;

    public GameObject box;
    public float speed, sudut;
    public string [] soal,kuncijawaban;
    string[] jawaban;
    int nomor = -1;

   void Start(){
         StartCoroutine(lanjutsoal());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0,0,0);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    void OnTriggerEnter (Collider obj) {
        if(obj.name == "box"){

        if(obj.transform.GetChild(0).GetComponent<TMP_Text>().text == jawaban[0]){
                print("betul");
        }else{
                print("salah");
        }
        StartCoroutine(lanjutsoal());
        
        }
    }

     

    IEnumerator lanjutsoal(){


        yield return new WaitForSeconds(1.5f);

        nomor++;

        soal_tampil.transform.parent.gameObject.SetActive(true);
        print(nomor);
        soal_tampil.text = soal[nomor];

        box.GetComponent<Animator>().enabled = true;
        box.GetComponent<Animator>().Play(0);
        
        jawaban =  kuncijawaban[nomor].Split('|');
        for (int i=0;i<box.transform.childCount;i++){
            box.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = "" ;
        }
        for(int i=0;i<box.transform.childCount;i++){
            do {
                int index = (int)Random.Range(0,2.4f);
        } while( box.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text != "");
        box.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = jawaban[i];
        }

    }
}

