using MauiTwitterApp.Features.Timeline.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiTwitterApp.Services;

internal interface ITweetsService
{
    Task<bool> SignInAsync();

    Task<IEnumerable<Timeline>> GetUserTimeline();

    Task<Client> GetClientAsync();
}
