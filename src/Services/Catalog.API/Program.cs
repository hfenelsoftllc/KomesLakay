var builder = WebApplication.CreateBuilder(args);

//Add Services to the container.



var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.Run();
