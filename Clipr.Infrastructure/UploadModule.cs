using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipr.Modules.Upload.Infrastructure;

public static class UploadModule
{
    public static IServiceCollection AddUploadModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApplication
    }
}
