using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class MainBook
    {
        public static void Main()
        {
            Disconnectedarchitecture();
            //GetAllCustomersWithOrder_EagerLoading();
            //AddnewcustomerAndOrder();
            //RemoveNewBook();
            //Console.ReadLine();
        }



        //private static void AddnewcustomerAndOrder()
        //{
        //    var ctx = new BookContext();

        //    Customer customer = new Customer();
        //    customer.ID = 1;
        //    customer.Name = "KGF";
        //    customer.Age = 38;

        //    Order ord = new Order();
        //    ord.Order_ID = 100;
        //    ord.Amount = 2000;
        //    ord.OrderDate = DateTime.Now;

        //    ord.cust = customer;
        //    try
        //    {
        //        ctx.Orders.Add(ord);
        //        ctx.SaveChanges();
        //        Console.WriteLine("Customer and Order is Created");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException.ToString());
        //    }

        //}

        //private static void GetAllCustomersWithOrder_EagerLoading()
        //{
        //    //Eager loading means that the related data is loaded
        //    //from the database as part of the initial query.
        //    var ctx = new BookContext();
        //    try
        //    {
        //        var customers = ctx.Customers.Include("Orders");

        //        //var customers = ctx.Customers.Include(o => o.Orders);

        //        foreach (var customer in customers)
        //        {
        //            Console.WriteLine(customer.Name);
        //            Console.WriteLine("----->");


        //            foreach (var order in customer.Orders)
        //            {
        //                Console.WriteLine(order.Amount.ToString() + " " + order.Order_ID);
        //            }
        //            Console.WriteLine("-----");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}


        //private static void GetAllCustomersWithOrder_ExplicitLoading()
        //{
        //    //Explicit loading means that the related data is
        //    //explicitly loaded from the database at a later time.
        //    //Needs MARS to be set to TRUE in connection string
        //    var ctx = new BookContext();
        //    try
        //    {
        //        var customers = ctx.Customers;

        //        foreach (var customer in customers)
        //        {
        //            Console.WriteLine(customer.Name);
        //            Console.WriteLine("----->");

        //            ctx.Entry(customer).Collection(o => o.Orders).Load();

        //            foreach (var order in customer.Orders)
        //            {
        //                Console.WriteLine(order.Amount.ToString() + " " + order.OrderDate.ToString());

        //            }
        //            Console.WriteLine("-----");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }



            private static void Disconnectedarchitecture()
            {
                var ctx = new BookContext();

                var customer = ctx.Customers.Where(c => c.ID == 1).SingleOrDefault();

                ctx.Dispose();

                UpdateCustomerName(customer);
            }

            private static void UpdateCustomerName(Customer customer)
            {
                var ctx = new BookContext();
                customer.Name = "Mike";
                Console.WriteLine(ctx.Entry(customer).State.ToString());
                //ctx.Update<Customer>(customer);
                //OR
                ctx.Update(customer);
                //OR
                //ctx.Customers.Update(customer);
                //OR

                // ctx.Attach(customer).State = EntityState.Modified;
                ctx.SaveChanges();
                Console.WriteLine("customer name is updated via disconnected mode");

            }

            //private static void AddNewBook()
            //{
            //    var ctx = new BookContext();
            //    Book book3 = new Book();
            //    book3 = new Book();
            //    book3.BookID = 17;
            //    book3.BookName = "Everybody with Python";
            //    book3.author = "Mictchell";
            //    book3.price = 222;



            //    try
            //    {
            //        ctx.Books.Add(book3);
            //        ctx.SaveChanges();
            //        Console.WriteLine("New Book Added  successfully");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.InnerException.Message);
            //    }
            //}

            //private static void UpdateBook()
            //{
            //    var ctx = new BookContext();
            //    var book = ctx.Books.Where(e => e.BookID == 17).SingleOrDefault();

            //    try
            //    {
            //        book.BookName = "python";
            //        ctx.Update(book);
            //        ctx.SaveChanges();
            //        Console.WriteLine("Updated successfully");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.InnerException.Message);
            //    }
            //}

            //private static void RemoveNewBook()
            //{
            //    var ctx = new BookContext();
            //    var book = ctx.Books.Where(e => e.BookID == 17).SingleOrDefault();


            //    try
            //    {
            //        object value = ctx.Books.Remove(book);
            //        ctx.SaveChanges();
            //        Console.WriteLine("Book removed");
            //    }

            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.InnerException.Message);
            //    }
            //}

            //private static void GetAllBookDetails()
            //{
            //    var ctx = new BookContext();
            //    var book = ctx.Books;
            //    foreach (var e in book)
            //    {
            //        Console.WriteLine(e.BookName);
            //    }
            //}
        }
    }

    

