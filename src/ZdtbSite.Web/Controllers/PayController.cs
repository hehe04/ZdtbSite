using PayPal.Api;
using PayPal.Sample;
using PayPal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using ZdtbSite.Web.Models;

namespace ZdtbSite.Web.Controllers
{
    public class PayController : Controller
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<Contract> ContractRepository;
        private IUnitOfWork unitOfWork;
        public PayController(IRepository<Customer> customerRepository, IRepository<Contract> ContractRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.ContractRepository = ContractRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: Pay
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Process(Models.PayViewModel model)
        {
            var customer = customerRepository.Get(e => e.Email == model.Email);
            if (customer == null)
            {
                customer = new Customer();
                customer.Email = model.Email;
                customer.CreateTime = DateTime.Now;
                customer.Phone = model.Phone;
                customer.IPAddress = Request.UserHostName;
                customer.Number = DateTime.Now.Ticks;
                customer.Count = 1;
                customerRepository.Add(customer);
                unitOfWork.Commit();
            }

            Contract contract = new Contract();
            contract.CreateTime = DateTime.Now;
            contract.Customer = customer;
            contract.IsSuccess = false;
            contract.Prepayments = model.Amount;
            contract.Status = ContractStatus.NotSigned;
            contract.Title = model.Name + ":[金额 ：　" + model.Amount + "]";
            ContractRepository.Add(contract);
            unitOfWork.Commit();

            //model.AttachData = contract.Id.ToString();
            //string hots = Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port + "/";
            //string content = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            //string result = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(content));
            //string returnURL = hots + "Pay/PayCallback?data=" + contract.Id.ToString();
            //PaypalViewModel paypal = new PaypalViewModel(ConfigurationManager.AppSettings["APIUserName"], "Amount information:" + model.Amount, model.Amount, returnURL, ConfigurationManager.AppSettings["paypalAction"]);

            //return View("~/Views/Pay/Redirect.cshtml", paypal);
            var apiContext = Configuration.GetAPIContext();

            //string payerId = Request.Params["PayerID"];
            //if (string.IsNullOrEmpty(payerId))
            //{
            // ###Items
            // Items within a transaction.
            var itemList = new ItemList()
            {
                items = new List<Item>() 
                    {
                        new Item()
                        {
                            name = "Amount information",
                            currency = "USD",
                            price = model.Amount.ToString(),
                            quantity = "1",
                            sku = "sku"
                        }
                    }
            };

            // ###Payer
            // A resource representing a Payer that funds a payment
            // Payment Method
            // as `paypal`
            var payer = new Payer() { payment_method = "paypal" };

            // ###Redirect URLS
            // These URLs will determine how the user is redirected from PayPal once they have either approved or canceled the payment.
            var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Pay/PayCallback?";
            var redirectUrl = baseURI + "id=" + contract.Id;
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&cancel=true",
                return_url = redirectUrl
            };

            // ###Details
            // Let's you specify details of a payment amount.
            var details = new Details()
            {
                tax = "0.00",
                shipping = "0.00",
                subtotal = model.Amount.ToString()
            };

            // ###Amount
            // Let's you specify a payment amount.
            var amount = new Amount()
            {
                currency = "USD",
                total = model.Amount.ToString("F2"), // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };

            // ###Transaction
            // A transaction defines the contract of a
            // payment - what is the payment for and who
            // is fulfilling it. 
            var transactionList = new List<Transaction>();

            // The Payment creation API requires a list of
            // Transaction; add the created `Transaction`
            // to a List
            transactionList.Add(new Transaction()
            {
                description = "Transaction description.",
                invoice_number = Common.GetRandomInvoiceNumber(),
                amount = amount,
                item_list = itemList
            });

            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            var createdPayment = payment.Create(apiContext);
            Session.Add(contract.Id.ToString(), createdPayment.id);
            var links = createdPayment.links.GetEnumerator();
            string redirect = string.Empty;
            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    redirect = link.href;
                }
            }
            return Redirect(redirect);
        }

        public ActionResult PayCallback(string id)
        {
            string msg = "Payment failed!";
            string payerId = Request.Params["PayerID"];
            if (!string.IsNullOrEmpty(payerId))
            {
                var apiContext = Configuration.GetAPIContext();
                var paymentId = Session[id] as string;
                var paymentExecution = new PaymentExecution() { payer_id = payerId };
                var payment = new Payment() { id = paymentId };

                var executedPayment = payment.Execute(apiContext, paymentExecution);
                if (executedPayment.state.ToLower().Equals("approved"))
                {
                    var contractModel = ContractRepository.GetById(int.Parse(id));
                    if (contractModel == null)
                    {
                        msg = "The contract is null!";
                    }
                    else
                    {
                        contractModel.IsSuccess = true;
                        unitOfWork.Commit();
                        msg = "Payment success!";
                    }
                }
            }
            ViewBag.Message = msg;
            return View("Message");
        }
    }
}