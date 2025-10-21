namespace DientesLimpios.Application.Utilidades.Mediator
{
    public class MediatorSimple : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatorSimple(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            throw new NotImplementedException();
        }
    }
}
