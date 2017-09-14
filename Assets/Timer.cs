using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float timer = 0;
    float duration = 0;
    public bool autoReset = true;

    public Timer(float time)
    {
        this.duration = time;
        timer = time;
    }



    public bool ticTac(float delta)
    {
        timer -= delta;

        if (timer <= 0)
        {
            if (autoReset)
            {
                timer = duration;
            }
            return true;
        }

        return false;

    }


    public void resetTimet()
    {
        timer = duration;
    }

    public bool isTimeOver()
    {
        return timer < 0;
    }

}