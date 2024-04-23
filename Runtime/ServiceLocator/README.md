# Unity Service Locator
## Overview

This repository contains a Service Locator implementation for Unity, designed to manage dependencies across different scopes – individual game objects, scenes, and globally. The Service Locator pattern, while often considered an anti-pattern, can be a practical solution in certain Unity development scenarios, providing a centralized point for service registration and retrieval.

### Features

- Manage services at GameObject, Scene, and Global levels.
- Supports Dependency Inversion and Inversion of Control principles.
- Simplifies dependency management in Unity projects.
- Easy-to-use API for service registration and retrieval.

## Getting Started

### Prerequisites

- Unity Editor (Version 2022 or later recommended)

## Example Usage

```csharp
// Registering Services
ServiceLocator.Register<YourGlobalService>(new YourGlobalService()); // Global Scope
ServiceLocator.ForSceneOf(this).Register<YourSceneService>(new YourSceneService()); // Scene Scope
ServiceLocator.For(this).Register<YourGameObjectService>(new YourGameObjectService()); // GameObject Scope

// Retrieving Services
YourGlobalService globalService;
ServiceLocator.Global.Get(out globalService); // Global Service

YourSceneService sceneService;
ServiceLocator.ForSceneOf(this).Get(out sceneService); // Scene Service

YourGameObjectService gameObjectService;
ServiceLocator.For(this).Get(out gameObjectService); // GameObject Service
```
