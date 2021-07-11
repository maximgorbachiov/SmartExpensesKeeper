using CommonUtilities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmsParserService.Services
{
    public class DefaultSmsHandler : ISmsHandler
    {
        public Task<Purchase> ParseSms(SmsInfo smsInfo)
        {
            Purchase purchase = new Purchase();
            string currency = "BYN";

            return Task.Run(() =>
            {
                string[] words = smsInfo.Body.Split(' ').ToArray();

                string shopTitle = string.Empty;
                double total = 0.0;
                bool dateTimeSetted = false;
                bool shopTitleEnd = false;
                DateTime purchaseDateTime = DateTime.Now;

                for(int i = 0; i < words.Length; i++)
                {
                    if (!dateTimeSetted && DateTime.TryParse(words[i], out purchaseDateTime))
                    {
                        purchase.PurchaseTime = purchaseDateTime;
                    }

                    if (double.TryParse(words[i], out total))
                    {
                        if (i < words.Length - 1 && words[i + 1] == currency)
                        {
                            purchase.TotalSum = total;
                        }
                    }

                    if (!shopTitleEnd && words[i].ToUpper() == "BLR")
                    {
                        shopTitleEnd = true;
                    }

                    if (!shopTitleEnd && (words[i].ToUpper() == "SHOP" || words[i].ToUpper() == "MARKET"))
                    {
                        shopTitle += words[i];
                    }
                }

                purchase.Market = shopTitle;

                return purchase;
            });
        }
    }
}
