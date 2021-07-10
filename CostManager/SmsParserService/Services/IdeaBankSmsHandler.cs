using CommonUtilities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmsParserService.Services
{
    public class IdeaBankSmsHandler : ISmsHandler
    {
        public Task<Purchase> ParseSms(SmsInfo smsInfo)
        {
            Purchase purchase = new Purchase();

            int leftMoneyPhraseLength = 3;
            int sumAndCurrencyLength = 2;

            return Task.Run(() =>
            {
                string[] words = smsInfo.Body.Split(' ');

                purchase.PurchaseTime = DateTime.Parse(words[2]);

                if (words[4] == "Retail")
                {
                    words = words.Skip(5).ToArray();

                    int marketNameElemCount = words.Length - leftMoneyPhraseLength - sumAndCurrencyLength;
                    string[] marketTitleWords = words.Skip(2).Take(marketNameElemCount).ToArray();

                    purchase.Market = string.Join(' ', marketTitleWords);
                }
                else if (words[5] == "Debit")
                {
                    words = words.Skip(6).ToArray();
                }

                double sum;

                if (double.TryParse(words[0], out sum))
                {
                    purchase.TotalSum = Math.Abs(sum);
                }

                return purchase;
            });
        }
    }
}
