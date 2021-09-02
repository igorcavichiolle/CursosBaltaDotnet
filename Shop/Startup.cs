using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shop.Data;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Contrutor recebe os parametros de Configuration vindo do arquivo appsettings.json
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Possibilitando requisições localhost sem problemas
            services.AddCors();

            //Comprimindo o JSON antes de enviar para a Tela, HTML Descompacta 
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            //Cacheando a aplicação
            //services.AddResponseCaching();

            //Adiciona os controladores para utilizar os Controllers do MVC em nossa API
            services.AddControllers();

            //Transformando a nossa chave do Settings.Secret em um Array de Bytes
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            //Utilizando a Authenticação via token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Passando o datacontext do nosso banco para nossa aplicação
            //Explicitando o tipo de banco que estamo utilizando UseInMemoryDatabase
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

            //Configurando o SqlServer para o entityframwork
            // services.AddDbContext<DataContext>(
            //     opt => opt.UseSqlServer(
            //         Configuration.GetConnectionString("connectionString")
            //     )
            // );

            //-------NÃO É MAIS NECESSARIO --------
            ///------AddDbContext já faz isso automatico
            //Garante que teremos apenas um datacontext por requisição
            //Após uma requisição, é criado um datacontext e passado para o método
            //Sempre criando um novo datacontext, garatimos que apenas uma conexão será aberta por vez
            //Quando a requisição acaba, o AddScoped destroi nosso datacontext, fechando a conexao com o banco
            //services.AddScoped<DataContext, DataContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            //Verificar se a variavel de ambiente está setada para desenvolvimento ou prokdução
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop v1"));
            }

            //Possibilita servir HTTPs
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1");
            });

            //Possibilita utilizar o roteamento do ASP.NET MVC
            app.UseRouting();

            //Possibilita chamadas sem problemas para localhost
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //Possibilita o uso de autorização nas requisições
            app.UseAuthorization();

            //Utilizando a autenticação via token para as requisições
            app.UseAuthentication();

            //Utiliza as URLs para mapear nossos controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
