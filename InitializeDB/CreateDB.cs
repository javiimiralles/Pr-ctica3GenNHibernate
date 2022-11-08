
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
#pragma warning disable CS0105 // La directiva using para 'System.Collections.Generic' aparece previamente en este espacio de nombres
using System.Collections.Generic;
#pragma warning restore CS0105 // La directiva using para 'System.Collections.Generic' aparece previamente en este espacio de nombres
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CP.Práctica3;
using Práctica3GenNHibernate.Enumerated.Práctica3;

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
                //Creacion de generos
                GeneroCEN generoCEN = new GeneroCEN ();
                generoCEN.New_ ("Rock");
                generoCEN.New_("Pop");
                generoCEN.New_("Rap");

                //Creacion de clientes
                ClienteCEN clienteCEN = new ClienteCEN ();
                clienteCEN.New_ ("paco@gmail.com", "Paco", "Gomez Miralles", "pacogo", 777777777, "1234");
                clienteCEN.New_ ("pere@gmail.com", "Pere", "Milla", "pere", 777777777, "1234");
                clienteCEN.New_ ("lucas@gmail.com", "Lucas", "Boye", "lucasbo", 777777777, "1234");

                clienteCEN.AsignarGeneroFav("paco@gmail.com", "Rock");

                //Creacion de pedidos
                PedidoCEN pedidoCEN = new PedidoCEN ();
                PedidoCP pedidoCP = new PedidoCP ();
                int idPed1 = pedidoCEN.New_ ("Calle Manolito", "Elche", "Alicante", 03203, "VISA", "paco@gmail.com");
                int idPed2 = pedidoCEN.New_ ("Calle Manolita", "Alicante", "Alicante", 03204, "VISA", "pere@gmail.com");
                int idPed3 = pedidoCEN.New_ ("Calle Juan", "Benidorm", "Alicante", 03204, "VISA", "paco@gmail.com");

                //Creacion de productos
                ProductoCEN prodCEN = new ProductoCEN ();
                int idProd1 = prodCEN.New_ ("Disco1", "AAAAAA", 9.90, 7);
                int idProd2 = prodCEN.New_ ("Disco2", "BBBBB", 9.90, 5);
                int idProd3 = prodCEN.New_ ("Disco3", "CCCCC", 9.90, 6);

                prodCEN.AsignarGenero(idProd1, "Rock");


                //Creacion de lineas de pedido
                LineaPedidoCP linPedCP = new LineaPedidoCP ();
                linPedCP.New_ (idProd1, idPed1, 2);
                linPedCP.New_ (idProd1, idPed2, 3);
                linPedCP.New_ (idProd1, idPed3, 6);

                //Creacion de listas de deseos
                ListaDeseosCEN listaCEN = new ListaDeseosCEN ();
                listaCEN.New_ ("paco@gmail.com");

                //Creacion de comentarios
                ComentariosCEN comentCEN = new ComentariosCEN ();
                comentCEN.New_ ("Muy buen producto", "paco@gmail.com", idProd1);

                //Creacion de valoraciones de usuarios
                ValoracionClienteCP valCP = new ValoracionClienteCP ();
                valCP.New_ (4.5, "paco@gmail.com", idProd1);
                valCP.New_ (3, "lucas@gmail.com", idProd1);
                valCP.New_ (2, "pere@gmail.com", idProd1);

                valCP.New_ (4, "paco@gmail.com", idProd2);
                valCP.New_ (3, "lucas@gmail.com", idProd2);
                valCP.New_ (4, "pere@gmail.com", idProd2);

                valCP.New_ (1, "paco@gmail.com", idProd3);
                valCP.New_ (2, "lucas@gmail.com", idProd3);
                valCP.New_ (1, "pere@gmail.com", idProd3);

                //-----------------Probamos los metodos creados-----------------------------
                //Incrementar y decrementar stock
                Console.WriteLine ("-------------------Incrementar y decrementar stock------------------------");
                Console.WriteLine ("Stock inicial = 7");
                prodCEN.DecrementarStock (idProd1, 2); //El stock es de 7, y le decrementamos 2
                ProductoEN prodStockDecEN = new ProductoCAD ().ReadOIDDefault (idProd1);
                Console.WriteLine ("Decremento de stock: " + prodStockDecEN.Stock);

                Console.WriteLine ("Stock inicial = 5");
                prodCEN.AumentarStock (idProd1, 3); //El stock es de 5, y le incrementamos 3
                ProductoEN prodStockIncEN = new ProductoCAD ().ReadOIDDefault (idProd1);
                Console.WriteLine ("Incremento de stock: " + prodStockIncEN.Stock + "\n");

                //Incrementar y decrementar precio
                Console.WriteLine ("-------------------Incrementar y decrementar precio------------------------");
                Console.WriteLine ("Precio inicial = 9.90");
                prodCEN.DecrementarPrecio (idProd1, 3.50); //El precio es de 9.90, y le decrementamos 3.50
                ProductoEN prodPrecioDecEN = new ProductoCAD ().ReadOIDDefault (idProd1);
                Console.WriteLine ("Decremento de precio: " + prodPrecioDecEN.Precio);

                Console.WriteLine ("Precio inicial = 6.40");
                prodCEN.AumentarPrecio (idProd1, 7.50); //El precio es de 6.40, y le incrementamos 7.50
                ProductoEN prodPrecioIncEN = new ProductoCAD ().ReadOIDDefault (idProd1);
                Console.WriteLine ("Incremento de precio: " + prodPrecioIncEN.Precio + "\n");

                //Realizar un pago
                Console.WriteLine ("-------------------Realizar un pago------------------------");
                pedidoCP.RealizarPago (idPed1, "paco@gmail.com", "5555555", "VISA");
                PedidoEN pedidoPagadoEN = new PedidoCAD ().ReadOIDDefault (idPed1);
                Console.WriteLine ("Estado del pedido -> " + pedidoPagadoEN.Estado); //Comprobamos que el pedido esta en reparto
                Console.WriteLine ("Fecha del pedido -> " + pedidoPagadoEN.FechaPedido + "\n"); //Comprobamos que se ha cambiado la fecha del pedido
                // Más adelante se muestra como el usuario que ha realizado el pago ha obtenido un punto por su compra
                // Ver ObtenerClientesSinPuntos()

                //Cambiar estado de un pedido
                Console.WriteLine ("-------------------Cambiar estado de un pedido------------------------");
                pedidoCEN.CambiarEstado (idPed1);
                PedidoEN pedidoEntregadoEN = new PedidoCAD ().ReadOIDDefault (idPed1);
                Console.WriteLine ("Estado del pedido -> " + pedidoEntregadoEN.Estado); //Comprobamos que el pedido se ha entregado
                Console.WriteLine ("Fecha de la entrega -> " + pedidoEntregadoEN.FechaEntrega + "\n"); //Comprobamos que se ha cambiado la fecha de la entrega


                //FiltrarPorValoracion()
                Console.WriteLine ("-------------------Filtrar productos por valoracion media------------------------");
                IList<ProductoEN> listaProductos = prodCEN.FiltrarPorValoracion ();
                foreach (ProductoEN prod in listaProductos) {
                        Console.WriteLine (prod.Nombre + "-> Valoracion: " + prod.ValoracionMedia);
                }
                Console.WriteLine ("\n");

                //ObtenerClientesSinPuntos()
                Console.WriteLine ("-------------------Obtener clientes sin puntos------------------------");
                IList<ClienteEN> listaClientes = clienteCEN.ObtenerClientesSinPuntos ();
                Console.WriteLine ("Clientes sin puntos: ");
                foreach (ClienteEN cli in listaClientes) {
                        Console.WriteLine (cli.Email);
                }
                Console.WriteLine ("\n");


                //FiltarPedidoPorProducto()
                Console.WriteLine ("-------------------Filtrar pedidos por productos------------------------");
                IList<PedidoEN> listaPedidos = pedidoCEN.FiltrarPedidoPorProducto (idProd1);
                Console.WriteLine ("Lista de pedidos que tienen el producto: Disco1 ");
                foreach (PedidoEN ped in listaPedidos) {
                        Console.WriteLine ("ID del pedido: " + ped.Id);
                        Console.WriteLine ("Direccion: " + ped.Direccion);
                        Console.WriteLine ("Precio total del pedido: " + ped.PrecioTotal);
                }
                Console.WriteLine ("\n");

                //ObtenerProductosPorGeneroFav
                Console.WriteLine ("-------------------Obtener productos por genero favorito------------------------");
                IList<ProductoEN> listaFavs = prodCEN.ObtenerProductosPorGeneroFav("paco@gmail.com");
                Console.WriteLine("Productos recomendados para paco@gmail.com");
                foreach(ProductoEN prod in listaFavs)
                {
                    Console.WriteLine(prod.Nombre);
                }


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
