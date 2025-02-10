var builder = WebApplication.CreateBuilder(args);

//Add Services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(connectionString: builder.Configuration.GetConnectionString("Database")!);
    //opts.AutoCreateSchemaObjects = AutoCreate.All;
    //opts.Schema.For<Product>().Index(x => x.Id, x => x.Unique = true);
}).UseLightweightSessions();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapCarter();

app.Run();
