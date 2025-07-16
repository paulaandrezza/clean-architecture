namespace Application.Common.Interfaces
{
    public interface IMigration
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
