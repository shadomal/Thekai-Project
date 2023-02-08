using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermometroController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Toda vez que o jogador colidir com um objeto do time ice_cube o contador da barra do termometro vai ser reduzido em 5 ou seja nesse colisor ira sempre reduzir a barra do termometro
        if (collision.gameObject.tag == "ice_cube")
        {
            RemoveBarCount(5);
        }
    }

    #region Thermal_bar

    public int barFill;
    public int barMaxFill;
    public Image thermalBar;
    public void SetBar(int increment)
    {
        if (increment >= barFill)
        {
            barFill = barMaxFill;
        }
        else
        {
            barFill = increment;
        }
        UpdateTermalBar();
        if (barFill == 100)
        {
            //destroy player
        }
    }

    public void AddBarCount(int barIncrement) => this.SetBar(barFill + barIncrement);
    public void RemoveBarCount(int barReduced) => this.SetBar(barFill - barReduced);
    public void UpdateTermalBar() => this.thermalBar.fillAmount = ((1.6f / this.barMaxFill) / barFill);

    #endregion

    #region Termometro Controller

    public float timer;
    public bool isRunning;
    public void OnGameRunning()
    {
        if (isRunning == true)
        {
            //Neste contador a cada minuto que passa a barra vai aumentar a partir do momento em que o jogo estiver iniciando, ou seja a todo segundo que o player estiver em campo teoricamente a barra vai cada vez mais subindo.

            timer += Time.deltaTime;
            if (timer <= 100)
            {
                AddBarCount(1);
                if (timer == 100)
                {
                    isRunning = false;
                }
            }

        }
    }
    private void Update()
    {
        OnGameRunning();
    }

    #endregion

}
