using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtil : MonoBehaviour
{
    /// <summary>
    /// thisCamera must have [RenderTexture] in Target Texture,
    /// which means "camera waching image to texture, not camera view".
    /// </summary>
    private Camera thisCamera;

    void Awake()
    {
        thisCamera = this.gameObject.GetComponent<Camera>();
    }

    /// <summary>
    /// Get Image which thisCamera watching
    /// </summary>
    /// <returns></returns>
    public byte[] CamCapture()
    {
        // store active render texture
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = thisCamera.targetTexture;

        thisCamera.Render();

        Texture2D Image = new Texture2D(thisCamera.targetTexture.width, thisCamera.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, thisCamera.targetTexture.width, thisCamera.targetTexture.height), 0, 0);
        Image.Apply();

        // restore active render texture
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        return Bytes;
    }
}

