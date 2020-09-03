using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class PixelPerfectCanvasScaler : UIBehaviour
{
    private CanvasScaler canvasScaler;
    private PixelPerfectCamera pixelPerfectCamera;

    // Start is called before the first frame update
    protected override void Start()
    {
        // Get references to components
        canvasScaler = GetComponent<CanvasScaler>();
        pixelPerfectCamera = Camera.main.GetComponent<PixelPerfectCamera>();
    }

    // OnRectTransformDimensionsChange is called when an associated RectTransform has its dimensions changed.
    protected override void OnRectTransformDimensionsChange()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(SetScaleFactorAtEndOfFrame());
    }

    // Set the canvas scale factor to match the pixel perfect canvas
    void SetScaleFactor()
    {
        canvasScaler.scaleFactor = pixelPerfectCamera.pixelRatio;
    }

    // Call SetScaleFactor at end of frame
    IEnumerator SetScaleFactorAtEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        SetScaleFactor();
    }
}