using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform WaterEffect;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin noise;
    private void Start()
    {
        virtualCamera.gameObject.SetActive(true);
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        WaterEffect.localScale = new Vector3(0.4f,0.4f,0f);
    }
    public void ChangeOrtho()
    {
        if (virtualCamera.m_Lens.OrthographicSize >= 10)
            return;

        virtualCamera.m_Lens.OrthographicSize += 3;
        WaterEffect.transform.localScale += new Vector3(0.2f, 0.2f, WaterEffect.transform.localScale.z);
       
    }
    public void Shake(float amplitudeGain, float frequencyGain,float time)
    {
        StartCoroutine(CameraShake(amplitudeGain,frequencyGain,time));
    }

    IEnumerator CameraShake(float amplitudeGain,float frequencyGain,float time)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        yield return new WaitForSeconds(time);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

    public void maxCamSize()
    {
        virtualCamera.m_Lens.OrthographicSize = 10;
        WaterEffect.transform.localScale = new Vector3(.8f,.8f,.8f);
    }
}
