using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Classe responsável por manter a escala dos elementos do canvas conforme outras resoluções
/// </summary>
[RequireComponent(typeof(CanvasScaler))]
public class ScreenAjust : MonoBehaviour
{
    private void Start() {
        var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
        var isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);

        if (isTablet) {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        } else {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        }
    }

    public static float DeviceDiagonalSizeInInches() {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        return diagonalInches;
    }
}