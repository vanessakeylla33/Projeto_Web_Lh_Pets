namespace Projeto_Web_Lh_Pets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/index", (HttpContext contexto) => "Projeto web - LH Pets versão 1");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext contexto) => {
            contexto.Response.Redirect("index.html", false);
        });

        Banco dba=new Banco();
        app.MapGet("/listClientes",(HttpContext contexto) =>{

            contexto.Response.WriteAsync(dba.GetListaString());

        });

        app.Run();
    }
}
