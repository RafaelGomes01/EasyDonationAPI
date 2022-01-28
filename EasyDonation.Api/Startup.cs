using EasyDonation.Dominio.Commands.Usuario;
using EasyDonation.Dominio.Handlers.Autenticacao;
using EasyDonation.Dominio.Handlers.Categoria;
using EasyDonation.Dominio.Handlers.Doacao;
using EasyDonation.Dominio.Handlers.Usuarios;
using EasyDonation.Dominio.Repositorios;
using EasyDonation.Infra.Data.Contexts;
using EasyDonation.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //services.AddDbContext<EasyDonationContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Data Source=.\\SQLEXPRESS;Initial Catalog=EasyDonation;Integrated Security=true")));
            services.AddDbContext<EasyDonationContext>(options => options.UseSqlServer("Data Source=easydonationsrv.database.windows.net ;Initial Catalog=EasyDonationDB;User Id=rafaelgomes; Password=Senai@132"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "EasyDonation",
                    ValidAudience = "EasyDonation",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EasyDonation-security-key"))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyDonation.Api", Version = "v1" });
            });

            // Injeção de dependencias
            #region Usuarios
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CriarUsuarioHandler, CriarUsuarioHandler>();
            services.AddTransient<LogarHandler, LogarHandler>();
            services.AddTransient<DeletarUsuarioHandler, DeletarUsuarioHandler>();
            services.AddTransient<BuscarUsuarioPeloIdHandler, BuscarUsuarioPeloIdHandler>();
            services.AddTransient<ListarUsuariosHadle, ListarUsuariosHadle>();
            services.AddTransient<BuscarUsuarioPeloNomeHandler, BuscarUsuarioPeloNomeHandler>();
            #endregion

            #region Doações 
            services.AddTransient<IDoacaoRepositorio, DoacaoRepositorio>();
            services.AddTransient<BuscarDoacaoPeloIdHandler, BuscarDoacaoPeloIdHandler>();
            services.AddTransient<CriarDoacaoHandler, CriarDoacaoHandler>();
            services.AddTransient<DeletarDoacaoHandler, DeletarDoacaoHandler>();
            services.AddTransient<ListarDoacoesHandle, ListarDoacoesHandle>();
            #endregion

            #region Categorias
            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddTransient<BuscarCategoriaPeloIdHandler, BuscarCategoriaPeloIdHandler>();
            services.AddTransient<CriarCategoriaHandler, CriarCategoriaHandler>();
            services.AddTransient<DeletarCategoriaHandler, DeletarCategoriaHandler>();
            services.AddTransient<ListarCategoriasHandle, ListarCategoriasHandle>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyDonation.Api v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
