# GravityMod for *I Am Cat*

**GravityMod** is a simple MelonLoader mod that lets you adjust the global gravity multiplier in the Unity VR game *I Am Cat*. Rather than recompiling the mod, you can tweak the gravity value via an external config file.

---

## Features

- Multiply Unity’s `Physics.gravity` by a configurable multiplier  
- Apply the custom gravity once when your first game scene loads  
- Expose `GravityMultiplier` in a user-editable `.cfg` under `MelonLoader/Preferences`  
- No Harmony patches — uses built-in MelonPreferences API for simplicity and reliability

---

## Installation

1. **Install MelonLoader**  
   Follow the official instructions to install MelonLoader for *I Am Cat*.  
   https://melonwiki.xyz/#/installation  

2. **Download GravityMod.dll**  
   - Build from source or download the latest release from the Releases page.  

3. **Drop into Mods folder**  
   Copy `GravityMod.dll` into your game’s `Mods/` directory: <br>
I Am Cat/ <br>
├─ MelonLoader/ <br>
├─ Mods/ <br>
│ └─ GravityMod.dll <br>
└─ I Am Cat.exe <br>

4. **Run the game**  
Start *I Am Cat* normally. On first-scene load you will see a log message in `MelonLoaderLogs.txt` confirming your custom gravity.

---

## Configuration

GravityMod creates and manages its own config file:
<game folder>/MelonLoader/Preferences/GravityMod.cfg


Example contents:

[GravityMod]
// Multiplier applied to Physics.gravity
GravityMultiplier=0.10

GravityMultiplier
A floating-point value. The default game gravity (e.g. (0, -9.81, 0)) will be multiplied by this value.

To change gravity:

Open GravityMod.cfg in a text editor.

Edit the GravityMultiplier value (e.g. 0.05 for half-strength gravity).

Save and restart the game. The new gravity will apply immediately.

## License
This project is licensed under the MIT License.



