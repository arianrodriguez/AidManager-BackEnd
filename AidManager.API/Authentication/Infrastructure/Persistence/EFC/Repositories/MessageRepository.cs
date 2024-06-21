using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace AidManager.API.Authentication.Infrastructure.Persistence.EFC.Repositories;

public class MessageRepository(AppDBContext context) : BaseRepository<Message>(context), IMessageRepository
{
    
}