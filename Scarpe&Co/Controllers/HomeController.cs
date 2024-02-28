using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Scarpe_Co.Models;
using static Scarpe_Co.Models.Articolo;

namespace Scarpe_Co.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ToString();

        public ActionResult Vetrina()
        {
            List<Articolo> prodottiInVendita = new List<Articolo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Articoli WHERE InVendita = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Articolo prodotto = new Articolo
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Prezzo = Convert.ToDecimal(reader["Prezzo"]),
                                DescrizioneDettagliata = reader["DescrizioneDettagliata"].ToString(),
                                ImmagineCopertina = reader["ImmagineCopertina"].ToString(),
                                ImmagineAggiuntiva1 = reader["ImmagineAggiuntiva1"].ToString(),
                                ImmagineAggiuntiva2 = reader["ImmagineAggiuntiva2"].ToString(),
                                InVendita = Convert.ToBoolean(reader["InVendita"])
                            };

                            prodottiInVendita.Add(prodotto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Errore durante il recupero dei dati: {ex.Message}";
            }

            return View(prodottiInVendita);
        }

        public ActionResult Details(int id)
        {
            Articolo prodottoDettaglio = GetProdottoById(id);

            if (prodottoDettaglio == null)
            {
                return HttpNotFound();
            }

            return View(prodottoDettaglio);
        }

        private Articolo GetProdottoById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Articoli WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Articolo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Prezzo = Convert.ToDecimal(reader["Prezzo"]),
                            DescrizioneDettagliata = reader["DescrizioneDettagliata"].ToString(),
                            ImmagineCopertina = reader["ImmagineCopertina"].ToString(),
                            ImmagineAggiuntiva1 = reader["ImmagineAggiuntiva1"].ToString(),
                            ImmagineAggiuntiva2 = reader["ImmagineAggiuntiva2"].ToString(),
                            InVendita = Convert.ToBoolean(reader["InVendita"])
                        };
                    }
                }
            }

            return null;
        }
    }
}
