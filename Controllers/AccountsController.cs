using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration; 
using System.IO; 




namespace Task1.Controllers
{
    public class AccountsController : Controller
    {
        string conn;

        public AccountsController()
        {

            var dbconfig = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            conn = dbconfig["ConnectionStrings:constr"];
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                       con.Open();
                        SqlCommand cmd = new SqlCommand("sp_login", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                        cmd.Parameters.AddWithValue("@password", obj.Password);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return RedirectToAction("Home", "Accounts");
                        }


                        else
                        {
                            ViewBag.error = "EmailID or Password is not correct";
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "something went wrong");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }



        [HttpGet]
        public IActionResult Regrister()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Regrister(RegristerModel obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_insert", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                        cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", obj.ConfirmPassword);
                        cmd.Parameters.AddWithValue("@Dob", obj.Dob);
                        cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                        cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                        cmd.Parameters.AddWithValue("@Dept", obj.Dept);
                        cmd.Parameters.AddWithValue("@Role", obj.Role);
                        cmd.Parameters.AddWithValue("@Fee", obj.Fee);
                        cmd.Parameters.AddWithValue("@Status", obj.Status);
                        cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
                        int x = cmd.ExecuteNonQuery();
                        if (x > 0)
                        {
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("", "something went wrong");
                            return View();
                        }
                    }


                }
                else
                {

                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            finally
            {

            }

            return View();
        }
    }
}
