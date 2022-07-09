using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.SessionState;

namespace AwpDemo.Models
{
    public class BussnissLayer
    {

        public void AddUser(Users user)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("adduser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@Name";
                paraName.Value = user.Name;
                SqlParameter paraEmail = new SqlParameter();
                paraEmail.ParameterName = "@Email";
                paraEmail.Value = user.Email.ToString();
                SqlParameter paraPassword = new SqlParameter();
                paraPassword.ParameterName = "@Password";
                paraPassword.Value = user.Password;
                SqlParameter paraPhone = new SqlParameter();
                paraPhone.ParameterName = "@Phone";
                paraPhone.Value = user.Phone.ToString();
                SqlParameter paraGender = new SqlParameter();
                paraGender.ParameterName = "@Gender";
                paraGender.Value = user.Gender;
                SqlParameter paraCity = new SqlParameter();
                paraCity.ParameterName = "@City";
                paraCity.Value = user.City;
                cmd.Parameters.Add(paraName);
                cmd.Parameters.Add(paraEmail);
                cmd.Parameters.Add(paraPassword);
                cmd.Parameters.Add(paraPhone);
                cmd.Parameters.Add(paraGender);
                cmd.Parameters.Add(paraCity);

                con.Open();
                cmd.ExecuteNonQuery();


            }


        }
        public int Login(Users user)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("loging", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@Name";
                paraName.Value = user.Name;
                SqlParameter paraPassword = new SqlParameter();
                paraPassword.ParameterName = "@Password";
                paraPassword.Value = user.Password;

                cmd.Parameters.Add(paraName);
                cmd.Parameters.Add(paraPassword);



                con.Open();
                int i;
                i = Convert.ToInt32(cmd.ExecuteScalar());
                return i;


            }
        }

        public IEnumerable<Asks> asks

        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
                //difine list
                List<Asks> asks = new List<Asks>();
                //for connect to db
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SpGetQuestion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // READ TABLE tblEAsk
                    while (rdr.Read())
                    {
                        Asks ask = new Asks();

                        ask.Question = rdr["Question"].ToString();
                        ask.Answer = rdr["Answer"].ToString();
                        ask.UserName = rdr["UserName"].ToString();
                        ask.Id = Convert.ToInt32(rdr["IdMedical"]);

                        asks.Add(ask);

                    }


                }
                return asks;


            }

        }
        public void AddAnswar(Asks ask)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //stored procedure in sql server 2016 db sample 
                SqlCommand cmd = new SqlCommand("SpAddAnswar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // define and add parameter 
                SqlParameter paraAnswer = new SqlParameter();
                paraAnswer.ParameterName = "@Answer";
                paraAnswer.Value = ask.Answer;
                cmd.Parameters.Add(paraAnswer);
                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@Id";
                paraId.Value = ask.Id;
                cmd.Parameters.Add(paraId);

                con.Open();
                cmd.ExecuteNonQuery();


            }


        }
        public void AddQuestion(Asks ask, string UserName)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //stored procedure in sql server 2016  
                SqlCommand cmd = new SqlCommand("SpAdQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // define and add parameter 
                SqlParameter paraQuestion = new SqlParameter();
                paraQuestion.ParameterName = "@Question";
                paraQuestion.Value = ask.Question;
                cmd.Parameters.Add(paraQuestion);
                SqlParameter paraIduser = new SqlParameter();
                paraIduser.ParameterName = "@UserName";
                paraIduser.Value = UserName;
                cmd.Parameters.Add(paraIduser);

                con.Open();
                cmd.ExecuteNonQuery();


            }


        }
        public IEnumerable<Articles> articles

        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
                //define list
                List<Articles> articles = new List<Articles>();
                //for connect to db
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SpGetArticles", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // READ TABLE tblEAsk
                    while (rdr.Read())
                    {
                        Articles article = new Articles();

                        article.ArticleAdress = rdr["ArticleAddress"].ToString();
                        article.Article = rdr["Article"].ToString();


                        article.Visitor = Convert.ToInt32(rdr["Vistor"]);

                        article.Id = Convert.ToInt32(rdr["Id"]);
                        article.ImageName = rdr["ImageName"].ToString();


                        articles.Add(article);

                    }


                }
                return articles;


            }

        }
        public void Increament(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //stored procedure in sql server 2016 db sample 
                SqlCommand cmd = new SqlCommand("SpIncrement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paraid = new SqlParameter();
                paraid.ParameterName = "@Id";
                paraid.Value = id;
                cmd.Parameters.Add(paraid);
                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
        public void AddArticle(Articles articles)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //stored procedure in sql server  
                SqlCommand cmd = new SqlCommand("SpAddArticle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // define and add parameter 
                SqlParameter paraArticleAddress = new SqlParameter();
                paraArticleAddress.ParameterName = "@ArticleAddress";
                paraArticleAddress.Value = articles.ArticleAdress.ToString();

                SqlParameter paraArticle = new SqlParameter();
                paraArticle.ParameterName = "@Article";
                paraArticle.Value = articles.Article.ToString();
                SqlParameter paraImageName = new SqlParameter();
                paraImageName.ParameterName = "@ImageName";
                paraImageName.Value = articles.ImageName.ToString();
                cmd.Parameters.Add(paraArticleAddress);
                cmd.Parameters.Add(paraArticle);
                cmd.Parameters.Add(paraImageName);

                con.Open();
                cmd.ExecuteNonQuery();


            }


        }
        public void Delete(int id)
        {

            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;

            //for connect to db
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SpDelete", con);
                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@Id";
                paraId.Value = id;
                cmd.Parameters.Add(paraId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();

            }


        }
        public List<Asks> Myquestion(string name)

        {

            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            //difine list
            List<Asks> asks = new List<Asks>();
            //for connect to db
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SpGetMyQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paraname = new SqlParameter();
                paraname.ParameterName = "@UserName";
                paraname.Value = name;
                cmd.Parameters.Add(paraname);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                // READ TABLE tblEAsk
                while (rdr.Read())
                {
                    Asks ask = new Asks();

                    ask.Question = rdr["Question"].ToString();
                    ask.Answer = rdr["Answer"].ToString();
                    ask.UserName = rdr["UserName"].ToString();
                    ask.Id = Convert.ToInt32(rdr["IdMedical"]);

                    asks.Add(ask);




                }
                return asks;


            }
        }
        public void EditArticle(Articles articles)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;

            //for connect to db
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SpEdit", con);
                SqlParameter paraArticleAddress = new SqlParameter();
                paraArticleAddress.ParameterName = "@ArcticleAddress";
                paraArticleAddress.Value = articles.ArticleAdress;
                SqlParameter paraArticle = new SqlParameter();
                paraArticle.ParameterName = "@Article";
                paraArticle.Value = articles.Article;
                SqlParameter paraImageName = new SqlParameter();
                paraImageName.ParameterName = "@ImageName";
                paraImageName.Value = articles.ImageName;
                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@Id";
                paraId.Value = articles.Id;
                cmd.Parameters.Add(paraArticleAddress);
                cmd.Parameters.Add(paraArticle);
                cmd.Parameters.Add(paraImageName);
                cmd.Parameters.Add(paraId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();

            }


        }
        public List<Asks> WaittingQuestion()

        {

            string cs = ConfigurationManager.ConnectionStrings["dbuser"].ConnectionString;
            //difine list
            List<Asks> asks = new List<Asks>();
            //for connect to db
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SpGetWaitting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parawaitting = new SqlParameter();
               parawaitting.ParameterName = "@waitting";
                parawaitting.Value = "waitting";
                cmd.Parameters.Add(parawaitting);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                // READ TABLE tblEAsk
                while (rdr.Read())
                {
                    Asks ask = new Asks();

                    ask.Question = rdr["Question"].ToString();
                    ask.Answer = rdr["Answer"].ToString();
                    ask.UserName = rdr["UserName"].ToString();
                    ask.Id = Convert.ToInt32(rdr["IdMedical"]);

                    asks.Add(ask);




                }
                return asks;


            }
        }
    }
}
