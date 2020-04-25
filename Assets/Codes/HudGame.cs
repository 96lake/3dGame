using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudGame : MonoBehaviour
{
    public Text timegame;
    public float mytime;
    public Objetivo1 objetivo1;
    public Objetivo2 objetivo2;
    public int Fim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (objetivo1.b && objetivo2.b)
            StartCoroutine(Finalizar(true));
        else {
            TimeSpan mytimespan = TimeSpan.FromSeconds(mytime);
            mytime += Time.deltaTime;
            timegame.text = mytimespan.ToString();
        }
    }

    public IEnumerator Finalizar(bool w) {
        if(w)timegame.color = Color.green;
        else timegame.color = Color.red;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}
