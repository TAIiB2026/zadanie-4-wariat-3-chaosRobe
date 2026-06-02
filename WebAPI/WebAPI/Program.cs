
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string angularCorsPolicy = "Angular";
            // Add services to the container.
            builder.Services.AddCors(CorsPolicy => 
            {
                CorsPolicy.AddPolicy(name: angularCorsPolicy, policy => 
                {
                    policy.WithOrigins("http://localhost:4109").AllowAnyMethod().AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(angularCorsPolicy);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
