# Crush It

Crush It is a 3D arcade vehicular runner and car combat prototype developed in Unity. The player drives forward along an endless multi-lane road, steering left and right while adjusting throttle to crush obstacles, ram through zombies and enemy vehicles, and battle an opposing AI vehicle using collectible power-up skills. This repository is a personal prototype/demo project, not a maintained product, with the last substantial work committed in 2022.

## Gameplay

- Continuous forward vehicular movement, lane shifting, and speed modulation (`Assets/Scripts/Player/PlayerController.cs`, `Assets/Scripts/Player/BaseController.cs`).
- Looping endless road progression created by dynamically recycling ground tiles ahead of the vehicle (`Assets/Scripts/Block/GroundBlock.cs`).
- Procedural obstacle and hazard generation placing civilian cars, barriers, and wandering entities along random lanes (`Assets/Scripts/Helper/GameplayController.cs`).
- Destructible zombie hazards that react with blood particle effects, award score points, and deform on collision (`Assets/Scripts/Obstacle/Zombie.cs`).
- Hostile enemy civilian traffic vehicles that explode on impact with bullets or the player vehicle (`Assets/Scripts/Obstacle/EnemyCar.cs`).
- Static explosive obstacle hazards inflicting damage upon vehicle collision (`Assets/Scripts/Obstacle/ExplosiveObstacle.cs`).
- Timed spawning of power-up items along the track (`Assets/Scripts/Pickups/PickupSpawner.cs`, `Assets/Scripts/Pickups/PowerPickup.cs`).
- Rocket power-up enabling homing projectile attacks targeting opposing vehicles (`Assets/Scripts/Player/PlayerSkillController.cs`, `Assets/Scripts/Enemy/EnemySkillController.cs`, `Assets/Scripts/Projectile/Rocket.cs`).
- Shield power-up granting temporary damage absorption and collision defense (`Assets/Scripts/Player/PlayerSkillController.cs`, `Assets/Scripts/Enemy/EnemySkillController.cs`, `Assets/Scripts/Player/PlayerHealth.cs`, `Assets/Scripts/Pickups/ShieldSoundController.cs`).
- Magnetize power-up slowing down opponent vehicle velocity (`Assets/Scripts/Player/PlayerSkillController.cs`, `Assets/Scripts/Enemy/EnemySkillController.cs`, `Assets/Scripts/Enemy/Enemy.cs`).
- Health management and win/loss resolution tracking both player and enemy vehicle status (`Assets/Scripts/Player/PlayerHealth.cs`, `Assets/Scripts/Enemy/EnemyHealth.cs`, `Assets/Scripts/UI/EndGamePanel.cs`).
- Dynamic scoring increasing over time and upon striking hazards or gathering pickups (`Assets/Scripts/Helper/GameplayController.cs`).
- Third-person dynamic camera tracking with position and rotation damping behind the active vehicle (`Assets/Scripts/Camera/SmoothFollow.cs`).
- Mobile touch swipe and on-screen steering button inputs (`Assets/Scripts/Helper/MobileInput.cs`, `Assets/Scripts/UI/LeftButton.cs`, `Assets/Scripts/UI/RightButton.cs`).
- Main menu UI flow with camera transition animation into the gameplay scene (`Assets/Scripts/Helper/MainMenuController.cs`, `Assets/Scripts/Helper/AnimationEvents.cs`).
- Sound effect and background music management for explosions, impacts, engine states, and round outcomes (`Assets/Scripts/Helper/AudioController.cs`).

## Tech stack

- **Game Engine**: Unity 2020.3.20f1 (declared in `ProjectSettings/ProjectVersion.txt`).
- **Language**: C# (.NET / Mono scripting runtime).
- **Rendering Pipeline**: Built-in Render Pipeline.
- **Notable Packages / Dependencies** (declared in `Packages/manifest.json`):
  - `com.unity.ugui`: `1.0.0` (Unity UI system for menus, health sliders, buttons)
  - `com.unity.textmeshpro`: `3.0.6` (text rendering)
  - `com.unity.2d.sprite`: `1.0.0` (sprite manipulation)
  - `com.unity.device-simulator`: `3.0.3-preview` (device simulation)
  - `com.unity.timeline`: `1.4.8` (timeline tooling)
  - `com.unity.test-framework`: `1.1.29` (test framework package)
  - `com.unity.ide.rider`: `2.0.7`, `com.unity.ide.visualstudio`: `2.0.11`, `com.unity.ide.vscode`: `1.2.4` (IDE integration)

## Project structure

| Path | What is in it | Classification |
| --- | --- | --- |
| `Assets/Scripts/` | C# scripts for player, enemy, hazards, pickups, UI, audio, and game loop | Own code |
| `Assets/Scenes/` | Unity scenes (`MainMenu.unity`, `Gameplay.unity`) | Own code / Data |
| `Assets/Prefabs/` | Prefab configurations for vehicles, obstacles, pickups, projectiles, and UI | Own code / Data |
| `Assets/Animations/` | Animation clips and animator controllers for camera, panels, and hazards | Own code / Data |
| `Assets/Materials/` | Physics and rendering materials | Own code / Data |
| `Assets/Models/` | 3D FBX models for vehicles, characters, obstacles, and props | Data |
| `Assets/Sounds/` | Audio clips (`.wav`, `.mp3`, `.ogg`) for effects, music, and voice | Data |
| `Assets/Sprites/` | 2D sprites, textures, button icons, and logos | Data |
| `Assets/Lighting/` | Scene lighting settings | Data |
| `Assets/Particle/` | Particle systems and visual effects | Own code / Data |
| `Assets/Packages/2D Casual UI/` | 2D casual UI sprite pack and documentation | Third-party |
| `Assets/JMO Assets/Toony Colors/` | Toony Colors Free v2.0 shaders, demo scene, and material inspector | Third-party |
| `Assets/SimpleFX/` | Particle effects package and demo scene | Third-party |
| `Assets/Fonts/` | Font assets (`GameCubeCartoon-Regular.otf`, `Kraash Black.ttf`) | Third-party / Data |
| `Packages/` | Unity package manager manifest (`Packages/manifest.json`) | Project configuration |
| `ProjectSettings/` | Unity editor settings (`ProjectVersion.txt`, `EditorBuildSettings.asset`, etc.) | Project configuration |

## Running / building

This project is an uncompiled Unity editor project. It has not been compiled or run in this environment.

### Prerequisites

- Unity Hub installed.
- Unity Editor version `2020.3.20f1` installed via Unity Hub.

### Opening in Unity Editor

1. Open **Unity Hub**.
2. Click **Open** or **Add project from disk** and choose the repository root folder (`crush-it`).
3. Select Unity Editor version `2020.3.20f1` if prompted.
4. Allow Unity to import and compile assets.

### Entry Scene & Playing

- Entry scene: `Assets/Scenes/MainMenu.unity` (confirmed as scene 0 in `ProjectSettings/EditorBuildSettings.asset`).
- Open `Assets/Scenes/MainMenu.unity` in the Unity Editor.
- Press the **Play** button in the editor toolbar. Clicking Play triggers the menu camera transition into `Assets/Scenes/Gameplay.unity`.
- **Controls**:
  - `A` / `Left Arrow`: Steer left
  - `D` / `Right Arrow`: Steer right
  - `W` / `Up Arrow`: Accelerate
  - `S` / `Down Arrow`: Decelerate
  - `Space`: Activate collected power-up skill (Rocket, Shield, Magnetize)

### Building the Project

1. In the Unity Editor, select **File > Build Settings...**.
2. Ensure both `Assets/Scenes/MainMenu.unity` (index 0) and `Assets/Scenes/Gameplay.unity` (index 1) are checked.
3. Select the desired platform (e.g., **PC, Mac & Linux Standalone** or **Android**).
4. Click **Build** and choose an output directory.

## Repository notes

- **Status**: Personal learning prototype created to experiment with 3D runner and vehicle combat mechanics.
- **Tests**: No automated test suites or unit test files exist in the project, despite the presence of the Unity test framework package.
- **CI/CD**: No continuous integration or deployment pipelines are configured (no `.github/workflows`).
- **Commit History**: The repository contains two commits (`Initial commit` and `project`), created on September 22, 2022.

## Third-party assets

- `Assets/JMO Assets/Toony Colors/`: Toony Colors Free v2.0 (by Jean Moreno). Provides toon shaders, ramp textures, demo scene, and custom material inspector. Contains `!ToonyColors Readme.txt` (no licence file present).
- `Assets/Packages/2D Casual UI/`: 2D casual user interface graphics and sprites. Contains `readme.rtf` (no licence file present).
- `Assets/SimpleFX/`: Visual particle effects and demo scene. No licence file present.
- `Assets/Fonts/`: Fonts `GameCubeCartoon-Regular.otf` and `Kraash Black.ttf`. No licence files present.
