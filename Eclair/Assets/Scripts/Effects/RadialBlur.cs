using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RadialBlur : MonoBehaviour {

	public Material material;

	[Range(0.0f,5.0f)]
	public float force = 1.2f;

	[Range(0.0f,5.0f)]
	public float brightness = 1.0f;

	public float smoothFactor = 0.8f;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		material.SetFloat ("_Force", force);
		material.SetFloat ("_Brightness", brightness);
		Graphics.Blit(source, destination, material);
	}

	public void Shock(float force){
		StartCoroutine (Shock_raw (force,force));
	}

    public void Shock(float force,float brightness)
    {
        StartCoroutine(Shock_raw(force, brightness));
    }

    private IEnumerator Shock_raw(float force,float brightness){
		//Debug.Log ("Shock");
		bool disableWhenEnd = false;
		if (!enabled) {
			enabled = true;
			disableWhenEnd = true;
		}
		float targetForce = this.force;
		float targetBrightness = this.brightness;
		float timeCursor = 0;
		this.force = force;
		this.brightness = brightness;
		while (timeCursor < 1) {
			timeCursor += Time.deltaTime;
			this.force = Mathf.Lerp (targetForce, this.force, smoothFactor);
			this.brightness = Mathf.Lerp (targetBrightness, this.brightness, smoothFactor);
			yield return null;
		}
		this.force = targetForce;
		this.brightness = targetBrightness;

		Debug.Log ("ShockEnd");


		if (disableWhenEnd)
			enabled = false;
	}
}
