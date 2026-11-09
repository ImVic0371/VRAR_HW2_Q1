# Homework 2 — Question 1: Google Cardboard VR Scene

A Unity VR scene developed for the Virtual and Augmented Reality course using the official Google Cardboard XR Plugin.

## Submission Status

As of November 8, 2026, the scene, gaze interaction, and FPS display have been implemented and tested in the Unity Editor on Windows.

My Apple Developer Program enrollment is currently under review. The planned deployment workflow is Unity Build Automation with Ad Hoc signing for installation on my iPhone. iOS build verification, on-device testing, and the required mobile screen recording are pending.

Any Unity Editor demonstration represents desktop testing only and does not replace the required phone recording.

This repository covers Question 1. The completed Python notebook for Questions 2 and 3 is submitted separately.

## Development Environment

- Unity Editor: 6000.6.8f1
- Development platform: Windows
- VR SDK: Official Google Cardboard XR Plugin for Unity
- Target platform: iOS
- Main scene: `Assets/Scenes/HW2_VRScene.unity`

The project dependencies are defined in `Packages/manifest.json`.

## Implemented Features

### Gaze Interaction

The scene contains a golden sphere with custom interaction behavior:

- Looking at the sphere changes its color to cyan and enlarges it.
- Looking away restores its original color and scale.
- A pointer click maintains the highlighted appearance.

The behavior is implemented in `GoldenSphereInteraction.cs` using the Cardboard pointer callbacks `OnPointerEnter`, `OnPointerExit`, and `OnPointerClick`.

### FPS Display

The scene displays two performance measurements:

- **FPS:** the reciprocal of the latest frame's unscaled delta time.
- **Avg (1s):** the number of frames divided by elapsed time over approximately one-second windows.

The text refreshes approximately four times per second. These measurements are implemented in `VRFPSDisplay.cs`.

Editor FPS values describe desktop execution only; phone performance has not yet been measured.

## Main Files

| File | Purpose |
|---|---|
| `Assets/Scenes/HW2_VRScene.unity` | Main assignment scene |
| `Assets/GoldenSphereInteraction.cs` | Custom sphere gaze interaction |
| `Assets/VRFPSDisplay.cs` | Instantaneous and average FPS display |
| `Packages/manifest.json` | Unity package dependencies |
| `ProjectSettings/ProjectVersion.txt` | Required Unity Editor version |

The project uses rendering provided by Unity and the Cardboard package. No custom `.shader` source file was authored for this submission.

## Open the Project

1. Clone or download this repository.
2. Open Unity Hub and add the project folder containing `Assets`, `Packages`, and `ProjectSettings`.
3. Open the project with Unity 6000.6.8f1.
4. Allow Unity to resolve packages and import assets. Git must be available for the Cardboard Git-based package dependency.
5. Open `Assets/Scenes/HW2_VRScene.unity`.
6. Enter Play Mode to inspect the scene and FPS display.

The custom scripts can also be reviewed directly in the `Assets` folder. Full mobile VR behavior, including device orientation tracking and stereoscopic rendering, still requires validation on the target iPhone.

## Planned iOS Deployment

1. Complete Apple Developer Program enrollment.
2. Register the target iPhone and configure the app identifier.
3. Generate the signing certificate and Ad Hoc provisioning profile.
4. Configure the signing credentials in Unity Build Automation.
5. Build and install the application on the registered iPhone.
6. Verify stereoscopic rendering, orientation tracking, gaze interaction, and both FPS measurements.
7. Record the application running on the phone for the assignment.

Signing credentials, private keys, and provisioning files must not be committed to this repository.

## Acknowledgments

This project uses the official Google Cardboard XR Plugin and its sample components, with custom interaction and FPS scripts added for the assignment.

Google Cardboard XR Plugin:
https://github.com/googlevr/cardboard-xr-plugin
