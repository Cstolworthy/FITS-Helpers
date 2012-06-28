namespace Interfaces.Marker
{
    /// <summary>
    /// Aggregate root is the root of a domain model tree. Aggregate roots should be retrieved and saved using
    /// repositories. There should be one repository per aggregate root. Aggregate roots are also entities.
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        
    }
}