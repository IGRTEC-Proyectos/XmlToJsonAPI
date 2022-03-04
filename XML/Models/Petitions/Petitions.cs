using Newtonsoft.Json;
using RestSharp;
using System;
using System.Windows.Forms;
using XML.Clases;
using XML.Models.Response;

namespace XML.Models.Petitions
{
    public class Petitions
    {
        private string domain = "https://soporte.clandbus.com";

        #region POST Requests
        public bool loginPostRequest()
        {
            try
            {
                var client = new RestClient($"{domain}/mejorcompra/entity/auth/login");
                client.Timeout = -1;
                //client.Authenticator = new HttpBasicAuthenticator("client-app", "secret");
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(new { name = "test1@clandbus.com", password = "sHJag^&L78Uns3&", tenant = "{{tenant}}", locale = "en-US" });
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    foreach (var cookie in response.Cookies)
                    {
                        switch (cookie.Name)
                        {
                            case "ASP.NET_SessionId":
                                CookiesResponse.ASPNetSessionID = cookie.Value;
                                break;
                            case "UserBranch":
                                CookiesResponse.UserBrach = cookie.Value;
                                break;
                            case "Locale":
                                CookiesResponse.Locale = cookie.Value;
                                break;
                            case ".ASPXAUTH":
                                CookiesResponse.ASPXAuth = cookie.Value;
                                break;
                            case "requestid":
                                CookiesResponse.RequestID = cookie.Value;
                                break;
                            case "requeststat":
                                CookiesResponse.RequestStat = cookie.Value;
                                break;
                        }
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar sesión: \n" + response.StatusCode.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void logoutPostRequest()
        {
            try
            {
                var client = new RestClient("https://soporte.clandbus.com/mejorcompra/entity/auth/logout");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                Console.WriteLine(response.StatusDescription);
                Console.WriteLine(response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region PUT Requests
        public bool newSalePutRequest(Factura fact)
        {
            try
            {
                var client = new RestClient($"{domain}/mejorcompra/entity/OLX/17.200.001/SalesOrders");
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddCookie(".ASPXAuth", CookiesResponse.ASPXAuth);
                request.AddCookie("ASP.NET_SessionId", CookiesResponse.ASPNetSessionID);
                request.AddCookie("Locale", CookiesResponse.Locale);
                request.AddCookie("UserBrach", CookiesResponse.UserBrach);
                request.AddCookie("requestID", CookiesResponse.RequestID);
                request.AddCookie("requestStat", CookiesResponse.RequestStat);

                var body = JsonConvert.SerializeObject(fact);

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Documento enviado con éxito", response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al enviar el documento: \n" + response.Content, response.StatusCode.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        #endregion

    }
}
