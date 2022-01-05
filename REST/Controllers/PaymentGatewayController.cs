// Depreciated technology; maybe reintroduced in the next iteration

/* using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.Models;
using Stripe;

// namespace Rest.Controllers
// {

//     /// <summary>
//     /// Implementation from https://stripe.com/docs/payments/integration-builder?client=react&platform=web
//     /// </summary>
//     [ApiController]
//     [Route("[controller]")]
//     public class PaymentController : Controller
//     {
//         /// <summary>
//         /// This endpoint will create a Payment Intent for the Stripe Service account.
//         /// 
//         /// <see>https://stripe.com/docs/payments/payment-intents</see>
//         /// </summary>
//         /// <param name="request">
//         /// Sent by the client, this will inform use of what the client intends to purchase
//         /// and how to calculate their total accordingly
//         /// </param>
//         /// <returns>A client-secret token used to keep track of the PaymentIntent</returns>
//         [HttpPost("/[controller]/create-payment-intent")]
//         public async Task<ActionResult> CreatePayment(PaymentIntentCreateRequest request)
//         {
//             var paymentIntents = new PaymentIntentService();
//             var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
//             {
//                 Amount = CalculateOrderAmount(request.OccupationsToBuy),
//                 Currency = "usd",
//                 PaymentMethodTypes = new List<string> {
//           "card",
//         }
//             });

//             // This will be a token sent to the client.  When this token
//             // is created by the paymentIntent object above, Stripe will 
//             // register the payment intent for the registered account we 
//             // created and the token will be used to track whether a 
//             // payment succeded or failed. If the token is never used,
//             // Stripe will leave the paymentIntent marked as imcomplete.
//             return Json(new { clientSecret = paymentIntent.ClientSecret });
//         }

//         // TODO: Integrate a Stripe paymentIntent.successful webhook to allow us to register
//         //       valide payments into the DB.
//         [HttpPost("/[controller]/payment-success")]
//         public async Task<IActionResult> RecordSuccesfulPayment()
//         {
//             throw new NotImplementedException();
//         }

        // TODO: determine how prices are stored in the DB for each Occupation
        private int CalculateOrderAmount(Occupation[] OccupationsToBuy)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            int pricePerOccupation = 2000; // Placeholder cost per Occupation, 2000 is equal to $20 usd
            return pricePerOccupation * OccupationsToBuy.Length;
        }
    }
} */
