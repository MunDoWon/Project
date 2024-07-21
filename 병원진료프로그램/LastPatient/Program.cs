using LastPatient.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//���Ǳ���� �߰��ϰ� ������ AddSesion()�� ����ϼ���.
builder.Services.AddSession(); //�ܼ� ����

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<PatientDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//���Ǳ���� ��� �Ϸ��� �� �ۼ��ؾ� �մϴ�. build�� �ɼ��� ���״�� �ɼ� �������� ���� ������ app.UseSession()�� ���ؼ� ���� ����� �����մϴ�.
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Main}/{id?}");

app.Run();
