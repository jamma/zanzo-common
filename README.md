# zanzo-common
<h1>Common library for Zanzo Studios game projects</h1>

<h2>Overview</h2>
There are two main motivations for the overall design of this code:

1. Abstract the concept of "active" from Unity's behavior on calling GameObject.SetActive()
2. Facilitate the pooling of categories of objects

It is important to note that flexibility is not a primary goal for this design. I adapt my game designs to fit to this pattern.


The focus of this code review will be 3 files:

* **ZanzoObject** - Replaces MonoBehaviour as the base class of all components
  * https://github.com/jamma/zanzo-common/blob/main/unity/Common/ZanzoObject.cs
* **ResourceDomain** - Holds collections of ZanzoObject pools
  * https://github.com/jamma/zanzo-common/blob/main/unity/Common/ResourceDomain.cs
* **ZanzoObjectManager** - Wrapper class for ResourceDomain that also tracks all currently active objects
  * https://github.com/jamma/zanzo-common/blob/main/unity/Common/ZanzoObjectManager.cs

**ZanzoObject**  
This class replaces MonoBehaviour as the base class for all components, and has two additional purposes:

1. It redefines the concept of "active" in Unity, separating out the ability to flag an object as active/inactive without modifying its gameObject.activeSelf flag. The primary reason for this is so that the object can be flagged as inactive in MonoBehaviour::Update() without causing conflicts with the physics engine. Modifying the gameObject.activeSelf flag has been abstracted into two methods, Display (true) and Hide (false). This behavior can be overridden in subclasses as needed.

2. It introduces the concept of being retained. The two methods Retain() / Release() flag the object's current retained state. This is used in conjunction with ResourceDomain and ZanzoObjectManager to create pools of objects.

**ResourceDomain**  
This class holds pools of ZanzoObjects. It's designed to hold multiple pools but works just fine with just one. An single enum is used to access all pools, where an enum entry represents a single pool. In other words, if there are pools for three different types of enemies, the enum EnemyType would map to each pool like this:

* EnemyType.One => Enemy 1
* EnemyType.Two => Enemy 2
* EnemyType.Three => Enemy 3

Items are retained from this pool by calling ResourceDomain.Retain() with an enum value:

```csharp
var enemy = ResourceDomain.Retain(EnemyType.Three)
```

Items are released by calling Release() with the retained item.
```csharp
ResourceDomain.Release(enemy);
```

**ZanzoObjectManager**  
A wrapper around ResourceDomain that adds some helper functionality for creating pools, and tracks all currently active objects. Active object tracking is performed by listening to Activate/Deactivate events emitted by ZanzoObjects.

Pools can be initialized by passing a key (enum entry), Unity prefab, and int representing the total number of prefab instances to create:

```csharp
ZanzoObjectManager.InitializePool(EnemyType.One, enemyOnePrefab, 25);
```

Object initialization can be customized by overriding the method below, which is called soon after the object's instantiation:

```csharp
ZanzoObjectManager.InitializeResource(Enemy enemy)
```

Custom behavior on object activation/deactivation can be handled by overriding the two methods:

```csharp
public virtual void OnResourceActivated(ZanzoObject target)
public virtual void OnResourceDeactivated(ZanzoObject target)
```
