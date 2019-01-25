using System.Collections;
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
    private float starsHeight;

    private float t;

    public GameObject light;
    
	void Start ()
    {
        s = m.shader;
        skyColor = skyColors[0];
        equatorColor = equatorColors[0];
        cloudLightColor = cloudLightColors[0];
        cloudShadowColor = cloudShadowColors[0];

        currentIndex = 0; nextIndex = 1;

        starsHeight = 1;

        m.SetColor("_SkyColor", skyColor);
        m.SetColor("_EquatorColor", equatorColor);
        m.SetColor("_CloudsLightColor", cloudLightColor);
        m.SetColor("_CloudsShadowColor", cloudShadowColor);
        m.SetFloat("_StarsHeightMask", starsHeight);
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
        if (currentIndex == 1)
        {
            if (starsHeight > 0.17)
                starsHeight -= Time.deltaTime;
        }
        if (currentIndex == 2)
        {
            if (starsHeight < 1)
                starsHeight += Time.deltaTime;
        }

        light.transform.Rotate(Vector3.right, Time.deltaTime * 90 / dayLength);

        m.SetColor("_SkyColor", skyColor);
        m.SetColor("_EquatorColor", equatorColor);
        m.SetColor("_CloudsLightColor", cloudLightColor);
        m.SetColor("_CloudsShadowColor", cloudShadowColor);
        m.SetFloat("_StarsHeightMask", starsHeight);
	}
}
