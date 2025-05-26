var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<MitFin_Api.DBAccess.DBConnection>();// Register Oracle DB connection 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// **add this**:
builder.Services.AddScoped<MitFin_Api.Inventory.CommittedMaterialInterface, MitFin_Api.Inventory.CommittedMaterialRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
