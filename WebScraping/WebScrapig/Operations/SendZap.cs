using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Operations
{
    public class SendZap
    {
        public static async void EnviarZap(string numZap, string nome, string precoLivre, string precoLuiza, string responseCompare)
        {

            try
            {

                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();
                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                parameters.Add("apikey", "B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY"); //switch to your api key
                parameters.Add("phone_number", "5579996103269"); //switch to your connected number
                parameters.Add("contact_phone_number", numZap); //switch to your number text to received message

                parameters.Add("message_custom_id", "testejp");
                parameters.Add("message_type", "text");
                parameters.Add("message_body", $"*Mercado Livre*\n" +
                           $"*Produto*: {nome}\n" +
                           $"*Preço*: R${precoLivre}\n" +
                           "\n" +
                           $"*Magazine Luiza*\n" +
                           $"*Produto*: {nome}\n" +
                           $"*Preço*: {precoLuiza}\n" +
                           "\n" +
                           $"{responseCompare}\n"+
                           "\n" +
                           "by BOT 0805 - João Pedro Barros Silva"); 



                


                string responseString = "";
                byte[] response_data;

                response_data = client.UploadValues(url, "POST", parameters);
                responseString = UnicodeEncoding.UTF8.GetString(response_data);

                Console.WriteLine(responseString);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"FAIL: {ex.Message}");
            }


        }
        public static bool AskZap(string opt)
        {
            if (opt.ToLower().Equals("sim"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
