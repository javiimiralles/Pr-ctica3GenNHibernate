
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CP.Práctica3;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                //Creacion de clientes
                ClienteCEN clienteCEN = new ClienteCEN ();
                clienteCEN.New_ ("paco@gmail.com", "Paco", "Gomez Miralles", "pacogo", 777777777, "1234");

                //Creacion de pedidos
                PedidoCEN pedidoCEN = new PedidoCEN ();
                int idPed1 = pedidoCEN.New_ ("Calle Manolito", "Elche", "Alicante", 03203, "VISA", "paco@gmail.com");

                //Creacion de generos
                GeneroCEN generoCEN = new GeneroCEN ();
                int idGen1 = generoCEN.New_ ("Rock");

                //Creacion de productos
                ProductoCEN prodCEN = new ProductoCEN ();
                int idProd1 = prodCEN.New_ ("Disco1", "AAAAAA", 9.90, 7);

                //Creacion de lineas de pedido
                LineaPedidoCP linPedCP = new LineaPedidoCP ();
                linPedCP.New_ (idProd1, idPed1, 2);

                //Creacion de listas de deseos
                ListaDeseosCEN listaCEN = new ListaDeseosCEN ();
                listaCEN.New_ ("paco@gmail.com");

                //Creacion de comentarios
                ComentariosCEN comentCEN = new ComentariosCEN ();
                comentCEN.New_ ("Muy buen producto", "paco@gmail.com", idProd1);

                //Creacion de valoraciones de usuarios
                ValoracionClienteCP valCP = new ValoracionClienteCP ();
                valCP.New_ (4.5, "paco@gmail.com", idProd1);

                //Probamos los metodos creados
                //Incrementar y decrementar stock
                prodCEN.DecrementarStock(idProd1, 2); //El stock es de 7, y le decrementamos 2
                ProductoEN prodStockDecEN = new ProductoCAD().ReadOIDDefault(idProd1);
                Console.WriteLine("Decremento de stock: " + prodStockDecEN.Stock);

                prodCEN.AumentarStock(idProd1, 3); //El stock es de 5, y le incrementamos 3
                ProductoEN prodStockIncEN = new ProductoCAD().ReadOIDDefault(idProd1);
                Console.WriteLine("Incremento de stock: " + prodStockIncEN.Stock);

                //Incrementar y decrementar precio
                prodCEN.DecrementarPrecio(idProd1, 3.50); //El precio es de 9.90, y le decrementamos 3.50
                ProductoEN prodPrecioDecEN = new ProductoCAD().ReadOIDDefault(idProd1);
                Console.WriteLine("Decremento de precio: " + prodPrecioDecEN.Precio);

                prodCEN.AumentarPrecio(idProd1, 7.50); //El precio es de 6.40, y le incrementamos 7.50
                ProductoEN prodPrecioIncEN = new ProductoCAD().ReadOIDDefault(idProd1);
                Console.WriteLine("Incremento de precio: " + prodPrecioIncEN.Precio);

                //Realizar un pago
                pedidoCEN.RealizarPago(idPed1, "5555555", "VISA");
                PedidoEN pedidoPagadoEN = new PedidoCAD().ReadOIDDefault(idPed1);
                Console.WriteLine("Estado del pedido -> " + pedidoPagadoEN.Estado); //Comprobamos que el pedido esta en reparto
                Console.WriteLine("Fecha del pedido -> " + pedidoPagadoEN.FechaPedido); //Comprobamos que se ha cambiado la fecha del pedido

                //Cambiar estado de un pedido
                pedidoCEN.CambiarEstado(idPed1);
                PedidoEN pedidoEntregadoEN = new PedidoCAD().ReadOIDDefault(idPed1);
                Console.WriteLine("Estado del pedido -> " + pedidoEntregadoEN.Estado); //Comprobamos que el pedido se ha entregado
                Console.WriteLine("Fecha de la entrega -> " + pedidoEntregadoEN.FechaEntrega); //Comprobamos que se ha cambiado la fecha de la entrega

                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
