using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace QueueTrials;

public class App
{
public void Run(AppDbContext _context){
    AppInterface appInterface= new AppInterface();
    appInterface.Menu();
    string? value;
    while(true){
        value = Console.ReadLine();
        if(!string.IsNullOrEmpty(value)){
            break;
        }
        else{
            System.Console.WriteLine("Geçersiz giriş.");continue;
        }
    }
    if(value == "1"){
        CustomerController customerController = new CustomerController();
        appInterface.CustomerMenu();
        string? choice;
        while(true){
            choice = Console.ReadLine();
            if(!string.IsNullOrEmpty(choice)){
                break;
            }
            else{
                System.Console.WriteLine("Geçersiz giriş."); continue;
            }
        }
        if(choice=="1"){
            _context.customers.Add(customerController.CreateCustomer(CreateCustomerForm()));
            _context.SaveChanges();
        }
        else if(choice=="3"){
            List<Officer> officers = _context.officers.ToList();
            UpdateCustomerForm(officers);
        }
        else if(choice =="4"){
            List<Customer> customers = _context.customers.ToList();
            customerController.ListCustomers(customers);
        }
    }
}
public createCustomerDto CreateCustomerForm(){
    string? name;
    string? userName;
    string? adress;
    string? password;
    while(true){
        System.Console.WriteLine("Müşteri isim: ");
        name = Console.ReadLine();
        if(!string.IsNullOrEmpty(name)){
            break;
        }
        else{
            System.Console.WriteLine("Geçersiz giriş."); continue;
        }
        }
    while(true){
            System.Console.WriteLine("Müşteri kullanıcı adı: ");
            userName = Console.ReadLine();
            if(!string.IsNullOrEmpty (userName)){
                break;
            }
            else{
                System.Console.WriteLine("Geçersiz giriş."); continue;
            }
        }
    while(true){
            System.Console.WriteLine("Müşteri şifresi: ");
            string? passwordQuery = Console.ReadLine();
            if(!string.IsNullOrEmpty(passwordQuery)){
                System.Console.WriteLine("Şifre tekrar: ");
                string? passwordRepeatQuery = Console.ReadLine();
                if(!string.IsNullOrEmpty(passwordRepeatQuery)){
                    if(passwordRepeatQuery == passwordQuery){
                        password = passwordQuery;
                        break;
                    }
                    else{
                        System.Console.WriteLine("Şifreler aynı olmalı.");
                        continue;
                    }
                }
                else{
                    System.Console.WriteLine("Geçersiz giriş.");
                    continue;
                }
            }
            else{
                System.Console.WriteLine("Geçersiz giriş.");
                continue;
            }
        }
    while(true){
        System.Console.WriteLine("Müşteri adres:");
        adress = Console.ReadLine();
        if(!string.IsNullOrEmpty(adress)){
            break;
        }
        else{
            System.Console.WriteLine("Geçersiz giriş.");
            continue;
            }
        }
    createCustomerDto dto = new createCustomerDto{
        Name = name,
        Username = userName,
        Password = password,
        Address = adress,
        Balance = 0
    };
    return dto;
}
public void UpdateCustomerForm(List<Officer> officers){
     var officerService = new OfficerService();
     var authService = new AuthService(officerService);
     string? username;
     string? password;
     while(true){
        System.Console.WriteLine("Kullanıcı adınızı giriniz: ");
        username = Console.ReadLine();
        System.Console.WriteLine("Şifrenizi giriniz: ");
        password = Console.ReadLine();
        if(!string.IsNullOrEmpty(username)&&!string.IsNullOrEmpty(password)){
            break;
        }
        else{
            System.Console.WriteLine("Kullanıcı adı veya şifre boş bırakılamaz."); continue;
        }
     }
     var officer = officerService.Authenticate(username, password, officers);
     if(officer!=null){
        System.Console.WriteLine("Giriş başarılı.");
        if(officer.IsAdmin){
            System.Console.WriteLine("Admin");
        }
     }
     else{
        System.Console.WriteLine("Kullanıcı");
     }
}
}

