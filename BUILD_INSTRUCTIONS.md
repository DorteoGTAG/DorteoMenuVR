# Dorteo Menu v1 - Build Instructions for Visual Studio

## Quick Setup

1. **Download both files from the repo:**
   - `DorteoMenuPlugin.cs`
   - `DorteoMenuVR.csproj`

2. **Create a new folder** (e.g., `C:\DorteoMenuVR\`)

3. **Place both files in that folder**

4. **Open `DorteoMenuVR.csproj` in Visual Studio**
   - Double-click the `.csproj` file
   - Visual Studio will open the project

5. **Build the project:**
   - Click `Build` menu → `Build Solution`
   - Or press `Ctrl + Shift + B`
   - Wait for the build to complete

6. **Find your .DLL:**
   - Navigate to: `C:\DorteoMenuVR\bin\Release\`
   - You'll see `DorteoMenuVR.dll`

7. **Copy to BepInEx:**
   - Copy `DorteoMenuVR.dll`
   - Paste into: `C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag\BepInEx\plugins\`

8. **Launch Gorilla Tag**
   - Press **Y on your Oculus controller** to open/close the menu

## Menu Controls

- **Y Button**: Toggle menu open/close
- **A Button**: Toggle ghost mode
- **Toggles in menu:**
  - Ghost mode (makes you semi-transparent locally)
  - Hide local name
  - Hide leaderboard

## Troubleshooting

**Build errors about missing references?**
- Make sure Gorilla Tag is installed in the default Steam location: `C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag`
- If it's in a different location, edit the `.csproj` file and change the `<GorillaTagDir>` path

**DLL not loading in game?**
- Make sure BepInEx is installed and working in Gorilla Tag
- Check that the `.dll` is in the correct folder: `BepInEx\plugins\`
- Verify the `.dll` is named `DorteoMenuVR.dll`
