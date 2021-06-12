// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using RestSharp;
using NUnit.Tests1;
using Newtonsoft.Json;

namespace Tests 
{

    public class Tests : BaseTest
    {
        CustomerAPI custApi; 

        
        [Test]
        public void GetallCustomersTest() {

        //    string response = getAllCustomers();
        }


        //my try
        [Test]
        public void GetSingleCustomersTest()
        {
            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";


            string jsonBody = JsonConvert.SerializeObject(cust);

            string responseData = custApi.CreateCustomer(jsonBody);
            
            CustomerResponse resp = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            int id = resp.data.id;
            string response = custApi.getSingleCustomer(id);
            //validation pending

        }

    /*        //This is your test case .. 
        [Test]
        public void CreateCustomer_Test() {
             string postBody = "{\"company_name\": \"jisjoy\", \"vat_number\": \"string\", \"phone\": \"0202020\", \"website\": \"jisjoy\",\"currency\": \"string\",\"country\": \"string\",\"default_language\": \"string\"}";
             string response = CreateCustomer(postBody);
            //validation pending
        }
        */

       

        public void CreateCustomerTest()
        {
            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency= "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";


            string jsonBody = JsonConvert.SerializeObject(cust);
           
            string responseData = custApi.CreateCustomer(jsonBody);
            CustomerResponse actualCustomer = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            //assertion
            Assert.AreEqual(cust, actualCustomer);

        }

      
            [Test]

        public void DeleteCustomer_Test() {

            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";

            
            string jsonBody = JsonConvert.SerializeObject(cust);
            CustomerAPI custApi = new CustomerAPI();
            string responseData = custApi.CreateCustomer(jsonBody);
            CustomerResponse res = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            int id = res.data.id;
            custApi.deleteCustomer(id);
            //validation pending
        }

       
       

        [Test]
        public void putcustomer_Test() {
            string updateBody = "{\"company_name\": \"jjoylearning\", \"vat_number\": \"string\", \"phone\": \"10101010\", \"website\": \"postmantutorial\",\"currency\": \"string\",\"country\": \"AU\",\"default_language\": \"en\"}";
            // string response  = putCustomer("12",updateBody);

          //  string response = custApi.putCustomer();

            //validation pending
        }


        
    }
}