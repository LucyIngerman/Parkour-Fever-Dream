using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material skyboxMaterial;

    void Start()
    {
        RenderSettings.skybox = skyboxMaterial;
        DynamicGI.UpdateEnvironment(); // optional for realtime GI
    }
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1f);
    }
}
