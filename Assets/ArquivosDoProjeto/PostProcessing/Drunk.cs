using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DrunkRenderer), PostProcessEvent.AfterStack, "Custom/Drunk")]
public sealed class Drunk : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Drunk distortion effect intensity")]
    public FloatParameter amplitude = new FloatParameter { value = 0.5f };
    [Range(0f, 100f), Tooltip("Drunk distortion effect Frequency")]
    public FloatParameter frequency = new FloatParameter { value = 0.5f };
    [Tooltip("Speed of distortion only x&y used")]
    public Vector4Parameter speed = new Vector4Parameter { value = new Vector4(1, 1, 0, 0) };
    [Tooltip("Size of distortion only x&y used")]
    public Vector4Parameter size = new Vector4Parameter { value = new Vector4(1, 1, 0, 0) };

}

public sealed class DrunkRenderer : PostProcessEffectRenderer<Drunk>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/Drunk"));
        sheet.properties.SetFloat("_Amplitude", settings.amplitude);
        sheet.properties.SetFloat("_Frquency", settings.frequency);
        sheet.properties.SetVector("_Speed", settings.speed);
        sheet.properties.SetVector("_Size", settings.size);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}