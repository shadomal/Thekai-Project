using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCounter : MonoBehaviour
{

    public int iceCounter;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ice_cube")
        {
            iceCounter++;
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
        if (barFill <= 0)
        {
            //destroy player
        }
    }

    public void AddBarCount(int barIncrement) => this.SetBar(barFill + barIncrement);
    public void RemoveBarCount(int barReduced) => this.SetBar(barFill - barReduced);
    public void UpdateTermalBar() => this.thermalBar.fillAmount = ((1.6f / this.barMaxFill) * barFill);

    #endregion

}
