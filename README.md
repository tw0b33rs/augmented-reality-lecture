# Augmented Reality Lecture Examples

This repository provides Augmented Reality examples based on AR Foundation and the Vuforia Engine. The projects are ready to be build for either iOS or Android.

## Requirements
- Unity 2021.3.16f1 with
    - Android Build Support
    - iOS Build Support
- IDE with C# support, e.g. [Visual Studio Code](https://code.visualstudio.com/docs/other/unity)
- Blender
- (optional) Vuforia license key

## Overview

The main scope of the provided examples is to provide an overview of state-of-the-art AR features, like image tracking, model tracking and basic interaction with the environment and virtual objects.

The lecture is being taught at the [University of Applied Sciences Upper Austria](https://www.fh-ooe.at/en/) in the field of [Mechatronics & Business Management](https://www.fh-ooe.at/en/wels-campus/studiengaenge/bachelor/mechatronics-and-business-management/).

# Detailed description of provided examples

Most examples are based on the [Vuforia Engine](https://library.vuforia.com/), since this library provides one of the best ways of getting started with Augmented Reality development. However, some examples are based on the [AR Foundation](https://unity.com/unity/features/arfoundation) framework.

## Vuforia Engine

The Vuforia Engine offers a variety of AR features and most of those are covered in this repository. An extensive list can be found here: https://library.vuforia.com/getting-started/vuforia-features

### Image Targets

### Model Targets

Real objects can be recognized, tracked and overlayed with virtual assets. This can be helpful to display information which is not visible otherwise.

![](images/bmw_model_target.gif)
![](images/model_target.gif)

### VuMarks

### Area Targets

### Ground plane

Recognizing the ground plane enables the placement of virtual 3D objects, like a robot.

![](images/robot.gif)

## Unity Foundation

