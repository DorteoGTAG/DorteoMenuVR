using BepInEx;
using UnityEngine;

namespace DorteoMenu
{
    [BepInPlugin("com.dorteo.gorillatag.menu", "Dorteo Menu v1", "1.0.0")]
    public class DorteoMenuPlugin : BaseUnityPlugin
    {
        private static bool menuOpen = true;
        private static bool ghostMode = false;
        private static bool hideLocalName = false;
        private static bool hideLeaderboard = false;

        private readonly GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
        private readonly GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        private readonly GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
        private readonly GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

        private void Awake()
        {
            boxStyle.normal.background = MakeTexture(2, 2, new Color(0.05f, 0.05f, 0.10f, 0.92f));
            boxStyle.normal.textColor = Color.white;
            boxStyle.fontSize = 14;

            labelStyle.normal.textColor = Color.white;
            labelStyle.fontSize = 14;

            toggleStyle.normal.textColor = Color.white;
            toggleStyle.onNormal.textColor = new Color(0.4f, 0.8f, 1f, 1f);
            toggleStyle.fontSize = 14;

            buttonStyle.normal.textColor = Color.white;
            buttonStyle.hover.textColor = new Color(0.4f, 0.8f, 1f, 1f);
            buttonStyle.fontSize = 14;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                menuOpen = !menuOpen;
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                ghostMode = !ghostMode;
                ApplyGhostMode(ghostMode);
            }
        }

        private void OnGUI()
        {
            if (!menuOpen)
                return;

            const float x = 30f;
            const float y = 30f;
            const float w = 320f;
            const float h = 250f;

            GUI.Box(new Rect(x, y, w, h), "Dorteo Menu v1", boxStyle);

            float offsetY = y + 30f;
            GUI.Label(new Rect(x + 16f, offsetY, w - 32f, 24f), "Utility Menu", labelStyle);
            offsetY += 30f;

            ghostMode = GUI.Toggle(new Rect(x + 16f, offsetY, w - 32f, 24f), ghostMode, " Ghost mode", toggleStyle);
            offsetY += 32f;

            hideLocalName = GUI.Toggle(new Rect(x + 16f, offsetY, w - 32f, 24f), hideLocalName, " Hide local name", toggleStyle);
            offsetY += 32f;

            hideLeaderboard = GUI.Toggle(new Rect(x + 16f, offsetY, w - 32f, 24f), hideLeaderboard, " Hide leaderboard", toggleStyle);
            offsetY += 32f;

            if (GUI.Button(new Rect(x + 16f, offsetY, w - 32f, 28f), "Toggle Ghost", buttonStyle))
            {
                ghostMode = !ghostMode;
                ApplyGhostMode(ghostMode);
            }
        }

        private static void ApplyGhostMode(bool enabled)
        {
            foreach (var renderer in FindObjectsOfType<Renderer>())
            {
                if (renderer == null)
                    continue;

                var material = renderer.material;
                if (material == null)
                    continue;

                var color = material.color;
                color.a = enabled ? 0.15f : 1f;
                material.color = color;
            }
        }

        private static Texture2D MakeTexture(int width, int height, Color color)
        {
            var texture = new Texture2D(width, height);
            var pixels = new Color[width * height];

            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }
    }
}
