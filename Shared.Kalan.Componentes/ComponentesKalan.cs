using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.DependencyInjection;
using Shared.Componentes;
using Shared.Utilerias.Excel;
using Shared.Utilerias.Traductor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace Shared.Kalan.Componentes
{
	public static class ExtensionMethods
	{
		public static IServiceCollection AddComponentesKalan(this IServiceCollection services)
		{
			services.AddFileReaderService();
			services.AddScoped<Excel>();
			services.AddSweetAlert2();
			services.AddScoped<UserService>();
			services.AddScoped<LoadingService>();
			services.AddScoped<TranslatorService>();
			return services;
		}
	}
}
