﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayLength;
    public Material m;
    private Shader s;
    
    public Color[] skyColors;
    public Color[] equatorColors;
    public Color[] cloudLightColors;
    public Color[] cloudShadowColors;
    private int currentIndex, nextIndex;
    private Color skyColor, equatorColor, cloudLightColor, cloudShadowColor;
    
    private float t;
    
	void Start ()
    {
        s = m.shader;
        skyColor = skyColors[0];
        equatorColor = equatorColors[0];
        cloudLightColor = cloudLightColors[0];
        cloudShadowColor = cloudShadowColors[0];

        currentIndex = 0; nextIndex = 1;

        m.SetColor("_SkyColor", skyColor);
        m.SetColor("_EquatorColor", equatorColor);
        m.SetColor("_CloudsLightColor", cloudLightColor);
        m.SetColor("_CloudsShadowColor", cloudShadowColor);
	}
	
	void Update ()
    {
        skyColor = Color.Lerp(skyColors[currentIndex], skyColors[nextIndex], t);
        equatorColor = Color.Lerp(equatorColors[currentIndex], equatorColors[nextIndex], t);
        cloudLightColor = Color.Lerp(cloudLightColors[currentIndex], cloudLightColors[nextIndex], t);
        cloudShadowColor = Color.Lerp(cloudShadowColors[currentIndex], cloudShadowColors[nextIndex], t);
        if (t < 1)
        {
            t += Time.deltaTime / dayLength;
        }
        else
        {
            currentIndex = nextIndex; nextIndex++;
            if (nextIndex >= 4)
                nextIndex = 0;
            t = 0;
        }

        m.SetColor("_SkyColor", skyColor);
        m.SetColor("_EquatorColor", equatorColor);
        m.SetColor("_CloudsLightColor", cloudLightColor);
        m.SetColor("_CloudsShadowColor", cloudShadowColor);
	}
}