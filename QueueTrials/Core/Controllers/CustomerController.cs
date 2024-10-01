using System.Security.Cryptography.X509Certificates;

namespace QueueTrials;

public class CustomerController
{
    public Customer CreateCustomer(createCustomerDto dto){
        return new Customer{
            Name = dto.Name,
            Username = dto.Username,
            Password = dto.Password,
            Address = dto.Address,
            Balance = dto.Balance,
        };
    }
    public void ListCustomers(List<Customer> customers){
    if(customers != null){
        foreach(var customer in customers){
            System.Console.WriteLine(customer.Name);
        }
    }
    }
    public void UpdateCustomer(UpdateCustomerDto dto){

    }
}
