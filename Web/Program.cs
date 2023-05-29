using WarehouseApi2.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://localhost:7188/Show/Stock");
if (response.IsSuccessStatusCode)
{
    // Получить строку JSON из ответа
    string json = await response.Content.ReadAsStringAsync();
    // Десериализовать строку JSON в объект Stock
    Stock stock = JsonConvert.DeserializeObject<Stock>(json);
    // Вывести свойства объекта Stock в консоль
    Console.WriteLine($"Name: {stock.id_product}");
    Console.WriteLine($"Price: {stock.id_warehouse}");
    Console.WriteLine($"Quantity: {stock.quanity}");
}
else
{
    // Вывести код состояния и сообщение об ошибке в консоль
    Console.WriteLine($"Status code: {response.StatusCode}");
    Console.WriteLine($"Error message: {response.ReasonPhrase}");
}

Console.WriteLine("!");

app.Run();
