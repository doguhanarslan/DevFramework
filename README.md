# DevFramework

A reusable application framework layer for .NET, built while working through a framework
development course, and consumed by a Northwind sample implemented three ways —
**ASP.NET MVC**, **Web API** and **WCF**.

The point of the project is the `DevFramework.Core` library: the cross-cutting machinery
an application shouldn't reimplement.

## Two ORMs behind one abstraction

`Core/DataAccess` defines `IEntityRepository<T>` and `IQueryableRepository<T>`, then
implements them **twice**:

```
DataAccess/EntityFramework/   EfEntityRepositoryBase · EfQueryableRepository
DataAccess/NHibernate/        NhEntityRepositoryBase · NhQueryableRepository · NHibernateHelper
```

Business code depends only on the interface, so the same service runs against either
Entity Framework or NHibernate (mapped with FluentNHibernate). This is the part of the
project worth reading — it forces the abstraction to be genuinely ORM-agnostic rather
than an EF wrapper with a different name.

## Cross-cutting concerns

| Concern | Implementation |
|---|---|
| **Aspects** | PostSharp — `ExceptionLogAspect`, `PerformanceCounterAspect` |
| **Logging** | Log4Net behind `LoggerService`, with file and database loggers |
| **Caching** | `ICacheManager` with a `MemoryCacheManager` implementation |
| **Validation** | FluentValidation via a `ValidatorTool` aspect |
| **Security** | Custom `Identity`, authentication helpers, MVC security utilities |
| **Mapping** | AutoMapper helper |
| **DI** | Ninject, wired into MVC through a custom controller factory |

Exception logging and performance counting are **aspects**, not try/catch blocks repeated
in every method — a method opts in with an attribute and the behaviour is applied at
compile time.

## Tests

MSTest unit tests covering the business layer (`ProductManagerTests`) and the Entity
Framework repository implementation (`EntityFrameworkTest`).

## Stack

`.NET Framework 4.7.2` `C#` `ASP.NET MVC` `ASP.NET Web API` `WCF` `Entity Framework`
`NHibernate` `FluentNHibernate` `PostSharp` `Log4Net` `AutoMapper` `FluentValidation`
`Ninject` `MSTest`

---

Learning project — the architecture and the abstractions are the deliverable, not the
Northwind domain on top of them.
