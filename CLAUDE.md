# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Unity 6 (6000.1.2f1) VR carnival game targeting Windows 64-bit standalone. Three mini-games: Plinko, Wheel of Fortune, and Coin Toss. Uses C# 9.0 / .NET Standard 2.1.

## Build & Development

This is a Unity project — there is no CLI build command. Open in Unity Editor via `Proyecto VR.sln` or load the project folder directly. Scripts compile automatically in the editor.

- **Main scene:** `Assets/Scenes/Carnival.unity`
- **Test framework:** `com.unity.test-framework` 1.5.1 is installed but no custom tests exist yet
- **IDE config:** VS Code settings in `.vscode/settings.json`

## Key Packages

- **Rendering:** Universal Render Pipeline (URP 17.1.0) — settings in `Assets/Settings/`
- **Input:** New Input System 1.14.0 — mappings in `Assets/InputSystem_Actions.inputactions`
- **UI:** TextMeshPro via URP
- **VR:** Unity XR modules enabled

## Architecture

### Score System (Singleton)
`CarnivalScores` is the central singleton managing all game scores. All three mini-games report scores through it. It updates TMP UI displays and triggers a teddy bear reward at 2000+ points.

### Event-Driven Game Flow
Mini-games communicate via C# delegates/events:
- `CarnivalNeedle.OnSpokeHit` → wheel score result
- `CoinTossCoin.OnCoinMissed` → missed coin handling
- `CarnivalCoinTossPlatform` → landed coin scoring

### Mini-Game Scripts
| Game | Key Scripts |
|------|------------|
| Plinko | `CarnivalPlinko.cs`, `PlinkoCoin.cs`, `PlinkoWin.cs` |
| Wheel | `CarnivalWheel.cs`, `CarnivalNeedle.cs` |
| Coin Toss | `CarnivalCoinToss.cs`, `CoinTossCoin.cs`, `CarnivalCoinTossPlatform.cs`, `CarnivalPowerSlider.cs` |
| Shared | `CarnivalScores.cs`, `ScoreHighlight.cs` |

All scripts are in `Assets/Scripts/`. Coroutines drive animations (wheel spin, power slider, score highlights). Physics interactions use Rigidbody + collision/trigger callbacks.

### VR Integration
Coin Toss uses a `VRView` camera reference for head-relative positioning. Input actions support VR controllers.

## Rendering Profiles
Two URP profiles exist in `Assets/Settings/`:
- `PC_RPAsset` — desktop quality
- `Mobile_RPAsset` — mobile optimization
