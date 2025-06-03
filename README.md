# Level Map System - Complete MVC Solution

A professional, production-ready level map system for Unity with clean MVC architecture, perfect for mobile and desktop games.

## 🎯 Key Features

- **Complete MVC Architecture** - Clean, maintainable, and extensible code following SOLID principles
- **Automatic Level Progression** - Next level unlocks upon completion with smooth transitions
- **Star Rating System** - Track player performance with 1-3 star ratings
- **Persistent Save System** - Progress saved automatically via PlayerPrefs with corruption resistance
- **Event-Driven Architecture** - Easy integration with existing game systems

## 🔧 Technical Highlights

- **Dependency Injection Ready** - Compatible with Zenject, VContainer, and Extenject
- **Interface-Based Architecture** - Easy testing and mocking capabilities
- **Scalable Performance** - Supports hundreds of levels without performance issues
- **Zero Dependencies** - Works out of the box, DI frameworks are optional

## 🚀 Quick Start

```csharp
// Basic setup example
public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelMapView levelMapView;
    [SerializeField] private LevelMapViewSettings settings;
    
    private ILevelMapController levelMapController;
    
    void Start()
    {
        var model = new LevelMapModel();
        levelMapController = new LevelMapController(model, levelMapView, settings);
        levelMapController.Initialize();
    }
}
```

## 🏗️ Architecture Overview

The system follows the Model-View-Controller (MVC) pattern:

- **Model** (`LevelMapModel`) - Manages level data and game state
- **View** (`LevelMapView`) - Handles UI presentation and user interactions  
- **Controller** (`LevelMapController`) - Coordinates between Model and View

### Core Interfaces

- `ILevelMapController` - Main controller interface
- `ILevelMapModel` - Data management interface
- `ILevelMapView` - UI presentation interface
- `ILevelMapInstaller` - Dependency injection support

## 📚 Documentation

- **Integration Guide** - Step-by-step setup instructions
- **API Reference** - Complete code documentation
- **Best Practices** - Recommended usage patterns
- **Troubleshooting** - Common issues and solutions
- **Examples** - Multiple integration scenarios

## 🔗 Dependency Injection Integration

### Zenject Example
```csharp
public class LevelMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelMapModel>().To<LevelMapModel>().AsSingle();
        Container.Bind<ILevelMapController>().To<LevelMapController>().AsSingle();
    }
}
```

### VContainer Example
```csharp
public class LevelMapLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ILevelMapModel, LevelMapModel>(Lifetime.Singleton);
        builder.Register<ILevelMapController, LevelMapController>(Lifetime.Singleton);
    }
}
```

## 🛠️ Customization

The system is highly customizable through:

- **ScriptableObject Settings** - Visual appearance and behavior
- **Custom Level Data** - Extend `LevelData` for game-specific requirements
- **UI Themes** - Complete visual customization support
- **Event Callbacks** - Hook into any system event for custom logic

## 📄 License

This asset is available on the Unity Asset Store.

---

*Transform your game with a professional level map system that handles all aspects of level progression and UI management. Save weeks of development time with this complete, tested solution.*
