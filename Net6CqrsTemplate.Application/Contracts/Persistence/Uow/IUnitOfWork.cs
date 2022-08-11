namespace Net6CqrsTemplate.Application.Contracts.Persistence.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        public IValueRepository ValueRepository { get; set; }

        Task<int> Complete();
    }
}
