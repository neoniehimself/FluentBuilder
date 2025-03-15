# FluentBuilder

A class library that helps load properties of TEntity. Consists of two projects:

1. FluentBuilder.Core – Contains the core classes responsible for loading properties and has no dependencies.
2. FluentBuilder.Persistence – Includes the query-building class, compatible with EF Core.

## How to Use

### FluentBuilder.Core

1. Clone/download the project.
2. Open and build the solution.
3. Go to FluentBuilder.Core > bin > Debug >net8.0.
4. Copy the FluentBuilder.Core.dll.
5. Create a lib folder in your project
6. Paste the .dll file.
7. In Visual Studio 2022, right click your project > Add > Reference > Browse.
8. Select and add the .dll file.
9. Use the utility classes to load entity properties.

## FluentBuilder Utility Classes

1. PropertyList<TEntity>
2. IncludeOptions<TEntity>
3. QueryBuilder

## Example Usages
### PropertyList and IncludeOptions 
```csharp
// Option 1
var propList = new PropertyList<TEntity>();
propList.Add(x => x.ObjectA);
var includeOptions = new IncludeOptions<TEntity>(propList);

// Option 2
var includeOpt1 = new IncludeOptions<TEntity>(
       x => x.ObjectA,
       x => x.ObjectB);

// Option 3 - including a child object
var includeOpt2 = new IncludeOptions<TEntity>(
       x => x.ObjectA,
       x => x.ObjectA.ChildObjectA);
```

### QueryBuilder
```csharp
// Generic repository GetByIDAsync() method
public async Task<TEntity?> GetByIDAsync(TEntityID entityID, IncludeOptions<TEntity>? includeOptions = null)
{
    IQueryable<TEntity> query = QueryBuilder.Build(this.dbContext.Set<TEntity>(), includeOptions);
    return await query.SingleOrDefaultAsync(e => EF.Property<TEntityID>(e, this.EntityID)!.Equals(entityID));
}
